using Ingredients.Interfaces;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour, IIngredient
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;
    
        private SpriteRenderer _renderer;
        private Color _originalColor;
    
        [SerializeField]
        private float spriteTransparency = 0.4f;
    
        void Awake()
        {
            _startPosition = transform.position;
            _startRotation = transform.rotation;
            
            _renderer = GetComponent<SpriteRenderer>();
            _originalColor = _renderer.color;
        }

        public void Return()
        {
            Debug.Log("Return");
            gameObject.transform.position = _startPosition;
            gameObject.transform.rotation = _startRotation;
        }

        public void Use()
        {
            Debug.Log("Used");
            gameObject.transform.position = _startPosition;
            gameObject.transform.rotation = _startRotation;
        }

        private void OnMouseEnter()
        {
            var color = _renderer.material.color;
            color.a = spriteTransparency;
            _renderer.material.color = color;
        }

        private void OnMouseExit()
        {
            _renderer.material.color = _originalColor;
        }
    }
}
