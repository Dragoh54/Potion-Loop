using TMPro;
using UnityEngine;

public class RecipePage : MonoBehaviour
{
    [field: SerializeField] public Recipe Recipe { get; private set; }

    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public TextMeshProUGUI[] Ingredients { get; private set; }
    [field: SerializeField] public TextMeshProUGUI FireLevel { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Rotations { get; private set; }

    private void Start()
    {
        Name.text = Recipe.Name;

        var currentIngredient = 0;
        foreach (var item in Recipe.Ingredients)
        {
            SetText(Ingredients[currentIngredient], item.ToString());
            
            currentIngredient++;
        }

        SetText(FireLevel, ProduceFireLevelText());
        SetText(Rotations, ProduceRotationsText());
    }

    private void SetText(TextMeshProUGUI textElement, string text)
    {
        textElement.text = "• " + text;
    }

    private string ProduceFireLevelText() => Recipe.RequiredFireLevel.ToString() + "fire level";

    private string ProduceRotationsText()
    {
        var rotationsText = "Stir ";
        rotationsText += Recipe.IsRightDirection ? "clockwise ": "counter-clockwise ";

        rotationsText += Recipe.AmountOfRotations + " times";

        return rotationsText;
    }
}
