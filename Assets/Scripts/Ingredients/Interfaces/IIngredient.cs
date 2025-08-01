using Assets.Data.Enums;

namespace Ingredients.Interfaces
{
    public interface IIngredient
    {
        public IngredientType IngredientType { get; }
        void Return();
        void Use();
    }
}
