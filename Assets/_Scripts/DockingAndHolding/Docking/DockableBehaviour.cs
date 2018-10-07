using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{
    public enum DockingHardness
    {
        SMOOTH,
        HARD
    }


    public class DockableBehaviour : MonoBehaviour, IDockable 
	{

        private Vector3 currentSmoothMovementVelocity = Vector3.zero;
        private float sooothMovementTime = 1f;
        private float smoothRotationSpeed = 90;

        private Transform slotToDockTo;
        private DockingHardness dockingHardness;
        public void SetSlotToDockTo(Transform tr, DockingHardness hardness = DockingHardness.HARD)
        {
            slotToDockTo = tr;
            dockingHardness = hardness;
        }


        private void Update()
        {
            if (slotToDockTo != null)
            {
                switch (dockingHardness)
                {
                    case DockingHardness.HARD:
                        transform.position = slotToDockTo.position;
                        transform.rotation = slotToDockTo.rotation;
                        break;
                    case DockingHardness.SMOOTH:
                        transform.position = Vector3.SmoothDamp(transform.position, slotToDockTo.position, ref currentSmoothMovementVelocity, sooothMovementTime);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, slotToDockTo.rotation, smoothRotationSpeed * Time.deltaTime);
                        break;
                }
            }
        } // Update() ///

    } // end of class //
} // end of namespace //