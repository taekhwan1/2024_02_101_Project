using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;                    //건물 감지 범위
    private Vector3 lastPosition;                       //플레이어의 마지막 위치 저장
    private float moveThreshold = 0.1f;                 //이동 감지 임계값
    private ConstructibleBuilding currentNearbyBuilding;       //현재 가장 가까이 있는 건설 가능한 건물

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

        float closestDistance = float.MaxValue;     //가장 가까운 거리의 초기값
        ConstructibleBuilding closestBuilding = null;         //가장 가까운 아이템 초기값

        //각 콜라이더를 검사하여 수집 가능한 아이템을 찾음
        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();
            if (building != null && building.canBuild && !building.isConstructed)
            {
                float distance = Vector3.Distance(transform.position, building.transform.position); //거리 계산
                if (distance < closestDistance)      //더 가까운 아이템을 발견 시 업데이트
                {
                    closestDistance = distance;
                    closestBuilding = building;
                }
            }
        }

        if (closestBuilding != currentNearbyBuilding) //가장 가까운 아이템이 변경되었을 때만 메세지 표시
        {
            currentNearbyBuilding = closestBuilding;             //가장 가까운 아이템 업데이트
            if (currentNearbyBuilding != null)
            {
                if (FloatingTextManager.Instance != null)
                {
                    FloatingTextManager.Instance.Show(
                        $"[F]키로 {currentNearbyBuilding.buildingName} 건설 (나무 {currentNearbyBuilding.requriedTree} 개 필요)",
                        currentNearbyBuilding.transform.position + Vector3.up
                        );
                }

            }
        }
    }
}


