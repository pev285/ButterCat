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
        protected Transform PivotTransform
        {
            set
            {
                pivotTransform = value;
                ReinitValues();
            }
            get
            {
                return pivotTransform;
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
                    temporaryGO = new GameObject("SatteliteTransform");
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
                ReinitValues();
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
            PivotTransform = tr;
        }

        public void SetDefaultRelativePosition(Vector3 relativePosition)
        {
            defaultRelativePosition = relativePosition;
            SatteliteTransform.position = PivotTransform.position + relativePosition;

            ReinitValues();
        }

        public void SetSatteliteTransform(Transform tr)
        {
            SatteliteTransform = tr;
        }

        #endregion


        private Vector3 defaultRelativePosition;

        private float distance = 0;


        private void ReinitValues()
        {
            defaultRelativePosition = SatteliteTransform.position - PivotTransform.position;
            distance = defaultRelativePosition.magnitude;
        }



        private void LateUpdate()
        {
            UpdatePosition();
            UpdateRotation();
        }

        private void UpdatePosition()
        {
            SatteliteTransform.position = PivotTransform.position + defaultRelativePosition;
        }

        private void UpdateRotation()
        {
            //Debug.Log("satPos = " + SattelitePosition + ", pivPos = " + PivotTransform.position);
            Vector3 forward = PivotTransform.position - SattelitePosition;
            Vector3 right = Vector3.Cross( Vector3.up, forward);
            Vector3 up = Vector3.Cross(forward, right);
            Debug.DrawLine(SattelitePosition, SattelitePosition + forward, Color.blue);
            Debug.DrawLine(SattelitePosition, SattelitePosition + right, Color.red);
            Debug.DrawLine(SattelitePosition, SattelitePosition + up, Color.green);


            SatteliteTransform.rotation = Quaternion.LookRotation(PivotTransform.position - SattelitePosition, up);
        }

        public void ReturnToDefaultPosition()
        {
            SatteliteTransform.position = PivotTransform.position + defaultRelativePosition;
            UpdateRotation();
        }
    }
}

