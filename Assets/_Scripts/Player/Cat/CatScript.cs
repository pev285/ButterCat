using ButterCat.DockingAndHolding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Cat
{

    [RequireComponent(typeof(DockingPointComponent), typeof(HoldingPointComponent))]
    [RequireComponent(typeof(CatController), typeof(CatAnimationController), typeof(SatteliteHolder))]
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class CatScript : PlayerCharacterBase, IDockStation
    {

        #region RequiredComponents



        private Animator animator = null;
        protected Animator Animator
        {
            get
            {
                if (animator == null)
                {
                    animator = GetComponent<Animator>();
                }
                return animator;
            }
        }

        private DockingPointComponent dockingPointComponent = null;
        protected DockingPointComponent DockingPointComponent
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
        public Transform DockingPoint
        {
            get
            {
                return DockingPointComponent.DockingPoint;
            }
        }


        private CatController controller = null;
        protected CatController Controller
        {
            get
            {
                if (controller == null)
                {
                    controller = GetComponent<CatController>();
                }
                return controller;
            }
        }

        private CatAnimationController animationController = null;
        protected CatAnimationController AnimationController
        {
            get
            {
                if (animationController == null)
                {
                    animationController = GetComponent<CatAnimationController>();
                }
                return animationController;
            }
        }




        #endregion

        



        protected override void UpdateActingState()
        {

        }


    } // End of class ///
}

