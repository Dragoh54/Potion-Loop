using System.Collections.Generic;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    [SerializeField] private TextAsset file;
    public TextList GetDialogText()
    {
        return JsonUtility.FromJson<TextList>(file.text);
    }
}

[System.Serializable]
public class GameText
{
    public string text;
}

//[System.Serializable]
//public class AllStory
//{
//    public List<GameText> firstWerewolf;
//    public List<GameText> secondWerewolf;
//    public List<GameText> thirdWerewolf;

//    public List<GameText> firstWitch;
//    public List<GameText> secondWitch;
//    public List<GameText> thirdWitch;

//    public List<GameText> firstFairy;
//    public List<GameText> secondFairy;
//    public List<GameText> thirdFairy;
//}

[System.Serializable]
public class TextList
{
    public List<InnerList> dialogs;
    public List<GameText> storyCards;
}
[System.Serializable]
public class InnerList
{
    public List<GameText> array;
    public string potion;
}