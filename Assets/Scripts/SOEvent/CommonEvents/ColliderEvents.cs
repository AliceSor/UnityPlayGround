using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SOEvent.CommonEvents
{
    public class ColliderEvents : MonoBehaviour
    {
        public UnityEvent triggerEnterEvent;
        public UnityEvent triggerExitEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (triggerEnterEvent != null)
                triggerEnterEvent.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (triggerExitEvent != null)
                triggerExitEvent.Invoke();
        }
    }
}
