using System.Collections.Generic;
using Assets.Data.Enums;
using Ingredients;
using UnityEngine;
using UnityEngine.Events;

public class IngredientManager : MonoBehaviour
{
    private List<Ingredient> _usedIngredients = new List<Ingredient>();

    public UnityEvent OnIngredientsChange;
    
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        Ingredient.OnIngredientUsed += HandleIngredientUsed;
    }

    private void OnDisable()
    {
        Ingredient.OnIngredientUsed -= HandleIngredientUsed;
    }
    
    private void HandleIngredientUsed(Ingredient ingredient)
    {
        _animator.Play("Splash");

        if (ingredient.ingredientType != IngredientType.Water)
        {
            _usedIngredients.Add(ingredient);
            Debug.Log($"Ingredient used: {ingredient.ingredientType.ToString()}");
        }
        else
        {
            Debug.Log("Used water");
            RemoveLastIngredient();
        }

        OnIngredientsChange?.Invoke();
    }
    
    public List<Ingredient> GetUsedIngredients()
    {
        return _usedIngredients;
    }

    public void ShowIngredients()
    {
        Debug.Log(string.Join(", ", _usedIngredients.ConvertAll(i => i.ingredientType.ToString())));
    }

    public void ResetUsedIngredients()
    {
        _usedIngredients.Clear();
    }

    public void RemoveLastIngredient()
    {
        _usedIngredients.RemoveAt(_usedIngredients.Count - 1);
    }
}
