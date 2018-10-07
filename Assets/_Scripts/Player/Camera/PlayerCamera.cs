using ButterCat.DockingAndHolding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Camera

{
    [RequireComponent(typeof(SatteliteWatcher), typeof(DockableBehaviour), typeof(PlayerCameraController))]
    public class PlayerCamera : MonoBehaviour, ISattelite
    {

        #region RequiredComponents

        private SatteliteWatcher satteliteWatcher = null;
        protected SatteliteWatcher SatteliteWatcher
        {
            get
            {
                if (satteliteWatcher == null)
                {
                    satteliteWatcher = GetComponent<SatteliteWatcher>();
                }
                return satteliteWatcher;
            }
        }

        private DockableBehaviour dockableBehaviour = null;
        protected DockableBehaviour DockableBehaviour
        {
            get
            {
                if (dockableBehaviour == null)
                {
                    dockableBehaviour = GetComponent<DockableBehaviour>();
                }
                return dockableBehaviour;
            }
        }

        private PlayerCameraController controller = null;
        protected PlayerCameraController Controller
        {
            get
            {
                if (controller == null)
                {
                    controller = GetComponent<PlayerCameraController>();
                }
                return controller;
            }
        }

        #endregion

        #region ISattelite implementations

        public Vector3 Forward
        {
            get
            {
                return satteliteWatcher.Forward;
            }
        }

        public Vector3 SattelitePosition
        {
            get
            {
                return satteliteWatcher.SattelitePosition;
            }
        }

        public Quaternion SatteliteRotation
        {
            get
            {
                return satteliteWatcher.SatteliteRotation;
            }
        }


        public void SetPivotTransform(Transform tr)
        {
            satteliteWatcher.SetPivotTransform(tr);
            SetSlotToDockTo();
        }

        public void SetDefaultRelativePosition(Vector3 position)
        {
            satteliteWatcher.SetDefaultRelativePosition(position);
            SetSlotToDockTo();
        }

        public void SetSatteliteTransform(Transform tr)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnToDefaultPosition()
        {
            satteliteWatcher.ReturnToDefaultPosition();
        }

        #endregion

        public void SetSlotToDockTo()
        {
            DockableBehaviour.SetSlotToDockTo(satteliteWatcher.SatteliteTransform, DockingHardness.SMOOTH);
        }

    } // end of class ///
} // end of namespace ///

