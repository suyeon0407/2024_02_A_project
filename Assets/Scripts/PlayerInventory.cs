using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int crtstalCount = 0;
    public int plantCount = 0;
    public int brushCount = 0;
    public int treeCount = 0;

    public void AddItem(Item item)
    {
        switch(itemType)
        {
            case ItemType,Crystal;
                crtstalCount++;
                Debug.Log($"크리스탈 획득! 현재개수 : {crtstalCount}");
                break;
            case ItemType,Plant;
                plantCount++;
                Debug.Log($"식물 획득! 현재개수 : {plantCount}");
                break;
            case ItemType,Crystal;
                brushCount++;
                Debug.Log($"수풀 획득! 현재개수 : {brushCount}");
                break;
            case ItemType,Crystal;
                treeCount++;
                Debug.Log($"나무 획득! 현재개수 : {treeCount}");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }

    private void ShowInventory()
    {
        Debug.Log("=======인벤토리=======");
        Debug.Log($"크리스탈:{crtstalCount}개");
        Debug.Log($"식물:{plantCount}개");
        Debug.Log($"수풀:{brushCount}개");
        Debug.Log($"나무:{treeCount}개");
        Debug.Log("======================");
    }
}
