using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOEvent
{
    [CreateAssetMenu()]
    public class SOEvent : ScriptableObject
    {
        private List<SOEventListener> listeners = new List<SOEventListener>();

        public void Invoke()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventInvoked();
            }
        }

        public void AddListener(SOEventListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(SOEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}

