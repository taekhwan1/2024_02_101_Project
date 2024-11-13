using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //각각의 아이템 개수를 저장하는 변수
    public int crystalCount = 0;             //크리스탈 개수
    public int plantCount = 0;               //식물 개수
    public int bushCount = 0;                //수풀 개수
    public int treeCount = 0;                //나무 개수

    //여러 아이템을 한꺼번에 획득
    public void AddItem(ItemType itemType, int amount)
    {
        //amount 만큼 여러번 AddItem 호출
        for (int i = 0; i < amount; i++)
        {
            AddItem(itemType);
        }
    }

    //아이템을 추가하는 함수, 아이템 종류에 따라 해당 아이템의 개수를 증가시킴

    public void AddItem(ItemType itemType)
    {
        //아이템 종류에 따른 다른 동작 수행
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++;  //크리스탈 개수 증가
                Debug.Log($"크리스탈 획득! 현재 개수 :{crystalCount}");                  //현재 크리스탈 개수 출력
                break;
            case ItemType.Plant:
                plantCount++;  //식물 개수 증가
                Debug.Log($"식물 획득! 현재 개수 :{plantCount}");                  //현재 식물 개수 출력
                break;
            case ItemType.Bush:
                bushCount++;  //수풀 개수 증가
                Debug.Log($"수풀 획득! 현재 개수 :{bushCount}");                  //현재 수풀 개수 출력
                break;
            case ItemType.Tree:
                treeCount++;  //나무 개수 증가
                Debug.Log($"나무 획득! 현재 개수 :{treeCount}");                  //현재 나무 개수 출력
                break;
        }
    }
    
    //아이템을 제거하는 함수
    public bool Removeitem(ItemType itemType, int amount = 1)
    {
        //아이템 종류에 따른 다른 동작 수행
        switch (itemType)
        {
            case ItemType.Crystal:
                if (crystalCount >= amount)     //가지고 있는 개수가 충분한지 확인
                {
                    crystalCount -= amount;  //크리스탈 개수 감소
                    Debug.Log($"크리스탈 {amount} 사용! 현재 개수 :{crystalCount}");                  //현재 크리스탈 개수 출력
                    return true;
                }             
                break;
            case ItemType.Plant:
                if (plantCount >= amount)     //가지고 있는 개수가 충분한지 확인
                {
                    plantCount -= amount;  //식물 개수 증가
                    Debug.Log($"식물 {amount} 사용! 현재 개수 :{plantCount}");                  //현재 식물 개수 출력
                }                                   
                break;
            case ItemType.Bush:
                if (bushCount >= amount)     //가지고 있는 개수가 충분한지 확인
                {
                    bushCount -= amount;  //수풀 개수 증가
                    Debug.Log($"수풀 {amount} 사용! 현재 개수 :{bushCount}");                  //현재 수풀 개수 출력
                }               
                break;
            case ItemType.Tree:
                if (treeCount >= amount)     //가지고 있는 개수가 충분한지 확인
                {
                    treeCount -= amount;  //나무 개수 증가
                    Debug.Log($"나무 {amount} 사용! 현재 개수 :{treeCount}");                  //현재 나무 개수 출력
                }                   
                break;
        }

        Debug.Log($"{itemType} 아이템이 부족합니다.");
        return false;       
    }

    //특정 아이템의 현재 개수를 반환 하는 함수
    public int GetItemCount(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                return crystalCount;
            case ItemType.Plant:
                return plantCount;
            case ItemType.Bush:
                return bushCount;
            case ItemType.Tree:
                return treeCount;
            default:
                return 0;
        }
    }



    // Update is called once per frame
    void Update()
    {
        // I 키를 눌렀을 때 인벤토리 로그 내역을 보여줌
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();                            //인벤토리 출력 함수 호출
        }
    }

    private void ShowInventory()
    {
        Debug.Log("====인벤토리====");
        Debug.Log($"크리스탈:{crystalCount}개");           //크리스탈 개수 출력
        Debug.Log($"식물:{plantCount}개");                 //식물 개수 출력
        Debug.Log($"수풀:{bushCount}개");                  //수풀 개수 출력
        Debug.Log($"나무:{treeCount}개");                  //나무 개수 출력
        Debug.Log("================");
    }
}
