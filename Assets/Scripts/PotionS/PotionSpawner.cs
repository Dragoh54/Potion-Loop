using UnityEngine;
using UnityEngine.Events;

public class PotionSpawner : MonoBehaviour
{
    [field: SerializeField] public Potion[] potions;

    public UnityEvent OnPotionConsumed;

    public void SpawnPotion(int i)
    {
        var potion = Instantiate(potions[i], transform.position, Quaternion.identity);
        potion.OnConsumed.AddListener(() => OnPotionConsumed?.Invoke());
    }
}
