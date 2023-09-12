using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTest
{
    public class CameraZone : MonoBehaviour
    {
        public GameObject cam;
        
        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
                cam.SetActive(true);
        }

        void OnTriggerExit(Collider collisionInfo)
        {
            if (collisionInfo.gameObject.tag == "Player")
                cam.SetActive(false);
        }

    }
}
