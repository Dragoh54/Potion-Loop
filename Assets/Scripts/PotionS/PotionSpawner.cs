using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    [field: SerializeField] public Potion[] potions;
    public void SpawnPotion(int i)
    {
        Instantiate(potions[i], transform.position, Quaternion.identity);
    }
}
