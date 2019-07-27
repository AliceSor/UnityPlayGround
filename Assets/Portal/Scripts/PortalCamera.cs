using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    [RequireComponent(typeof(Portal))]
    [RequireComponent(typeof(PortalTeleporter))]
    public class PortalCamera : MonoBehaviour
    {
        public MeshRenderer renderPlane;
        public PortalHelper helper;

        private Camera cam;
        private Transform playerCamera;
        private Transform otherPortal;

        #region Unity Callback

        private void Start()
        {
            if (renderPlane == null || helper == null)
            {
                Debug.LogError("Missing variables");
                Destroy(gameObject);
            }
            //cam.enabled = false;
            renderPlane.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            //...
        }

        private void OnDisable()
        {
            FreeResources();
            //hide render plane
            //disable cam
           // cam.enabled = false;
            renderPlane.gameObject.SetActive(false);
        }

        void Update()
        {
            MoveCamera();
        }
        #endregion

        private void MoveCamera()
        {
            //set camera position
            Vector3 playerOffsetFromPortal = playerCamera.position - transform.position;
            cam.transform.position = otherPortal.position + playerOffsetFromPortal;

            //set camera rotation
            cam.transform.rotation = playerCamera.rotation;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(transform.rotation, otherPortal.rotation);
            angularDifferenceBetweenPortalRotations -= 180;

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
           // Debug.Log("player forward " + player.forward);
            cam.transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }

        public void SetUp(Portal secondPortal)
        {
            cam = secondPortal.cam;
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

            //set player
            playerCamera = helper.cameraPlayer;
            //set other portal
            otherPortal = secondPortal.transform;
            //show render plane
            renderPlane.gameObject.SetActive(true);
            //enable cam
            cam.enabled = true;
            cam.gameObject.SetActive(true);
        }

        public void FreeResources()
        {
            //return render texture and material
            //if (cam.targetTexture != null)
            //    helper.ReturnRenderTexture(cam.targetTexture);
            //if (renderPlane.sharedMaterial != null)
            //    helper.ReturnMaterial(renderPlane.sharedMaterial);
            //renderPlane.sharedMaterial = null;
        }
    }
}
