using UnityEngine;

namespace Ingredients
{
    public class DragAndDrop : MonoBehaviour
    {
        private bool _isDrag;
        private Vector3 _offset;
        private Vector3 _mousePos;
        private Vector3 _newPos;

        private Quaternion _targetRotation;
        public float rotationLerpSpeed = 2f;
        
        protected virtual void Update()
        {
            if (_isDrag)
            {
                var previousPosition = transform.position;

                _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _newPos = _mousePos + _offset;

                transform.position = _newPos;
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
