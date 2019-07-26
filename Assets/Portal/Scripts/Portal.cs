using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    [RequireComponent(typeof(PortalCamera))]
    [RequireComponent(typeof(PortalTeleporter))]
    public class Portal : MonoBehaviour
    {
        public Portal secondPortal;
        public Transform teleportPlane;
        public Camera cam;

        private PortalCamera _camera;
        private PortalTeleporter _teleporter;
        private bool _isActive = false;

        private void Start()
        {
            if (secondPortal == null)
            {
                Debug.LogError("Missing second teleport");
                Destroy(gameObject);
            }
            _camera = GetComponent<PortalCamera>();
            _teleporter = GetComponent<PortalTeleporter>();
            Sleep();
        }

        //Wake the f*** Up Samurai, we have a city to burn (c)
        public void WakeUp() 
        {
            //wake up 
            _camera.enabled = true;
            cam.gameObject.SetActive(true);
            _teleporter.enabled = true;

            //Set up
            _camera.SetUp(secondPortal);
            _teleporter.SetUp(secondPortal);
            teleportPlane.gameObject.SetActive(true);
            Debug.Log("Portal wake up");
        }

        public void Sleep()
        {
            _camera.enabled = false;
            cam.gameObject.SetActive(false);
            _teleporter.enabled = false;
            teleportPlane.gameObject.SetActive(false);
            Debug.Log("Portal sleep");
        }
    }
}
