using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{


	public class HoldingPointComponent : MonoBehaviour 
	{

        [SerializeField]
        private Transform holdingPoint;
        public Transform HoldingPoint
        {
            get
            {
                return holdingPoint;
            }
        }

    } // end of class //

} // end of namespace //