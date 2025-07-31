using System;
using UnityEngine;

namespace Ingridients
{
    public class DragAndDrop : MonoBehaviour
    {
        private bool _isDrag;
        private Vector3 _offset;
        private Vector3 _mousePos;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_isDrag)
            {
                return;
            }
            
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = _mousePos + _offset;
        }

        private void OnMouseDown()
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _offset = transform.position - _mousePos;
            
            _isDrag = true;
            
            _rb.bodyType = RigidbodyType2D.Static;
        }

        private void OnMouseUp()
        {
            _isDrag = false;
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
