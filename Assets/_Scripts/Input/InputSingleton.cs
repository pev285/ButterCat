using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.InputControls
{

	public static class InputSingleton
	{
        private static IInputInterface _instance;
        public static IInputInterface Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PCInput();
                }
                return _instance;
            }
        }
		
	} // end of class //

} // end of namespace //