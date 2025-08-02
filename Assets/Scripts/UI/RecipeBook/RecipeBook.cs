using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField] private GameObject[] pagesGameObjects;
    [SerializeField] private GameObject RightButton;
    [SerializeField] private GameObject TitleCardButton;
    [SerializeField] private GameObject LeftButton;

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

            PresentRecipes.Add(recipePage.Recipe);
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
