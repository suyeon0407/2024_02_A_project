using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCrafter : MonoBehaviour
{
    public BuildingType buildingType;
    public CraftingRecipe[] recipes;
    private SurvivalStats survivalStats;
    private ConstructibleBuilding building;
    // Start is called before the first frame update
    void Start()
    {
        survivalStats = FindObjectOfType<SurvivalStats>();
        building = GetComponent<ConstructibleBuilding>();

        switch (buildingType)
        {
            case BuildingType.kitchen;
                recipes = RecipeList.KitchenRecipes;
                break;
            case BuildingType.CraftingTable;
                recipes = RecipeList.WorkbenchRecipes;
                break;
        }
    }

    public void TryCraft(CraftingRecipe recipe, PlayerInventory inventory)
    {
        if(!building.isConstructed)
        {
            FloatingTextManager.instance?,Show("건설이 완료되지않았습니다!", transform.position + Vector3.up);
            return;
        }
        for (int i = 0; i < recipe.requiredItems.Length; i++)
        {
            inventory.RemoveItem(recipe.requiredItems[i], recipe, requiredAmounts[i]);
        }

        survivalStats.DamageCrafting();

        inventory.AddItem(recipe.resultItem,recipe.resultAmount);
        FloatingTextManager.instance?.Show($"{recipe.itemName}", transform.position + Vector3.up);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
