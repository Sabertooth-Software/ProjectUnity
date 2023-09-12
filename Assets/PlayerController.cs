using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTest
{ 
    public class PlayerController : MonoBehaviour
    {
        CharacterController controller;
        float turnSmoothTime = 0.1f;
        float turnSmoothVelocity;
        Vector3 direction = Vector3.zero;
        float targetAngle = 0f;
        float angle = 0f;
        public Transform cam;
        private float currentSpeed = 3.5f;

        private bool camChanged = false;
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        public void CameraChange()
        {
            camChanged = true;
        }
        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (Input.GetKeyDown("g")){
                Debug.Log("button");
            }

            if (direction.magnitude >= 0.1f)
            {
                if (!camChanged)
                {
                    targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                }
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                    turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            }
            else camChanged = false;
        }
    }
}
