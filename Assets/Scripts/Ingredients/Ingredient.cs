using Ingredients.Interfaces;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour, IIngredient
    {
        private Vector3 _startPosition;
    
        private SpriteRenderer _renderer;
        private Color _originalColor;
    
        [SerializeField]
        private float spriteTransparency = 0.4f;
    
        void Awake()
        {
            _startPosition = transform.position;
            _renderer = GetComponent<SpriteRenderer>();
            _originalColor = _renderer.color;
        }

        public void Return()
        {
            Debug.Log("Return");
            gameObject.transform.position = _startPosition;
        }

        public void Use()
        {
            Debug.Log("Used");
            gameObject.transform.position = _startPosition;
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
