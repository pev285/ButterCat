using ButterCat.DockingAndHolding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Cat
{

    [RequireComponent(typeof(DockingPointComponent), typeof(HoldingPointComponent))]
    [RequireComponent(typeof(CatController), typeof(CatAnimationController))]
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class CatScript : MonoBehaviour, IDockStation
    {

        #region RequiredComponents

        private Rigidbody rb = null;
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

        private HoldingPointComponent holdingPointComponent = null;
        protected HoldingPointComponent HoldingPointComponent
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




    } // End of class ///
}

