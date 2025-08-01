using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [field: SerializeField] public DialogCanvas DialogCanvas { get; private set; }
    [field: SerializeField] public TextList DialogList { get; private set; }

    private int _currentCustomer = -1;

    private void Start()
    {
        DialogList = GetComponent<FileReader>().GetDialogText();
        ChangeCustomer();
    }

    private void ChangeCustomer()
    {
        _currentCustomer++;
        StartCoroutine("ShowDialog");
    }

    private IEnumerator ShowDialog()
    {
        var customerDialogs = DialogList.allStory[_currentCustomer].array;
        for (int i = 0; i < customerDialogs.Count; i++)
        {
            DialogCanvas.ShowDialog(customerDialogs[i].text);

            yield return new WaitForSeconds(3.0f);

            if (i != 0 && i % 2 == 1)
            {
                DialogCanvas.HideAll();

                yield return new WaitForSeconds(1.0f);
            }
        }

        DialogCanvas.HideAll();
    }
}
