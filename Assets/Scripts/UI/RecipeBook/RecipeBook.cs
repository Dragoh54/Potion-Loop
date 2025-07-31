using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField] private GameObject[] pagesGameObjects;
    [SerializeField] private GameObject RightButton;
    [SerializeField] private GameObject LeftButton;

    private int _currentPageIndex = 0;

    public void MovePage(bool isRight)
    {
        if (isRight && (_currentPageIndex + 1) < pagesGameObjects.Length)
        {
            pagesGameObjects[_currentPageIndex++].SetActive(false);
            pagesGameObjects[_currentPageIndex].SetActive(true);

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
                LeftButton.SetActive(false);
            }
        }
    }
}
