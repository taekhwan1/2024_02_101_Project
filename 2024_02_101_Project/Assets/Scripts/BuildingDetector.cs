using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;                    //�ǹ� ���� ����
    private Vector3 lastPosition;                       //�÷��̾��� ������ ��ġ ����
    private float moveThreshold = 0.1f;                 //�̵� ���� �Ӱ谪
    private ConstructibleBuilding currentNearbyBuilding;       //���� ���� ������ �ִ� �Ǽ� ������ �ǹ�

    void Start()
    {
        lastPosition = transform.position;
        CheckForBuilding();
    }

    void Update()
    {
        if (Vector3.Distance(lastPosition, transform.position) > moveThreshold)
        {
            CheckForBuilding();
            lastPosition = transform.position;
        }

        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());
        }
    }
    private void CheckForBuilding()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        float closestDistance = float.MaxValue;     //���� ����� �Ÿ��� �ʱⰪ
        ConstructibleBuilding closestBuilding = null;         //���� ����� ������ �ʱⰪ

        //�� �ݶ��̴��� �˻��Ͽ� ���� ������ �������� ã��
        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();
            if (building != null && building.canBuild && !building.isConstructed)
            {
                float distance = Vector3.Distance(transform.position, building.transform.position); //�Ÿ� ���
                if (distance < closestDistance)      //�� ����� �������� �߰� �� ������Ʈ
                {
                    closestDistance = distance;
                    closestBuilding = building;
                }
            }
        }

        if (closestBuilding != currentNearbyBuilding) //���� ����� �������� ����Ǿ��� ���� �޼��� ǥ��
        {
            currentNearbyBuilding = closestBuilding;             //���� ����� ������ ������Ʈ
            if (currentNearbyBuilding != null)
            {
                if (FloatingTextManager.Instance != null)
                {
                    FloatingTextManager.Instance.Show(
                        $"[F]Ű�� {currentNearbyBuilding.buildingName} �Ǽ� (���� {currentNearbyBuilding.requriedTree} �� �ʿ�)",
                        currentNearbyBuilding.transform.position + Vector3.up
                        );
                }

            }
        }
    }
}


