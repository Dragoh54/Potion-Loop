using System.Text;
using TMPro;
using UnityEngine;

public class RecipePage : MonoBehaviour
{
    [field: SerializeField] public Recipe CurrentRecipe { get; private set; }
    [field: SerializeField] public Recipe[] RecipeVersions { get; private set; }

    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public TextMeshProUGUI[] Ingredients { get; private set; }
    [field: SerializeField] public TextMeshProUGUI FireLevel { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Rotations { get; private set; }

    private int _currentRecipe = -1;

    private void Start()
    {
        CurrentRecipe = RecipeVersions[_currentRecipe];
    }

    public void ChangeRecipe()
    {
        _currentRecipe++;
        CurrentRecipe = RecipeVersions[_currentRecipe];

        DisplayRecipe();
    }

    private void DisplayRecipe()
    {
        Name.text = CurrentRecipe.Name;

        var currentIngredient = 0;
        foreach (var item in CurrentRecipe.Ingredients)
        {
            SetText(Ingredients[currentIngredient], ProduceIngredientText(item.ToString()));

            currentIngredient++;
        }

        SetText(FireLevel, ProduceFireLevelText());
        SetText(Rotations, ProduceRotationsText());
    }

    private void SetText(TextMeshProUGUI textElement, string text)
    {
        textElement.text = "• " + text;
    }

    private string ProduceIngredientText(string text)
    {
        var output = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] >= 'A' && text[i] <= 'Z')
            {
                output.Append(' ');
            }

            output.Append(text[i]);
        }

        return output.ToString();
    }

    private string ProduceFireLevelText() => CurrentRecipe.RequiredFireLevel.ToString() + " fire level";

    private string ProduceRotationsText()
    {
        var rotationsText = "Stir";
        rotationsText += CurrentRecipe.IsRightDirection ? " clockwise ": " counter-clockwise ";

        rotationsText += CurrentRecipe.AmountOfRotations + " times";

        return rotationsText;
    }
}
