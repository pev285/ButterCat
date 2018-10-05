﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.InputControls
{


	public interface IInputInterface
	{
        bool FlyStartStopEvent { get; }

        // Presume all axes return values in [-1, 1]

        float FlyForwardAxis { get; }
        float FlyTurnAxis { get; }
        float FlyUpAxis { get; }

        float MoveForwardAxis { get; }
        float TurnAxis { get; }

        float ViewUpAxis { get; }
        float ViewRightAxis { get; }
		
	} // end of class //

} // end of namespace //