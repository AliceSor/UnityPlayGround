using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOEvent
{
    [CreateAssetMenu()]
    public class SOEventTObj : ScriptableObject
    {
        private List<SOEventListenerTObj> listeners = new List<SOEventListenerTObj>();

        public void Invoke(object obj)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventInvoked(obj);
            }
        }

        public void AddListener(SOEventListenerTObj listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(SOEventListenerTObj listener)
        {
            listeners.Remove(listener);
        }
    }
}

