using System.Linq;
using Cauldron;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public Recipe CurrentRecipe { get; private set; }
    
    [field: SerializeField]  public FireLevelCanvas FireLevelManager { get;  set; }
    [field: SerializeField]  public StickRotation StickManager { get; private set; }
    [field: SerializeField]  public IngredientManager IngredientManager { get; private set; }
    
    [Header("For testing")]
    [field: SerializeField] private Recipe Recipe1 { get; set; }
    [field: SerializeField] private Recipe Recipe2 { get; set; }
    [field: SerializeField] private Recipe Recipe3 { get; set; }

    public bool IsCorrectPotion()
    {
        var isValidIngredients = CheckIngredients();
        var isValidFire = CheckFire();
        var isValidStirring = CheckStirring();
        
        return isValidIngredients && isValidFire && isValidStirring;
    }
    
    public void SetRecipe(Recipe recipe) => CurrentRecipe = recipe;

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

    //todo: discuss about more stirring
    private bool CheckStirring()
    {
        return CurrentRecipe.IsRightDirection ? 
            StickManager.GetClockwiseCount() >= CurrentRecipe.AmountOfRotations
            : StickManager.GetCounterClockwiseCount() >= CurrentRecipe.AmountOfRotations;
    }

    private bool CheckFire() => FireLevelManager.FireLevel == CurrentRecipe.RequiredFireLevel;
    
    //TODO: remove in future
    public void SetRecipe1()
    {
        CurrentRecipe = Recipe1;
        Debug.Log("Set Recipe 1");
    }
    
    public void SetRecipe2()
    {
        CurrentRecipe = Recipe2;
        Debug.Log("Set Recipe 2");
    }
    
    public void SetRecipe3()
    {
        CurrentRecipe = Recipe3;
        Debug.Log("Set Recipe 3");
    }

    public void IsCorrectPotionTest()
    {
        var isValidIngredients = CheckIngredients();
        var isValidFire = CheckFire();
        var isValidStirring = CheckStirring();
        
        Debug.Log($"Ingredients: {isValidIngredients}, Fire: {isValidFire}, Stirring: {isValidStirring}");
    }
}
