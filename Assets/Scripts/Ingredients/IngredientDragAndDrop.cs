using Ingredients.Interfaces;
using UnityEngine;

namespace Ingredients
{
    public class IngredientDragAndDrop : DragAndDrop
    {
        private IIngredient _ingredient;
        
        private bool _isOverCauldron;
        public string cauldronTag = "Cauldron";
        
        private void Start()
        {
            _ingredient = GetComponent<Ingredient>();
        }

        protected override void OnMouseUp()
        {
            base.OnMouseUp(); 

            if (_isOverCauldron)
                _ingredient.Use();
            else
                _ingredient.Return();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag(cauldronTag))
            {
                _isOverCauldron = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(cauldronTag))
            {
                _isOverCauldron = false;
            }
        }
    }
}