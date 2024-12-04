using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private SurvivalStats survivalStats;

    public int crystalCount = 0;
    public int plantCount = 0;
    public int brushCount = 0;
    public int treeCount = 0;

    public int vegetableStewCount = 0;
    public int fruitSaladCount = 0;
    public int repairKitCount = 0;
    public void Start()
    {
        survivalStats = GetComponent<SurvivalStats>();
    }

    public void AddItem(ItemType itemType, int amount)
    {
        for(int i = 0; i <amount; i++)
        {
            AddItem(itemType);
        }
    }

    public void AddItem(ItemType itemType)
    {
        switch(itemType)
        {
            case ItemType.Crysteal:
                crystalCount++;
                Debug.Log($"ũ����Ż ȹ�� ! ���簳�� : {crystalCount}");
                break;
            case ItemType.Plant:
                plantCount++;
                Debug.Log($"�Ĺ� ȹ�� ! ���簳�� : {crystalCount}");
                break;
            case ItemType.Brush:
                brushCount++;
                Debug.Log($"��Ǯ ȹ�� ! ���簳�� : {crystalCount}");
                break;
            case ItemType.Tree:
                treeCount++;
                Debug.Log($"���� ȹ�� ! ���簳�� : {crystalCount}");
                break;
            case ItemType.VegetableStew:
                vegetableStewCount++;
                Debug.Log($"��ä��Ʃ ȹ�� ! ���簳�� : {crystalCount}");
                break;
            case ItemType.FruitSalad:
                fruitSaladCount++;
                Debug.Log($"���ϻ����� ȹ�� ! ���簳�� : {crystalCount}");
                break;
            case ItemType.RepairKit:
                repairKitCount++;
                Debug.Log($"����ŰƮ ȹ�� ! ���簳�� : {crystalCount}");
                break;
        }
    }

    public bool RemoveItem(ItemType itemType , int amount = 1)
    {
        switch(itemType)
        {
            case ItemType.Crystal:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount;
                    Debug.Log($"ũ����Ż {amount}���! ���簳�� : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Plant:
                if (plantCount >= amount)
                {
                    plantCount -= amount;
                    Debug.Log($"�Ĺ� {amount}���! ���簳�� : {plantCount}");
                    return true;
                }
                break;
            case ItemType.Brush:
                if (brushCount >= amount)
                {
                    brushCount -= amount;
                    Debug.Log($"��Ǯ {amount}���! ���簳�� : {brushCount}");
                    return true;
                }
                break;
            case ItemType.Tree:
                if (treeCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"���� {amount}���! ���簳�� : {treeCount}");
                    return true;
                }
                break;
            case ItemType.VegetableStew:
                if (vegetableStewCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"��ä��Ʃ {amount}���! ���簳�� : {vegetableStewCount}");
                    return true;
                }
                break;
            case ItemType.FruitSalad:
                if (fruitSaladCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"���ϻ����� {amount}���! ���簳�� : {fruitSaladCount}");
                    return true;
                }
                break;
            case ItemType.RepairKit:
                if (repairKitCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"����ŰƮ {amount}���! ���簳�� : {repairKitCount}");
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
            case ItemType.Crystal:
                return crystalCount;
            case ItemType.Plant:
                return plantCount;
            case ItemType.Brush:
                return brushCount;
            case ItemType.Tree:
                return treeCount;
            
            case ItemType.VeagtableStew:
                return vegetableStewCount;
            case ItemType.FruitSalad:
                return fruitSaladCount;
            case ItemType.RepairKit:
                return repairKitCount;
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
        Debug.Log($"ũ����Ż:{crystalCount}��");
        Debug.Log($"�Ĺ�:{plantCount}��");
        Debug.Log($"��Ǯ:{brushCount}��");
        Debug.Log($"����:{treeCount}��");
        Debug.Log("======================");
    }
}
