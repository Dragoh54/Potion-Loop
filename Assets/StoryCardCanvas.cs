using TMPro;
using UnityEngine;

public class StoryCardCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textElement;

    public void DisplayText(string text)
    {
        _textElement.text = text;
    }
}
