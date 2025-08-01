using TMPro;
using UnityEngine;

public class DialogCanvas : MonoBehaviour
{
    [field: SerializeField] public GameObject FirstDialogBubble {  get; private set; }
    [field: SerializeField] public GameObject SecondDialogBubble {  get; private set; }

    [field: SerializeField] public TextMeshProUGUI FirstDialogText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI SecondDialogText { get; private set; }

    public void ShowDialog(string text)
    {
        if(FirstDialogBubble.activeSelf)
        {
            SecondDialogBubble.SetActive(true);
            SecondDialogText.text = text;
        }
        else
        {
            FirstDialogBubble.SetActive(true);
            FirstDialogText.text = text;
        }
    }

    public void HideAll()
    {
        FirstDialogBubble.SetActive(false);
        SecondDialogBubble.SetActive(false);
    }
}
