using System;
using UnityEngine;

namespace Ingredients
{
    public class WaterIngredient : MonoBehaviour
    {
        [SerializeField] private Sprite pickedUpWaterSprite;
        [SerializeField] private Sprite stayedWaterSprite;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnMouseDown()
        {
            _spriteRenderer.sprite = pickedUpWaterSprite;
        }

        private void OnMouseUp()
        {
            _spriteRenderer.sprite = stayedWaterSprite;
        }
    }
}