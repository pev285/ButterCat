using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat
{
    public class ButterflyScript : MonoBehaviour
    {

        private Transform slotToDockTo;

        ButterflyAnimationController animationController;

        [SerializeField]
        private bool isFlying = false;
        public bool IsFlying
        {
            get
            {
                return isFlying;
            }
            set
            {
                if (isFlying == value)
                {
                    return;
                }

                isFlying = value;

                UpdateAnimation();
            } // set //
        } // IsFlying ///

        private void UpdateAnimation()
        {
            if (animationController == null)
            {
                animationController = GetComponent<ButterflyAnimationController>();
            }
            animationController.UpdateAnimation(isFlying);
        }

        private void Start()
        {
            UpdateAnimation();
        }


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

    } // end of class ///
}

