using UnityEngine;
using UnityEngine.Events;

namespace Cauldron
{
    public class StickRotation : MonoBehaviour
    {
        private float _angle = 0f;
        private const float FullRotationDegree = 360f;
        private Vector3 _centerPos;
        private float _prevAngel;

        private int _clockwise = 0;
        private int _counterClockwise = 0;
        
        public TMPro.TMP_Text clockwiseText;
        public TMPro.TMP_Text counterClockwiseText;
        
        public Transform cauldronCenter;
        public float rotationSpeedMultiplier = 1f;
        private float _radius = 0f;
        
        public float xOffset = 1.4f;
        public float yOffset = 0.4f;

        public UnityEvent OnCounterChange;

        private void Start()
        {
            _centerPos = Camera.main.WorldToScreenPoint(transform.position);
            _prevAngel = GetAngle();
            
            var dir = transform.position - cauldronCenter.position;
            _radius = dir.magnitude;
        }

        private void Update()
        {
            clockwiseText.text = $"Clockwise: {_clockwise}";
            counterClockwiseText.text = $"Counter Clockwise: {_counterClockwise}";
        }

        private void OnMouseDrag()
        {
            var currentAngle = GetAngle();
            var deltaAngle =  Mathf.DeltaAngle(_prevAngel, currentAngle);
            
            _angle += deltaAngle * rotationSpeedMultiplier;
            
            var angleRad = _angle * Mathf.Deg2Rad;
            var x = Mathf.Cos(angleRad) * _radius * xOffset;
            var y = Mathf.Sin(angleRad) * _radius * yOffset;
            
            var newPosition = new Vector3(x, y, 0) + cauldronCenter.position;
            transform.position = newPosition;
            
            //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 10f);
            
            if (_angle >= FullRotationDegree)
            {
                _counterClockwise++;
                _angle -= FullRotationDegree;

                OnCounterChange?.Invoke();
            }
            else if (_angle <= -FullRotationDegree)
            {
                _clockwise++;
                _angle += FullRotationDegree;

                OnCounterChange?.Invoke();
            }
            
            _prevAngel = currentAngle;
        }

        private float GetAngle()
        {
            var direction = Input.mousePosition - _centerPos;
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        
        public int GetClockwiseCount() => _clockwise;
        public int GetCounterClockwiseCount() => _counterClockwise;

        public void ClearCounter()
        {
            _counterClockwise = 0;
            _clockwise = 0;
        }
    }
}
