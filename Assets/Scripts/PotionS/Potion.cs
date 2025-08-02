using DND;
using UnityEngine;
using UnityEngine.Events;

public class Potion : DragAndDrop
{
    [SerializeField] private string _customerTag;

    public UnityEvent OnConsumed;

    private void OnTriggerEnter2D(Collider2D collision)
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
