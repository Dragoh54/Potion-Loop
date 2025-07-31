using UnityEngine;

namespace Ingredients
{
    public class DragAndDrop : MonoBehaviour
    {
        private bool _isDrag;
        private Vector3 _offset;
        private Vector3 _mousePos;

        private void Update()
        {
            if (_isDrag)
            {
                _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = _mousePos + _offset;
            }
        }

        protected virtual void OnMouseDown()
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _offset = transform.position - _mousePos;
            
            _isDrag = true;
        }

        protected virtual void OnMouseUp()
        {
            _isDrag = false;
        }
    }
}
