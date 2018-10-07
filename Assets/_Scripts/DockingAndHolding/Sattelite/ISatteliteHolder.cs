using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{
	public interface ISatteliteHolder
	{

        Transform TransformToLookAt { get; }
        Vector3 SatteliteDefaultRelativePosition { get; }

    } // END OF CLASS ///
	
} // END OF NAMESPACE ///


