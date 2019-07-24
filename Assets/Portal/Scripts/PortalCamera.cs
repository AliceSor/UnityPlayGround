using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    [RequireComponent(typeof(Portal))]
    [RequireComponent(typeof(PortalTeleporter))]
    public class PortalCamera : MonoBehaviour
    {
        public Camera cam;
        public MeshRenderer renderPlane;
        public PortalHelper helper;

        private Transform playerCamera;
        private Transform otherPortal;

        #region Unity Callback

        private void Start()
        {
            if (cam == null || renderPlane == null || helper == null)
            {
                Debug.LogError("Missing variables");
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            //..
        }

        private void OnDisable()
        {
            FreeResources();
            //hide render plane
            //disable cam
        }

        // Update is called once per frame
        void Update()
        {
            MoveCamera();
            
        }
        #endregion

        private void MoveCamera()
        {
            //set camera position
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            cam.transform.position = transform.position + playerOffsetFromPortal;

            //set camera rotation
            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(transform.rotation, otherPortal.rotation);

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
            cam.transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }

        public void SetUp(Portal secondPortal)
        {
            //set render texure
            if (cam.targetTexture != null)
            {
                cam.targetTexture.Release();
            }
            cam.targetTexture = helper.GetRenderTexture();

            //set material
            Material mat = helper.GetMaterial();
            mat.mainTexture = cam.targetTexture;
            renderPlane.sharedMaterial = mat;

            //set player cam
            playerCamera = helper.player;
            //set other portal
            otherPortal = secondPortal.transform;
            //show render plane
            //enable cam

        }

        public void FreeResources()
        {
            //return render texture and material
        }
    }
}
