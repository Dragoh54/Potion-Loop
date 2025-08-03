using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public UIManager UIManager { get; private set; }
    [field: SerializeField] public TextList Text { get; private set; }
    [field: SerializeField] public IngredientManager IngredientManager { get; private set; }
    [field: SerializeField] public PotionManager PotionManager { get; private set; }
    [field: SerializeField] public RecipeBook RecipeBook { get; private set; }
    [field: SerializeField] public List<Recipe> PresentRecipes { get; private set; }
    //[field: SerializeField] public List<RewardIngredient> RewardIngredients { get; private set; }
    [field: SerializeField] public PotionSpawner PotionSpawner { get; private set; }

    [SerializeField] private AudioClip[] _customerEntranceSounds;  

    private int _currentCustomer = -1;
    private int _currentEra = -1;

    private void Awake()
    {
        PotionManager.OnPotionCorrect.AddListener(HandlePotionSuccess);
        UIManager.OnEraChanged.AddListener(ChangeCustomerLogical);
        UIManager.OnDialogEnded.AddListener(HandleCustomerChange);
        PotionSpawner.OnPotionConsumed.AddListener(HandleOrderEnd);
    }

    private void Start()
    {
        Text = GetComponent<FileReader>().GetDialogText();
        var recipes = RecipeBook.PresentRecipes;
        var potionNames = Text.dialogs.Select(customer => customer.potion).ToList();

        foreach (var potion in potionNames)
        {
            var correspondingRecipe = recipes.FirstOrDefault(recipe => recipe.Label == potion);

            PresentRecipes.Add(correspondingRecipe);
        }

        ChangeEraLogical();
    }

    private void HandleOrderEnd()
    {
        var dialogs = Text.dialogs[_currentCustomer].array;
        UIManager.EnterShowLastDialog(dialogs[dialogs.Count - 1]);
    }

    private void HandleCustomerChange()
    {
        if ((_currentCustomer + 1) != 0 && (_currentCustomer + 1) % 3 == 0)
        {
            ChangeEraLogical();

            return;
        }
        
        //RewardIngredients[_currentCustomer % 3].Award();
        ChangeCustomerLogical();
    }

    private void HandlePotionSuccess()
    {
        PotionSpawner.SpawnPotion(_currentCustomer);
    }

    private void ChangeCustomerLogical()
    {
        if (_currentEra == Text.storyCards.Count - 1)
        {
            UIManager.ShowGameEndScreen();
            StartCoroutine("RestartGame");

            return;
        }

        foreach (var sound in _customerEntranceSounds)
        {
            AudioManager.Instance.PlaySFX(sound);
        }

        _currentCustomer++;
        var dialogs = Text.dialogs[_currentCustomer].array;
        UIManager.ChangeCustomer(_currentCustomer, dialogs.Take(dialogs.Count - 1).ToList());

        PotionManager.SetRecipe(PresentRecipes[_currentCustomer]);
    }

    private void ChangeEraLogical()
    {
        _currentEra++;

        if (_currentEra == Text.storyCards.Count - 1)
        {
            UIManager.ChangeEra(_currentEra, Text.storyCards[_currentEra]);

            return;
        }

        //RewardIngredients.ForEach(ingredient => ingredient.Hide());
        RecipeBook.RecipePages.ForEach(recipePage => recipePage.ChangeRecipe());

        UIManager.ChangeEra(_currentEra, Text.storyCards[_currentEra]);
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(7.0f);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
