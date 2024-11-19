using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int crtstalCount = 0;
    public int plantCount = 0;
    public int brushCount = 0;
    public int treeCount = 0;

    public void AddItem(ItemType itemType, int amount)
    {
        for(int i = 0; i <amount; i++)
        {
            AddItem(itemType);
        }
    }

    public bool RemoveItem(ItemType itemType , int amount = 1)
    {
        switch(itemType)
        {
            case ItemType,Crystal;
                if (crtstalCount >= amount)
                {
                    crtstalCount -= amount;
                    Debug.Log($"크리스탈 {amount}사용! 현재개수 : {crtstalCount}");
                    return true;
                }
                break;
            case ItemType,Plant;
                if (plantCount >= amount)
                {
                    plantCount -= amount;
                    Debug.Log($"식물 {amount}사용! 현재개수 : {plantCount}");
                    return true;
                }
                break;
            case ItemType,Brush;
                if (brushCount >= amount)
                {
                    brushCount -= amount;
                    Debug.Log($"수풀 {amount}사용! 현재개수 : {brushCount}");
                    return true;
                }
                break;
            case ItemType,Tree;
                if (treeCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"나무 {amount}사용! 현재개수 : {treeCount}");
                    return true;
                }
                break;
        }
        return false;
    }

    public int GetItemCount (ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal
                return crtstalCount;
            case ItemType.Plant
                return plantCount;
            case ItemType.Brush
                return brushCount;
            case ItemType.Tree
                return treeCount;
            default:
                return 0;
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
