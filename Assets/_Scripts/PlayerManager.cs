using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

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


    Dictionary<CharacterType, Transform> characters;

    private void Start()
    {
        characters = new Dictionary<CharacterType, Transform>();

        foreach(var pair in characterPrefabs)
        {
            GameObject go = Instantiate(pair.prefab, transform.position, transform.rotation);
            Transform tr = go.GetComponent<Transform>();
            characters.Add(pair.type, tr);
        }

        // TODO: Make some general way to attach one possessable character object to another ///
        ButterflyScript bs = characters[CharacterType.BUTTERFLY].GetComponent<ButterflyScript>();
        CatScript cs = characters[CharacterType.CAT].GetComponent<CatScript>();
        bs.SetSlotToDockTo(cs.DockingSlot);


    } // Start() ////


}
