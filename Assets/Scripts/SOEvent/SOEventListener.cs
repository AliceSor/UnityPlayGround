using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SOEvent
{
    public class SOEventListener : MonoBehaviour
    {
        public SOEvent Event;
        public UnityEvent Response;

        public void OnEventInvoked()
        {
            Response.Invoke();
        }

        void OnEnable()
        {
            Event.AddListener(this);
        }

        void OnDisable()
        {
            Event.RemoveListener(this);
        }
    }
}

