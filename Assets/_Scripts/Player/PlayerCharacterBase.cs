using ButterCat.DockingAndHolding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(HoldingPointComponent), typeof(SatteliteHolder))]
	public abstract class PlayerCharacterBase : MonoBehaviour, ISatteliteHolder
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

        private SatteliteHolder satteliteHolder = null;
        protected SatteliteHolder SatteliteHolder
        {
            get
            {
                if (satteliteHolder == null)
                {
                    satteliteHolder = GetComponent<SatteliteHolder>();
                }
                return satteliteHolder;
            }
        }

        #region ISatteliteHolder

        public Transform TransformToLookAt
        {
            get
            {
                return SatteliteHolder.TransformToLookAt;
            }
        }

        public Vector3 SatteliteDefaultRelativePosition
        {
            get
            {
                return SatteliteHolder.SatteliteDefaultRelativePosition;
            }
        }

        #endregion


        #endregion


        [SerializeField]
        private bool isActing = false;
        public bool IsActing
        {
            get
            {
                return isActing;
            }
            set
            {
                isActing = value;

                UpdateActingState();
            }
        } // IsActing ///

        protected abstract void UpdateActingState();

    } // END OF CLASS ///

} // END OF NAMESPACE ///


