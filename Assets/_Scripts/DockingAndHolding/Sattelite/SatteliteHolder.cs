using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{
    public class SatteliteHolder : MonoBehaviour, ISatteliteHolder
    {
        [SerializeField]
        Transform transformToLookAt;
        public Transform TransformToLookAt
        {
            get
            {
                return transformToLookAt;
            }
        }

        [SerializeField]
        Transform satteliteDefaultTransform;
        public Vector3 SatteliteDefaultRelativePosition
        {
            get
            {
                return satteliteDefaultTransform.position - transformToLookAt.position;
            }
        } 
	
	} // END OF CLASS ///
	
} // END OF NAMESPACE ///


