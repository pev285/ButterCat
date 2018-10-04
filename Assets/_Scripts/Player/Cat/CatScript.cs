using ButterCat.DockingAndHolding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Cat
{

    [RequireComponent(typeof(DockingPointComponent), typeof(HoldingPointComponent))]
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

        #endregion




    } // End of class ///
}

