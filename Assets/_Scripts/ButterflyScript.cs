using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyScript : MonoBehaviour {

    private Transform slotToDockTo;

    public void SetSlotToDockTo(Transform tr)
    {
        slotToDockTo = tr;
    }

    private void Update()
    {
        if (slotToDockTo != null)
        {
            transform.position = slotToDockTo.position;
            transform.rotation = slotToDockTo.rotation;
        }
    } // Update() ///

}
