using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForItems : MonoBehaviour
{

    private void CheckForItems()
    {
        Colider[] hitColiders = Physics.OverlapSphere(transform.position, checkRadius);

        float closestDistance = float.MaxValue;
        CollectibleItem closestItem = null;

        foreach (Collider collider in hitColiders)
        {
            CollectibleItem item = collider.GetCompoent<CollectibleItem>();
            if (item !=null && item.canCollect)
            {
                float distance = Vector3.Distance(transform.Position, item.transform.position);
                if (distance<closestDistance)
                {
                    closestDistance = distance;
                    closestItem = item;
                }
            }
        }
        if(closestItem !=currentNearbyItem)
        {
            currentNearbyItem = closestItem;
            if(currentNearbyItem !=null)
            {
                Debug.Log($"[E] 키를 눌러 {currentNearbyItem.itemName} 수집");
            }
        }
    }





}
