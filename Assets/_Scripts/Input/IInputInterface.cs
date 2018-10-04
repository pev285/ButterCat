using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.InputControls
{


	public interface IInputInterface
	{
        bool FlyEvent { get; }

        float FlyForwardAxis { get; }
        float FlyTurnAxis { get; }

        float MoveForwardAxis { get; }
        float TurnAxis { get; }

        float ViewUpAxis { get; }
        float ViewRightAxis { get; }
		
	} // end of class //

} // end of namespace //