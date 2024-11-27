using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Crysteal,
    Plant,
    Brush,
    Tree,
    VeagtableStew,
    FruitSalad,
    RepairKit

}
public class ItemDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;
    public Vector3 lastPosition;
    public float moveThreShold = 0.1f;
    public CollectibeItem currentNearbyItem;

    void Start()
    {
        lastPosition = transform.position;
        CheckForItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastPosition. transform.position)>moveThreShold)
        {
            CheckForItems();
            lastPosition = transform.position;
        }

        if (currentNearbyItem !=null && Input.GetKeyDown(KeyCode.E))
        {
            currentNearbyItem.CollectItem(GetComponet<PlayerInventory>());
        }
    }

    private void OnDrawGrizmos()
    {
        Grizmos.color = Color.blue;
        Grizmos.DrawSphere(transform.position, checkRadius);
    }
}
