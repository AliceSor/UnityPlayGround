using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SOEvent
{
    public class SOEventListenerTObj : MonoBehaviour
    {
        public SOEventTObj Event;
        public UnityEventTObj Response;

        public void OnEventInvoked(object obj)
        {
            Response.Invoke(obj);
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

