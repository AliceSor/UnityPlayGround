using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    ///<summary>
    ///To register the portal couple portal helper must differentiate them, 
    ///so in each couple must be A and B portal
    ///</summary>
    public enum PortalType { A, B }

    [RequireComponent(typeof(PortalCamera))]
    [RequireComponent(typeof(PortalTeleporter))]
    public class Portal : MonoBehaviour
    {
        public string id;
        public PortalType type;

        [Space(10)]
        public PortalHelper helper;
        public Transform teleportPlane;
        public Camera cam;

        private Portal secondPortal;
        private PortalCamera _camera;
        private PortalTeleporter _teleporter;
        private bool _isActive = false;

        private void Awake()
        {
            //register to portal helper
            if (!helper.RegisterPortal(id, this))
                Destroy(gameObject);
        }

        private void Start()
        {
            //get second portal from helper
            secondPortal = helper.GetSecondPortal(this);

            if (secondPortal == null)
            {
                Debug.LogError("Missing second teleport");
                Destroy(gameObject);
            }
            _camera = GetComponent<PortalCamera>();
            _teleporter = GetComponent<PortalTeleporter>();
            //Sleep();
            WakeUp();
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
