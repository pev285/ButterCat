using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{


	public class DockingPointComponent : MonoBehaviour, IDockStation
	{
        [SerializeField]
        private Transform dockingPoint;
        public Transform DockingPoint
        {
            get
            {
                return dockingPoint;
            }
        }

    } // end of class //

} // end of namespace //