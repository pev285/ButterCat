using ButterCat.DockingAndHolding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Butterfly
{
    [RequireComponent(typeof(ButterflyAnimationController), typeof(DockableBehaviour), typeof(ButterflyController))]
    [RequireComponent(typeof(HoldingPointComponent), typeof(DockingPointComponent), typeof(Rigidbody))]
    public class ButterflyScript : MonoBehaviour, IDockable, IDockStation
    {

        #region OtherComponents

        Rigidbody rb = null;
        protected Rigidbody RB
        {
            get
            {
                if (rb == null)
                {
                    rb = GetComponent<Rigidbody>();
                }
                return rb;
            }
        }

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
                    controllerComponent.Init(RB);
                }
                return controllerComponent;
            }
        }

        HoldingPointComponent holdingPointComponent = null;
        HoldingPointComponent HoldingPointComponent
        {
            get
            {
                if (holdingPointComponent == null)
                {
                    holdingPointComponent = GetComponent<HoldingPointComponent>();
                }
                return holdingPointComponent;
            }
        }

        DockingPointComponent dockingPointComponent = null;
        DockingPointComponent DockingPointComponent
        {
            get
            {
                if (dockingPointComponent == null)
                {
                    dockingPointComponent = GetComponent<DockingPointComponent>();
                }
                return dockingPointComponent;
            }
        }
        public Transform DockingPoint // IDockingStation //
        {
            get
            {
                return DockingPointComponent.DockingPoint;
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

