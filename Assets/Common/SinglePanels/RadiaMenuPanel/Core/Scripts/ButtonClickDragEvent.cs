﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
namespace Menu_Generic
{
    [RequireComponent(typeof(Button))]
    public class ButtonClickDragEvent : MonoBehaviour, IPointerDownHandler
    {
        Vector3 m_PressDownPos;
        Vector3 m_CurrentMousePos;

        bool m_Pressed = false;

        [System.Serializable]
        public class FloatEvent : UnityEvent<float> { }
        public FloatEvent OnDragUpdate;

        void Update()
        {
            if (m_Pressed && Input.GetMouseButtonUp(0))
            {
                Unclick();
            }
            else if (m_Pressed)
            {
                m_CurrentMousePos = Input.mousePosition;
                float distance = m_PressDownPos.x - m_CurrentMousePos.x;
                distance /= Screen.width;

                print("Drag value: " + distance);
                OnDragUpdate.Invoke(distance);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(this.gameObject.name + " Was click drag started.");
            m_PressDownPos = Input.mousePosition;
        }


        void Unclick()
        {
            m_Pressed = false;
        }
    }

}