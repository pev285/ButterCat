using ButterCat.Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Butterfly
{


	public class ButterflyController : CustomBehaviour
	{

        [SerializeField]
        float movementSpeed = 5f;
        [SerializeField]
        float rotationSpeed = 180f;

        private Rigidbody RB = null;

        public void Init(Rigidbody rb)
        {
            this.RB = rb;
        }

        private void Update()
        {
            if (RB != null)
            {
                float forward = InputSource.FlyForwardAxis;
                float turn = InputSource.FlyTurnAxis;
                float up = InputSource.FlyUpAxis;

                Vector3 shift = (RB.transform.forward * forward + Vector3.up * up) * Time.deltaTime * movementSpeed;
                if (shift != Vector3.zero)
                {
                    RB.MovePosition(RB.position + shift);
                }

                if (turn != 0)
                {
                    RB.MoveRotation(RB.rotation * Quaternion.Euler(0, Time.deltaTime * turn * rotationSpeed, 0));
                }
            }

        } // Update() ///


    } // end of class //

} // end of namespace //