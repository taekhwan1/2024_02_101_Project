using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //������ ������ ������ �����ϴ� ����
    public int crystalCount = 0;             //ũ����Ż ����
    public int plantCount = 0;               //�Ĺ� ����
    public int bushCount = 0;                //��Ǯ ����
    public int treeCount = 0;                //���� ����

    //���� �������� �Ѳ����� ȹ��
    public void AddItem(ItemType itemType, int amount)
    {
        //amount ��ŭ ������ AddItem ȣ��
        for (int i = 0; i < amount; i++)
        {
            AddItem(itemType);
        }
    }

    //�������� �߰��ϴ� �Լ�, ������ ������ ���� �ش� �������� ������ ������Ŵ

    public void AddItem(ItemType itemType)
    {
        //������ ������ ���� �ٸ� ���� ����
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++;  //ũ����Ż ���� ����
                Debug.Log($"ũ����Ż ȹ��! ���� ���� :{crystalCount}");                  //���� ũ����Ż ���� ���
                break;
            case ItemType.Plant:
                plantCount++;  //�Ĺ� ���� ����
                Debug.Log($"�Ĺ� ȹ��! ���� ���� :{plantCount}");                  //���� �Ĺ� ���� ���
                break;
            case ItemType.Bush:
                bushCount++;  //��Ǯ ���� ����
                Debug.Log($"��Ǯ ȹ��! ���� ���� :{bushCount}");                  //���� ��Ǯ ���� ���
                break;
            case ItemType.Tree:
                treeCount++;  //���� ���� ����
                Debug.Log($"���� ȹ��! ���� ���� :{treeCount}");                  //���� ���� ���� ���
                break;
        }
    }
    
    //�������� �����ϴ� �Լ�
    public bool Removeitem(ItemType itemType, int amount = 1)
    {
        //������ ������ ���� �ٸ� ���� ����
        switch (itemType)
        {
            case ItemType.Crystal:
                if (crystalCount >= amount)     //������ �ִ� ������ ������� Ȯ��
                {
                    crystalCount -= amount;  //ũ����Ż ���� ����
                    Debug.Log($"ũ����Ż {amount} ���! ���� ���� :{crystalCount}");                  //���� ũ����Ż ���� ���
                    return true;
                }             
                break;
            case ItemType.Plant:
                if (plantCount >= amount)     //������ �ִ� ������ ������� Ȯ��
                {
                    plantCount -= amount;  //�Ĺ� ���� ����
                    Debug.Log($"�Ĺ� {amount} ���! ���� ���� :{plantCount}");                  //���� �Ĺ� ���� ���
                }                                   
                break;
            case ItemType.Bush:
                if (bushCount >= amount)     //������ �ִ� ������ ������� Ȯ��
                {
                    bushCount -= amount;  //��Ǯ ���� ����
                    Debug.Log($"��Ǯ {amount} ���! ���� ���� :{bushCount}");                  //���� ��Ǯ ���� ���
                }               
                break;
            case ItemType.Tree:
                if (treeCount >= amount)     //������ �ִ� ������ ������� Ȯ��
                {
                    treeCount -= amount;  //���� ���� ����
                    Debug.Log($"���� {amount} ���! ���� ���� :{treeCount}");                  //���� ���� ���� ���
                }                   
                break;
        }

        Debug.Log($"{itemType} �������� �����մϴ�.");
        return false;       
    }

    //Ư�� �������� ���� ������ ��ȯ �ϴ� �Լ�
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
        // I Ű�� ������ �� �κ��丮 �α� ������ ������
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();                            //�κ��丮 ��� �Լ� ȣ��
        }
    }

    private void ShowInventory()
    {
        Debug.Log("====�κ��丮====");
        Debug.Log($"ũ����Ż:{crystalCount}��");           //ũ����Ż ���� ���
        Debug.Log($"�Ĺ�:{plantCount}��");                 //�Ĺ� ���� ���
        Debug.Log($"��Ǯ:{bushCount}��");                  //��Ǯ ���� ���
        Debug.Log($"����:{treeCount}��");                  //���� ���� ���
        Debug.Log("================");
    }
}
