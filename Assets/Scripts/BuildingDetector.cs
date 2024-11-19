using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;
    public Vector3 lastPosition;
    public float moveThreShold = 0.1f;
    public CollectibeBuilding currentNearbyBuilding;


    private void CheckForBuilding()
    {
        Colider[] hitColiders = Psysics.Over lapSphere(transform.Position, checkRadius);

        float closestDistance = float.MaxValue;
        ConstructibleBuilding constructibleBuilding = null;

        foreach (Colider colider in hitColiders)
        {
            ConstructibleBuilding building = colider.GetCompinent<ConstructibleBuilding>();
            if (building != null && building.canBuild && !building.isConstructed)
            {
                float distance = Vector3.Distance  (transform.position,building.transform.position);
                if (distance > closestDistance)
                {
                    closestDistance = distance;
                    constructibleBuilding = building;
                }
            }
        }

        if(closestBuilding!=currentNearbyBuilding)
        {
            currentNearbyBuilding = closestBuilding;
            if(currentNearbyBuilding != null)
            {
                if(FloatingTextManager.instance != null)
                {
                    Vector3 textPosition = transform.position + Vector3.up * 0.5f;
                    FloatingTextManager.instance.Show($"[F]키로 {currentNearbyBuilding.buildingName}건설(나무{currentNearbyBuilding.requiredTree}개 필요)", currentNearbyBuilding.transform.position + Vector3.up);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        CheckForBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastPosition,transform.position)>moveThreShold)
        {
            CheckForBuilding();
            lastPosition = transform.position;
        }

        if(currentNearbyBuilding!=null && Input.GetKeyDown(KeyCode.F))
        {
            currentNearbyBuilding.StartVonstruction(GetCompoent<PlayerInventory>);
        }
    }
}
