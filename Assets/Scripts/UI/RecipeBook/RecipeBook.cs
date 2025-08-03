using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField] private GameObject[] pagesGameObjects;
    [SerializeField] private GameObject RightButton;
    [SerializeField] private GameObject TitleCardButton;
    [SerializeField] private GameObject LeftButton;

    [field: SerializeField] public List<RecipePage> RecipePages { get; private set; } = new List<RecipePage>();
    [field: SerializeField] public HashSet<Recipe> PresentRecipes { get; private set; } = new HashSet<Recipe>();

    private int _currentPageIndex = 0;

    private void Awake()
    {
        foreach (var page in pagesGameObjects)
        {
            var recipePage = page.GetComponent<RecipePage>();

            if(recipePage is null)
            {
                continue;
            }

            RecipePages.Add(recipePage);
            PresentRecipes.AddRange(recipePage.RecipeVersions);
        }
    }

    public void MovePage(bool isRight)
    {
        if (isRight && (_currentPageIndex + 1) < pagesGameObjects.Length)
        {
            pagesGameObjects[_currentPageIndex++].SetActive(false);
            pagesGameObjects[_currentPageIndex].SetActive(true);

            RightButton.SetActive(true);
            TitleCardButton.SetActive(false);
            LeftButton.SetActive(true);

            if (_currentPageIndex == pagesGameObjects.Length - 1)
            {
                RightButton.SetActive(false);
            }
        }
        else if(!isRight && _currentPageIndex - 1 >= 0)
        {
            pagesGameObjects[_currentPageIndex--].SetActive(false);
            pagesGameObjects[_currentPageIndex].SetActive(true);

            RightButton.SetActive(true);

            if (_currentPageIndex == 0)
            {
                TitleCardButton.SetActive(true);
                LeftButton.SetActive(false);
                RightButton.SetActive(false);
            }
        }
    }
}
