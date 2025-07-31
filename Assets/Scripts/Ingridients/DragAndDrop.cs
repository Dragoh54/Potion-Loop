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
        
        private IIngridient _ingridient;
        
        [SerializeField]
        private string layerName = "cauldron";

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
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
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(layerName))
            {
                Debug.Log(collision.gameObject.name);
                _ingridient.Use();
                _ingridient.Refresh();
            }
        }
    }
}
