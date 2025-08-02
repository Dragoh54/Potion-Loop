using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public DialogCanvas DialogCanvas { get; private set; }
    [field: SerializeField] public TextList DialogList { get; private set; }
    [field: SerializeField] public PotionManager IngredientsManager { get; private set; }
    [field: SerializeField] public RecipeBook RecipeBook { get; private set; }
    [field: SerializeField] public List<Recipe> PresentRecipes { get; private set; }

    private int _currentCustomer = -1;

    private void Start()
    {
        DialogList = GetComponent<FileReader>().GetDialogText();
        var recipes = RecipeBook.PresentRecipes;
        var potionNames = DialogList.allStory.Select(customer => customer.potion).ToList();

        foreach (var potion in potionNames)
        {
            var correspondingRecipe = recipes.FirstOrDefault(recipe => recipe.Name == potion);

            PresentRecipes.Add(correspondingRecipe);
        }

        ChangeCustomer();
    }

    private void ChangeCustomer()
    {
        _currentCustomer++;
        StartCoroutine("ShowDialog");
    }

    private IEnumerator ShowDialog()
    {
        var customerDialogs = DialogList.allStory[_currentCustomer].array;
        for (int i = 0; i < customerDialogs.Count; i++)
        {
            DialogCanvas.ShowDialog(customerDialogs[i].text);

            yield return new WaitForSeconds(3.0f);

            if (i != 0 && i % 2 == 1)
            {
                DialogCanvas.HideAll();

                yield return new WaitForSeconds(1.0f);
            }
        }

        DialogCanvas.HideAll();
    }
}
