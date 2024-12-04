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
                Debug.Log($"크리스탈 획득 ! 현재개수 : {crystalCount}");
                break;
            case ItemType.Plant:
                plantCount++;
                Debug.Log($"식물 획득 ! 현재개수 : {crystalCount}");
                break;
            case ItemType.Brush:
                brushCount++;
                Debug.Log($"수풀 획득 ! 현재개수 : {crystalCount}");
                break;
            case ItemType.Tree:
                treeCount++;
                Debug.Log($"나무 획득 ! 현재개수 : {crystalCount}");
                break;
            case ItemType.VegetableStew:
                vegetableStewCount++;
                Debug.Log($"야채스튜 획득 ! 현재개수 : {crystalCount}");
                break;
            case ItemType.FruitSalad:
                fruitSaladCount++;
                Debug.Log($"과일샐러드 획득 ! 현재개수 : {crystalCount}");
                break;
            case ItemType.RepairKit:
                repairKitCount++;
                Debug.Log($"수리키트 획득 ! 현재개수 : {crystalCount}");
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
                    Debug.Log($"크리스탈 {amount}사용! 현재개수 : {crystalCount}");
                    return true;
                }
                break;
            case ItemType.Plant:
                if (plantCount >= amount)
                {
                    plantCount -= amount;
                    Debug.Log($"식물 {amount}사용! 현재개수 : {plantCount}");
                    return true;
                }
                break;
            case ItemType.Brush:
                if (brushCount >= amount)
                {
                    brushCount -= amount;
                    Debug.Log($"수풀 {amount}사용! 현재개수 : {brushCount}");
                    return true;
                }
                break;
            case ItemType.Tree:
                if (treeCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"나무 {amount}사용! 현재개수 : {treeCount}");
                    return true;
                }
                break;
            case ItemType.VegetableStew:
                if (vegetableStewCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"야채스튜 {amount}사용! 현재개수 : {vegetableStewCount}");
                    return true;
                }
                break;
            case ItemType.FruitSalad:
                if (fruitSaladCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"과일샐러드 {amount}사용! 현재개수 : {fruitSaladCount}");
                    return true;
                }
                break;
            case ItemType.RepairKit:
                if (repairKitCount >= amount)
                {
                    treeCount -= amount;
                    Debug.Log($"수리키트 {amount}사용! 현재개수 : {repairKitCount}");
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
        Debug.Log("=======인벤토리=======");
        Debug.Log($"크리스탈:{crystalCount}개");
        Debug.Log($"식물:{plantCount}개");
        Debug.Log($"수풀:{brushCount}개");
        Debug.Log($"나무:{treeCount}개");
        Debug.Log("======================");
    }
}
