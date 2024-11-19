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
                    Debug.Log($"ũ����Ż {amount}���! ���簳�� : {crtstalCount}");
                    return true;
                }
                break;
            case ItemType,Plant;
                if (plantCount >= amount)
                {
                    plantCount -= amount;
                    Debug.Log($"�Ĺ� {amount}���! ���簳�� : {plantCount}");
                    return true;
                }
                break;
            case ItemType,Brush;
                if (brushCount >= amount)
                {
                    brushCount -= amount;
                    Debug.Log($"��Ǯ {amount}���! ���簳�� : {brushCount}");
                    return true;
                }
                break;
            case ItemType,Tree;
                if (treeCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"���� {amount}���! ���簳�� : {treeCount}");
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
        Debug.Log("=======�κ��丮=======");
        Debug.Log($"ũ����Ż:{crtstalCount}��");
        Debug.Log($"�Ĺ�:{plantCount}��");
        Debug.Log($"��Ǯ:{brushCount}��");
        Debug.Log($"����:{treeCount}��");
        Debug.Log("======================");
    }
}
