using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    public class RegisterToPortal : MonoBehaviour
    {
        public PortalHelper helper;

        private void OnEnable()
        {
            helper.player = transform;
        }

        private void OnDisable()
        {
            //I don't sure i need to return it to null ...
        }

    }
}
