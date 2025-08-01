using System;
using UnityEngine;

namespace Cauldron
{
    public class StickRotation : MonoBehaviour
    {
        private float _rotationDegree = 0f;
        private const float FullRotationDegree = 360f;
        
        private int _clockwise = 0;
        private int _counterClockwise = 0;
        
        public TMPro.TMP_Text clockwiseText;
        public TMPro.TMP_Text counterClockwiseText;
        
        private float _prevAngel;

        private Vector3 _centerPos;
        
        public Transform cauldronCenter;
        public float rotationSpeedMultiplier = 1f;

        private void Start()
        {
            _centerPos = Camera.main.WorldToScreenPoint(transform.position);
            _prevAngel = GetAngle();
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
            
            _rotationDegree += deltaAngle;
            
            if (cauldronCenter != null)
            {
                var visualSpeed = deltaAngle * rotationSpeedMultiplier;
                transform.RotateAround(cauldronCenter.position, Vector3.up, visualSpeed);
            }
            
            if (_rotationDegree >= FullRotationDegree)
            {
                //_clockwise--;
                _counterClockwise++;
                
                _rotationDegree -= FullRotationDegree;
            }
            else if (_rotationDegree <= -FullRotationDegree)
            {
                _clockwise++;
                //_counterClockwise--;
                
                _rotationDegree += FullRotationDegree;
            }
            
            _prevAngel = currentAngle;
        }

        private float GetAngle()
        {
            var direction = Input.mousePosition - _centerPos;
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }
}
