using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.DockingAndHolding
{
    public class SatteliteWatcher : MonoBehaviour, ISattelite
    {
        #region Transforms

        // Indicates position of the rotation centre ///
        Transform pivotTransform;
        public Transform PivotTransform
        {
            set
            {
                pivotTransform = value;
            }
        }

        // Indicates position of a sattelite //
        Transform satteliteTransform;
        GameObject temporaryGO;
        public Transform SatteliteTransform
        {
            get
            {
                if (satteliteTransform == null)
                {
                    temporaryGO = new GameObject();
                    satteliteTransform = temporaryGO.transform;
                }
                return satteliteTransform;
            }
            set
            {
                if (temporaryGO != null)
                {
                    Destroy(temporaryGO);
                }
                satteliteTransform = value;
            }
        }

        #endregion





        #region ISattelite implementations

        public Vector3 Forward
        {
            get
            {
                Vector3 direction = pivotTransform.position - SatteliteTransform.position;
                direction.y = 0;
                return direction.normalized;
            }
        }

        public Vector3 SattelitePosition
        {
            get
            {
                return SatteliteTransform.position;
            }
        }

        public Quaternion SatteliteRotation
        {
            get
            {
                return SatteliteTransform.rotation;
            }
        }




        public void SetPivotTransform(Transform tr)
        {
            pivotTransform = tr;
            ReinitValues();
        }

        public void SetDefaultRelativePosition(Vector3 position)
        {
            SatteliteTransform.position = position;
            ReinitValues();
        }

        public void SetSatteliteTransform(Transform tr)
        {
            SatteliteTransform = tr;
            ReinitValues();
        }

        #endregion


        private Vector3 defaultRelativePosition;

        private float distance = 0;


        private void ReinitValues()
        {
            defaultRelativePosition = pivotTransform.position - SatteliteTransform.position;
            distance = defaultRelativePosition.magnitude;
        }



        private void LateUpdate()
        {
            UpdatePosition();
            UpdateRotation();
        }

        private void UpdatePosition()
        {

        }

        private void UpdateRotation()
        {
            SatteliteTransform.rotation.SetLookRotation(pivotTransform.position - SatteliteTransform.position);
        }

        public void ReturnToDefaultPosition()
        {
            SatteliteTransform.position = pivotTransform.position + defaultRelativePosition;
            UpdateRotation();
        }
    }
}

