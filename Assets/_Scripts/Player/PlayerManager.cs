using ButterCat.Behaviour;
using ButterCat.DockingAndHolding;
using ButterCat.InputControls;
using ButterCat.Player.Butterfly;
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
        Transform playerCamera;


        Dictionary<CharacterType, Transform> characters;
        ButterflyScript butterfly;
        CatScript cat;

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



            GoToCatMode();
        } // Start() ////


        private void Update()
        {
            ProcessInput();
        } // Update() ///


        private void ProcessInput()
        {
            if (InputSource.FlyEvent)
            {
                if (butterfly.IsFlying)
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
            butterfly.IsFlying = false;
        }

        private void GoToButterflyMode()
        {
            butterfly.IsFlying = true;
        }


    } // end of class ///
}

