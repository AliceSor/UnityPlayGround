using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    [RequireComponent(typeof(PortalCamera))]
    [RequireComponent(typeof(Portal))]
    public class PortalTeleporter : MonoBehaviour
    {
        public float cooldown = 0.5f;

        private Transform _player;
        private Transform _reciever; //front plane of second portal
        private Transform _sender; //our front plane that teleport player
        private bool playerIsOverlapping = false;
        [SerializeField]private bool _skipNextTrigger = false; //when going from portal from another side it don't teleport
        private Coroutine _skipCooldownCorotine;
        private Portal _secondPortal;

        void Update()
        {
            //if (playerIsOverlapping)
            //{
            //    Vector3 portalToPlayer = player.position - transform.position;
            //    float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //    // If this is true: The player has moved across the portal
            //    if (dotProduct < 0f)
            //    {
            //        // Teleport him!
            //        float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
            //        rotationDiff += 180;
            //        player.Rotate(Vector3.up, rotationDiff);

            //        Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            //        player.position = reciever.position + positionOffset;

            //        playerIsOverlapping = false;
            //    }
            //}
        }

        private void OnDisable()
        {
           // _skipNextTrigger = false;
        }

        public void SetUp(Portal secondPortal)
        {
            _player = GetComponent<PortalCamera>().helper.player;
            _reciever = secondPortal.teleportPlane;
            _sender = GetComponent<Portal>().teleportPlane;
            _secondPortal = secondPortal;
        }

        public void FrontPlaneTriggered()
        {
            Debug.Log("FrontPlaneTriggered");
            if (!_skipNextTrigger)
                Teleport();
            else
            {
                if (_skipCooldownCorotine != null)
                    StopCoroutine(_skipCooldownCorotine);
                _skipNextTrigger = false;
            }
        }

        public void BackPlaneTriggered()
        {
            Debug.Log("BackPlaneTriggered");

            _skipNextTrigger = true;
            if (_skipCooldownCorotine != null)
            {
                StopCoroutine(_skipCooldownCorotine);
                //start new
                _skipCooldownCorotine = StartCoroutine(Cooldown());
            }
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(cooldown);
            _skipNextTrigger = false;
        }

        private void Teleport()
        {
            Debug.Log("Teleport");

            // Teleport him!
            Vector3 portalToPlayer = _player.position - _sender.transform.position;
            float rotationDiff = -Quaternion.Angle(transform.rotation, _reciever.rotation);
            rotationDiff += 180;
            _player.Rotate(Vector3.up, rotationDiff);

            Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
            _player.position = _reciever.position + positionOffset;
            _secondPortal.GetComponent<PortalTeleporter>().BackPlaneTriggered();


            //        playerIsOverlapping = false;
        }

        //void OnTriggerEnter(Collider other)
        //{
        //    if (other.tag == "Player")
        //    {
        //        playerIsOverlapping = true;
        //    }
        //}

        //void OnTriggerExit(Collider other)
        //{
        //    if (other.tag == "Player")
        //    {
        //        playerIsOverlapping = false;
        //    }
        //}
    }
}