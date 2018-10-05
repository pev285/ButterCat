using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.InputControls
{

    public class PCInput : IInputInterface
    {
        private const string FLY_UP_KEY = "FlyUpAxis";

        #region flying

        public bool FlyStartStopEvent
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
                return Input.GetAxis("Vertical");
            }
        }

        public float FlyTurnAxis
        {
            get
            {
                return Input.GetAxis("Horizontal");
            }
        }

        public float FlyUpAxis
        {
            get
            {
                return Input.GetAxis(FLY_UP_KEY);
            }
        }

        #endregion


        #region Walking

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


        #endregion

        #region CameraControl

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

        #endregion

    } // end of class //

} // end of namespace //