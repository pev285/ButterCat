using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{
	public interface IDockable
	{
        void SetSlotToDockTo(Transform tr, DockingHardness hardness = DockingHardness.HARD);
    } // end of class //

} // end of namespace //