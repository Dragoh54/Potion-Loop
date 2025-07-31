using Assets.Data.Enums;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    [field: SerializeField] public IngredientType[] Ingredients { get; private set; }
    [field: SerializeField] public FireLevel RequiredFireLevel { get; private set; }

    [field: SerializeField] public int AmountOfRotations { get; private set; }
    [field: SerializeField] public bool IsRightDirection { get; private set; }
}
