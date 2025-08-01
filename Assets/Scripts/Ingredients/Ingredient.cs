using System;
using Assets.Data.Enums;
using Ingredients.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour, IIngredient
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;
    
        private SpriteRenderer _renderer;
        private Color _originalColor;

        [SerializeField]
        public IngredientType ingredientType; 
    
        [SerializeField]
        private float spriteTransparency = 0.4f;
        
        public static event Action<Ingredient> OnIngredientUsed;

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
            gameObject.transform.position = _startPosition;
            gameObject.transform.rotation = _startRotation;
            
            OnIngredientUsed?.Invoke(this);
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
