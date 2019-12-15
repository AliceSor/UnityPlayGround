using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SOEvent.CommonEvents
{
    public class CommonKeyboardEvents : MonoBehaviour
    {
        [SerializeField] UnityEvent enterPressed;
        [SerializeField] UnityEvent escapePressed;
        [SerializeField] UnityEvent upPressed;
        [SerializeField] UnityEvent downPressed;
        [SerializeField] UnityEvent leftPressed;
        [SerializeField] UnityEvent rightPressed;
        [SerializeField] UnityEvent deletePressed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
            {
                enterPressed.Invoke();
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                escapePressed.Invoke();
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                upPressed.Invoke();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                downPressed.Invoke();
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                leftPressed.Invoke();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rightPressed.Invoke();
            }
        }
    }
}
