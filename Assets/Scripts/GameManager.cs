using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public UIManager UIManager { get; private set; }
    [field: SerializeField] public TextList Text { get; private set; }
    [field: SerializeField] public IngredientManager IngredientManager { get; private set; }
    [field: SerializeField] public RecipeBook RecipeBook { get; private set; }
    [field: SerializeField] public List<Recipe> PresentRecipes { get; private set; }

    private int _currentCustomer = -1;
    private int _currentEra = -1;

    private void Start()
    {
        UIManager.OnEraChanged.AddListener(ChangeCustomerLogical);

        Text = GetComponent<FileReader>().GetDialogText();
        var recipes = RecipeBook.PresentRecipes;
        var potionNames = Text.dialogs.Select(customer => customer.potion).ToList();

        foreach (var potion in potionNames)
        {
            var correspondingRecipe = recipes.FirstOrDefault(recipe => recipe.Name == potion);

            PresentRecipes.Add(correspondingRecipe);
        }

        ChangeEraLogical();
    }

    public void HandlePotionSuccess()
    {
        if ((_currentCustomer + 1) != 0 && (_currentCustomer + 1) % 3 == 0)
        {
            ChangeEraLogical();

            return;
        }

        ChangeCustomerLogical();
    }

    private void ChangeCustomerLogical()
    {
        _currentCustomer++;
        UIManager.ChangeCustomer(_currentCustomer, Text.dialogs[_currentCustomer].array);
    }

    private void ChangeEraLogical()
    {
        _currentEra++;
        UIManager.ChangeEra(_currentEra, Text.storyCards[_currentEra].text);
    }
}
