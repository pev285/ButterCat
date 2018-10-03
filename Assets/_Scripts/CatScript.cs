using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    [SerializeField]
    Transform dockingSlot;
    public Transform DockingSlot
    {
        get
        {
            return dockingSlot;
        }
    }

} // End of class ///
