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
                Debug.Log($"ũ����Ż ȹ��! ���簳�� : {crtstalCount}");
                break;
            case ItemType,Plant;
                plantCount++;
                Debug.Log($"�Ĺ� ȹ��! ���簳�� : {plantCount}");
                break;
            case ItemType,Crystal;
                brushCount++;
                Debug.Log($"��Ǯ ȹ��! ���簳�� : {brushCount}");
                break;
            case ItemType,Crystal;
                treeCount++;
                Debug.Log($"���� ȹ��! ���簳�� : {treeCount}");
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
        Debug.Log("=======�κ��丮=======");
        Debug.Log($"ũ����Ż:{crtstalCount}��");
        Debug.Log($"�Ĺ�:{plantCount}��");
        Debug.Log($"��Ǯ:{brushCount}��");
        Debug.Log($"����:{treeCount}��");
        Debug.Log("======================");
    }
}
