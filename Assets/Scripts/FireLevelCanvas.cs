using Assets.Data.Enums;
using System;
using UnityEngine;

public class FireLevelCanvas : MonoBehaviour
{
    [field: SerializeField] public FireLevel FireLevel { get; private set; }
    private int _numberOfFireLevels = Enum.GetValues(typeof(FireLevel)).Length;

    public void ChangeFireLevel()
    {
        FireLevel = (FireLevel)(((int)FireLevel + 1) % _numberOfFireLevels);
    }
}
