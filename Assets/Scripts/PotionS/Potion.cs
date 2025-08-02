using DND;
using UnityEngine;
using UnityEngine.Events;

public class Potion : DragAndDrop
{
    [SerializeField] private string _customerTag;

    public UnityEvent OnConsumed;

    private bool _isDragged = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_isDragged)
        {
            var isCustomer = collision.gameObject.tag == _customerTag;

            if (isCustomer)
            {
                OnConsumed?.Invoke();

                Debug.Log("achieved");
                Destroy(gameObject);
            }
        }
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        
        _isDragged = true;
        
        Debug.Log("dragged");
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        
        _isDragged = false;
        
        Debug.Log("released");
    }
}
