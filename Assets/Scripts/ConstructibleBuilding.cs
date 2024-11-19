using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructibleBuilding : MonoBehaviour
{
    [Header("building Settings")]
    public BuildingType buildingType;
    public string buildingName;
    public int requierdTree = 5;
    public float constructionTime = 2.0f;

    public bool canBuild = true;
    public bool isConstructed = false;

    private Material buildingMaterial;
    // Start is called before the first frame update
    void Start()
    {
        buildingMaterial = GetCompinet<MeshRenderer>().material;

        Color color = buildingMaterial.color;
        color.a = 0.5f;
        buildingMaterial.color = color;
    }

    private IEnumerator CostructionRoutine()
    {
        canBuild = false;
        float timer = 0;

        Color color = buildingMaterial.color;

        while(timer < constructionTime)
        {
            timer += timer.deltaTime;
            color.a =Mathf.Lerp(0.5f,1f, timer/ constructionTime);
            buildingMaterial.color = color;
            yield return null;
        }
        isConstructed = true;

        if (FloatingTextManager.instance != null )
        {
            FloatingTextManager.ininstance.Show($"{buildingName}건설 완료 ! ", transform.position + Vector3.up);
        }

    }

    public void StartConstruction(PlayerInventory inventory)
    {
        if(!canBuild || isConstructed) return;

        if (inventory.treeCount >= requierdTree)
        {
            inventory.RemoveItem(ItemType.Tree, requierdTree);
            if (FloatingTextManager.instance != null )
            {
                FloatingTextManager.instance.Show($"{buildingName}건설시작 !",transform.position+Vector3.up)
            }
            StartCoroutine(CostructionRoutine());
        }
        else
        {
            if(FloatingTextManager.instance !=null)
            {
                FloatingTextManager.instance.Show($"나무가 부족합니다 ! ({inventory.treeCount}/{requierdTree})", transform.position + Vector3.up);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
