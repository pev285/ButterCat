using ButterCat.InputControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Behaviour
{


	public class CustomBehaviour : MonoBehaviour 
	{

        // Common access point to input object //
        IInputInterface inputObject;
        protected IInputInterface InputSource
        {
            get
            {
                if (inputObject == null)
                {
                    inputObject = InputSingleton.Instance;
                }
                return inputObject;
            }
        }
		
	} // end of class //

} // end of namespace //