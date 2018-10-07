using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{
	public interface ISattelite 
	{
        // Pivot to rotate around
        void SetPivotTransform(Transform tr);
        // Position of sattelite relative to pivot
        void SetDefaultRelativePosition(Vector3 position);
        // Optional: the transform of a sattelite which to rotate around the pivot
        void SetSatteliteTransform(Transform tr);


        Vector3 Forward { get; }
        Vector3 SattelitePosition { get; }
        Quaternion SatteliteRotation { get; }


        void ReturnToDefaultPosition();




    } // END OF CLASS ///
	
} // END OF NAMESPACE ///


