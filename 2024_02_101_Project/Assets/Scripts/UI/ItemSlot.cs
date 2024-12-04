using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;                           //������ �̸�
    public TextMeshProUGUI countText;                              //������ ����
    public Button useButton;                                       //��� ��ư

    private ItemType itemType;
    private int itemCount;

    public void Setup(ItemType type, int count)
    {
        itemType = type;
        itemCount = count;

        itemNameText.text = GetItemDisplayName(type);
        countText.text = count.ToString();

        useButton.onClick.AddListener(UseItem);
    }

    private string GetItemDisplayName(ItemType type)                       //������ ������ ǥ�� �Ǵ� �̸� ����
    {
        switch(type)
        {
            case ItemType.VegetableStew: return "��ä ��Ʃ";
            case ItemType.FruitSalad: return "���� ������";
            case ItemType.RepairKit: return "����ŰƮ";
            default: return type.ToString();
        }


    }

    private void UseItem()                                                    //������ ��� �Լ�
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();      //���� �κ��丮�� ����
        SurvivalStats stats = FindObjectOfType<SurvivalStats>();              //���� ���� ����
        switch(itemType)  
        {
            case ItemType.VegetableStew:                                      //��ä ��Ʃ�� ���
                if(inventory.Removeitem(itemType,1))                          //�κ��丮���� ������ 1�� ����
                {
                    stats.EatFood(40f);                                       //��� +40
                    InventoryUIManager.Instance.RefreshInventory();
                }
                break;
            case ItemType.FruitSalad:                                         //���� ������
                if (inventory.Removeitem(itemType, 1))                        //�κ��丮���� ������ 1�� ����
                {
                    stats.EatFood(50f);                                       //��� +50
                    InventoryUIManager.Instance.RefreshInventory();
                }
                break;
            case ItemType.RepairKit:                                          //���� ŰƮ
                if (inventory.Removeitem(itemType, 1))                        //�κ��丮���� ������ 1�� ����
                {
                    stats.RepairSuit(25f);
                    InventoryUIManager.Instance.RefreshInventory();
                }
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}