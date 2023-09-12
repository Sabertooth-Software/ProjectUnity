using UnityEditor.UI;
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

            if (!camChanged)
            {
                targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            }

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            RaycastHit hit;
            Vector3 facing = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, facing, out hit, Mathf.Infinity, 1 << 3))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                Debug.Log("Did not Hit");
            }

            if (Input.GetKeyDown("g")){
                
                GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                bullet.transform.position = transform.position + facing;
                bullet.AddComponent<Rigidbody>();
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(facing * 500);
            }

            if (direction.magnitude >= 0.1f)
            {
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                               turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            }
            else camChanged = false;
        }
    }
}
