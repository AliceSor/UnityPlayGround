using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    public class RegisterToPortal : MonoBehaviour
    {
        public PortalHelper helper;
        public enum PlayerPart {PLAYER, PLAYER_CAMERA}
        public PlayerPart playerPart;

        private void OnEnable()
        {
            if (playerPart == PlayerPart.PLAYER)
                helper.player = transform;
            else
                helper.cameraPlayer = transform;
        }

        private void OnDisable()
        {
            //I don't sure i need to return it to null ...
        }

    }
}
