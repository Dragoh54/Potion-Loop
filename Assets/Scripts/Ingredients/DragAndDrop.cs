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
        public float rotationLerpSpeed = 10f;
        
        protected virtual void Update()
        {
            if (_isDrag)
            {
                var previousPosition = transform.position;

                _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _newPos = _mousePos + _offset;

                transform.position = _newPos;

                //TODO: Remove if we don't need rotation
                //dragged rotation idk if we need this just added
                RotateTowardsMouse(previousPosition);
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

        private void RotateTowardsMouse(Vector3 previousPosition)
        {
            var direction = _newPos - previousPosition;

            if (direction.sqrMagnitude > 0.00001f) 
            {
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
                
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * rotationLerpSpeed);
        }
    }
}
