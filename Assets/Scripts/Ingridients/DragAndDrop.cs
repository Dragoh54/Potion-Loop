using System;
using UnityEngine;

namespace Ingridients
{
    public class DragAndDrop : MonoBehaviour
    {
        private bool _isDrag;
        private Vector3 _offset;
        private Vector3 _mousePos;
        
        private IIngridient _ingridient;
        
        

        private void Start()
        {
            _ingridient = GetComponent<Ingridient>();
        }

        private void Update()
        {
            if (_isDrag)
            {
                _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = _mousePos + _offset;
            }
        }

        private void OnMouseDown()
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _offset = transform.position - _mousePos;
            
            _isDrag = true;
        }

        private void OnMouseUp()
        {
            _isDrag = false;
            _ingridient.Return();
        }
    }
}
