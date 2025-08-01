using TMPro;
using UnityEngine;

public class RecipePage : MonoBehaviour
{
    [field: SerializeField] public Recipe Recipe { get; private set; }

    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public TextMeshProUGUI FirstIngredient { get; private set; }
    [field: SerializeField] public TextMeshProUGUI SecondIngredient { get; private set; }
    [field: SerializeField] public TextMeshProUGUI ThirdIngredient { get; private set; }
    [field: SerializeField] public TextMeshProUGUI FireLevel { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Rotations { get; private set; }

    private void Start()
    {
        Name.text = Recipe.Name;
        FirstIngredient.text += Recipe.Ingredients[0].ToString();
        SecondIngredient.text += Recipe.Ingredients[1].ToString();
        ThirdIngredient.text += Recipe.Ingredients[2].ToString();
        FireLevel.text += Recipe.RequiredFireLevel.ToString();
        Rotations.text += ProduceRotationsText();
    }

    private string ProduceRotationsText()
    {
        var rotationsText = "Stir ";
        rotationsText += Recipe.IsRightDirection ? "clockwise ": "counter-clockwise ";

        rotationsText += Recipe.AmountOfRotations + " times";

        return rotationsText;
    }
}
