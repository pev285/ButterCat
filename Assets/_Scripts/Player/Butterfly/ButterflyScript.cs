using ButterCat.DockingAndHolding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Butterfly
{
    [RequireComponent(typeof(ButterflyAnimationController), typeof(DockableBehaviour), typeof(ButterflyController))]
    [RequireComponent(typeof(HoldingPointComponent))]
    public class ButterflyScript : MonoBehaviour, IDockable
    {

        #region OtherComponents

        ButterflyAnimationController animationController;
        protected ButterflyAnimationController AnimationController
        {
            get
            {
                if (animationController == null)
                {
                    animationController = GetComponent<ButterflyAnimationController>();
                }
                return animationController;
            }
        }

        DockableBehaviour docableComponent;
        protected DockableBehaviour DocableComponent
        {
            get
            {
                if (docableComponent == null)
                {
                    docableComponent = GetComponent<DockableBehaviour>();
                }
                return docableComponent;
            }
        }

        ButterflyController controllerComponent;
        ButterflyController ControllerComponent
        {
            get
            {
                if (controllerComponent == null)
                {
                    controllerComponent = GetComponent<ButterflyController>();
                }
                return controllerComponent;
            }
        }

        HoldingPointComponent holdingPoint = null;
        HoldingPointComponent HoldingPoint
        {
            get
            {
                if (holdingPoint == null)
                {
                    holdingPoint = GetComponent<HoldingPointComponent>();
                }
                return holdingPoint;
            }
        }
        #endregion


        private Transform slotToDockTo = null;

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
                //if (isFlying == value)
                //{
                //    return;
                //}

                isFlying = value;

                UpdateFlyingState();
            } // set //
        } // IsFlying ///

        private void UpdateFlyingState()
        {
            UpdateAnimationState();
            UpdateDockingState();
            UpdateControllerState();
        }

        private void UpdateControllerState()
        {
            ControllerComponent.enabled = IsFlying;
        }

        private void UpdateDockingState()
        {
            if (isFlying)
            {
                DocableComponent.SetSlotToDockTo(null);
            }
            else
            {
                DocableComponent.SetSlotToDockTo(slotToDockTo, DockingHardness.HARD);
            }
        }

        private void UpdateAnimationState()
        {
            AnimationController.UpdateAnimation(isFlying);
        }


        /**
         * Method to external calls only.
         */
        public void SetSlotToDockTo(Transform tr, DockingHardness hardness)
        {
            // Save locally docing transform
            slotToDockTo = tr;
            // Use doable component to set desired docking
            DocableComponent.SetSlotToDockTo(tr, hardness);
        }


    } // end of class ///
}

