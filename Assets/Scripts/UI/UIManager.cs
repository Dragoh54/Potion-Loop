using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [field: SerializeField] public DialogCanvas DialogCanvas { get; private set; }
    [field: SerializeField] public SpriteVisualizer CusomerVisualizer { get; private set; }
    [field: SerializeField] public SpriteVisualizer WindowVisualizer { get; private set; }
    [field: SerializeField] public StoryCardCanvas StoryCard { get; private set; }
    [field: SerializeField] public GameObject GameEndScreen { get; private set; }

    public UnityEvent OnEraChanged;
    public UnityEvent OnDialogEnded;

    public void ChangeEra(int currentEra, StoryText storyText)
    {
        StartCoroutine("DisplayStoryCard", storyText);

        WindowVisualizer.ChangeSprite(currentEra);
    }

    public IEnumerator DisplayStoryCard(StoryText storyText)
    {
        StoryCard.gameObject.SetActive(true);
        StoryCard.DisplayText(storyText.text);

        yield return new WaitForSeconds(storyText.time);

        StoryCard.gameObject.SetActive(false);
        OnEraChanged?.Invoke();
    }

    public void ChangeCustomer(int currentCustomer, List<GameText> dialogs)
    {
        StartCoroutine("ChangeSpriteAfterDelay", new Customer { CurrentCustomer = currentCustomer, Dialogs = dialogs});
    }

    public void EnterShowLastDialog(GameText lastLine)
    {
        StartCoroutine("ShowLastDialog", lastLine);
    }

    public void ShowTask(string task)
    {
        DialogCanvas.ShowDialog(task);
    }

    public void ShowGameEndScreen()
    {
        GameEndScreen.SetActive(true);
    }

    private IEnumerator ChangeSpriteAfterDelay(Customer customer)
    {
        CusomerVisualizer.HideSprite();

        yield return new WaitForSeconds(1.0f);

        CusomerVisualizer.ChangeSprite(customer.CurrentCustomer);

        for (int i = 0; i < customer.Dialogs.Count; i++)
        {
            DialogCanvas.ShowDialog(customer.Dialogs[i].text);

            yield return new WaitForSeconds(3.0f);

            if (i != 0 && i % 2 == 1)
            {
                DialogCanvas.HideAll();

                yield return new WaitForSeconds(1.0f);
            }
        }
    }

    private IEnumerator ShowLastDialog(GameText lastLine)
    {
        DialogCanvas.HideAll();
        DialogCanvas.ShowDialog(lastLine.text);

        yield return new WaitForSeconds(3.0f);

        DialogCanvas.HideAll();
        OnDialogEnded?.Invoke();
    }

    private struct Customer
    {
        public int CurrentCustomer;
        public List<GameText> Dialogs;
    };
}
