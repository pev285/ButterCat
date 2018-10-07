using ButterCat.DockingAndHolding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Butterfly
{
    [RequireComponent(typeof(ButterflyAnimationController), typeof(DockableBehaviour), typeof(ButterflyController))]
    [RequireComponent(typeof(HoldingPointComponent), typeof(Rigidbody))]
    [RequireComponent(typeof(SatteliteHolder))]
    public class ButterflyScript : PlayerCharacterBase, IDockable /*, IDockStation*/
    {

        #region RequiredComponents



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



        /*
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
*/



        #endregion


        private Transform slotToDockTo = null;




        protected override void UpdateActingState()
        {
            UpdateAnimationState();
            UpdateDockingState();
            UpdateControllerState();
        }

        private void UpdateControllerState()
        {
            ControllerComponent.enabled = IsActing;
        }

        private void UpdateDockingState()
        {
            if (IsActing)
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
            AnimationController.UpdateAnimation(IsActing);
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

