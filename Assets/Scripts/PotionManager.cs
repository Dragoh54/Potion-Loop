using System.Collections.Generic;
using System.Linq;
using Assets.Data.Enums;
using Cauldron;
using Ingredients;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public Recipe CurrentRecipe { get; private set; }
    
    [field: SerializeField]  public FireLevelCanvas FireLevelManager { get;  set; }
    [field: SerializeField]  public StickRotation StickManager { get; private set; }
    [field: SerializeField]  public IngredientManager IngredientManager { get; private set; }

    public bool IsCorrectPotion()
    {
        var isValidIngredients = CheckIngredients();
        var isValidFire = CheckFire();
        var isValidStirring = CheckStirring();
        
        return isValidIngredients && isValidFire && isValidStirring;
    }

    private bool CheckIngredients()
    {
        var usedIngredients = IngredientManager.GetUsedIngredients().Select(i => i.ingredientType).ToList();
        var requiredIngredients = CurrentRecipe.Ingredients.ToList();

        if (requiredIngredients.Count != usedIngredients.Count)
        {
            return false;
        }
        
        requiredIngredients.Sort();
        usedIngredients.Sort();

        return requiredIngredients.SequenceEqual(usedIngredients);
    }

    private bool CheckStirring()
    {
        return CurrentRecipe.IsRightDirection ? 
            StickManager.GetClockwiseCount() == CurrentRecipe.AmountOfRotations
            : StickManager.GetCounterClockwiseCount() == CurrentRecipe.AmountOfRotations;
    }

    private bool CheckFire() => FireLevelManager.FireLevel == CurrentRecipe.RequiredFireLevel;
}
