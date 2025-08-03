using UnityEngine;

public class SpriteVisualizer : MonoBehaviour
{
    [field: SerializeField] public Sprite[] Sprites {  get; private set; }

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(int currentCustomer)
    {
        if(currentCustomer >= Sprites.Length)
        {
            return;
        }

        _spriteRenderer.sprite = Sprites[currentCustomer];
    }

    public void HideSprite()
    {
        _spriteRenderer.sprite = null;
    }
}
