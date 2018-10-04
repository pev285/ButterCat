using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.InputControls
{
    public class PCInput : IInputInterface
    {

        private const string FlyAxisKey = "FlyAxis";

        public bool FlyEvent
        {
            get
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    return true;
                }
                return false;
            }
        }

        public float FlyForwardAxis
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public float FlyTurnAxis
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public float MoveForwardAxis
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public float TurnAxis
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public float ViewUpAxis
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public float ViewRightAxis
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }




    } // end of class //

} // end of namespace //