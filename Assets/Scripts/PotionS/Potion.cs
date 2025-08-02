using DND;
using UnityEngine;

public class Potion : DragAndDrop
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //todo: chelik poluchil zelie
        
        Debug.Log("achieved");
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
