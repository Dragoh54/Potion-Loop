using System;
using UnityEngine;

public class Ingridient : MonoBehaviour, IIngridient
{
    private Vector3 _startPosition;
    
    private SpriteRenderer _renderer;
    private Color _originalColor;
    
    [SerializeField]
    private float spriteTransparency = 0.7f;
    
    [SerializeField]
    private GameObject _ingridientPrefab;
    
    [SerializeField]
    private string layerName = "cauldron";
    
    void Awake()
    {
        _startPosition = transform.position;
        _renderer = GetComponent<SpriteRenderer>();
        _originalColor = _renderer.color;
    }

    private void FixedUpdate()
    {
        var hit = Physics2D.OverlapPoint(transform.position);
        if (hit && hit.gameObject.layer == LayerMask.NameToLayer(layerName))
        {
            Use();
        }
    }

    public void Return()
    {
        Debug.Log("Return");
        gameObject.transform.position = _startPosition;
    }

    public void Use()
    {
        Debug.Log("Used");
        gameObject.transform.position = _startPosition;
    }

    // private void OnMouseDrag()
    // {
    //     var hit = Physics2D.OverlapPoint(transform.position);
    //     if (hit != null && hit.gameObject.layer == LayerMask.NameToLayer(layerName))
    //     {
    //         Use();
    //     }
    // }

    private void OnMouseEnter()
    {
        var color = _renderer.material.color;
        color.a = spriteTransparency;
        _renderer.material.color = color;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _originalColor;
    }
}
