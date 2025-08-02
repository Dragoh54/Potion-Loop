using System;
using UnityEngine;

public class RewardIngredient : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Award()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
