using ButterCat.Behaviour;
using ButterCat.DockingAndHolding;
using ButterCat.InputControls;
using ButterCat.Player.Butterfly;
using ButterCat.Player.Camera;
using ButterCat.Player.Cat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ButterCat.Player
{
    public class PlayerManager : CustomBehaviour
    {

        public enum CharacterType
        {
            CAT,
            BUTTERFLY
        }

        [Serializable]
        public struct TypePrefabPair
        {
            public CharacterType type;
            public GameObject prefab;
        }

        [SerializeField]
        List<TypePrefabPair> characterPrefabs;
        [SerializeField]
        Transform playerCameraTransform;


        Dictionary<CharacterType, Transform> characters;
        ButterflyScript butterfly;
        CatScript cat;
        new PlayerCamera camera;

        private void Start()
        {
            characters = new Dictionary<CharacterType, Transform>();

            foreach (var pair in characterPrefabs)
            {
                GameObject go = Instantiate(pair.prefab, transform.position, transform.rotation);
                Transform tr = go.GetComponent<Transform>();
                characters.Add(pair.type, tr);
            }

            // TODO ?? : Make some general way to attach one possessable character object to another ///
            butterfly = characters[CharacterType.BUTTERFLY].GetComponent<ButterflyScript>();
            cat = characters[CharacterType.CAT].GetComponent<CatScript>();
            butterfly.SetSlotToDockTo(cat.DockingPoint, DockingHardness.HARD);
            camera = GetComponent<PlayerCamera>();


            GoToCatMode();
        } // Start() ////


        private void Update()
        {
            ProcessInput();
        } // Update() ///


        private void ProcessInput()
        {
            if (InputSource.FlyStartStopEvent)
            {
                if (butterfly.IsActing)
                {
                    GoToCatMode();
                }
                else
                {
                    GoToButterflyMode();
                }
            }
        } // ProcessInput() ///


        private void GoToCatMode()
        {
            butterfly.IsActing = false;
            cat.IsActing = true;

            camera.SetPivotTransform(cat.TransformToLookAt);
            camera.SetDefaultRelativePosition(cat.SatteliteDefaultRelativePosition);
        }

        private void GoToButterflyMode()
        {
            butterfly.IsActing = true;
            cat.IsActing = false;

            camera.SetPivotTransform(butterfly.TransformToLookAt);
            camera.SetDefaultRelativePosition(butterfly.SatteliteDefaultRelativePosition);
        }


    } // end of class ///
}

