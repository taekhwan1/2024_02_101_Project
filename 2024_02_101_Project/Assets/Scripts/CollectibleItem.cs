using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������ ������ ��ũ��Ʈ
public class CollectibleItem : MonoBehaviour
{
    public ItemType itemType;                           //������ ���� ( �� : ũ����Ż, �Ĺ�, ��Ǯ, ����)
    public string itemName;                             //������ �̸�
    public float respwanTime = 30.0f;                   //������ �ð�(�������� �ٽ� ���� �� �� ������ ��� �ð�)
    public bool canCollect = true;                      //���� ���� ����(������ �� �ִ� �� ���θ� ��Ÿ��)

    //�������� �����ϴ� �޼��� , playerInventory�� ���� �κ��丮�� �߰�

    public void Collectitem(PlayerInventory inventory)
    {
        //���� ���� ���θ� üũ
        if (!canCollect)return;

        inventory.AddItem(itemType);                //�������� �κ��丮�� �߰�

        if(FloatingTextManager.Instance != null)
        {
            Vector3 textPosition = transform.position + Vector3.up * 0.5f;               //������ ��ġ���� �ణ ���� �ؽ�Ʈ ����
            FloatingTextManager.Instance.Show($"+ {itemName}", textPosition);
        }

        Debug.Log($"{itemName} ���� �Ϸ�");         //������ ���� �Ϸ� �޼��� ���


        StartCoroutine(RespawnRoutine());           //������ ������ �ڷ�ƾ ����
    }

    //������ �������� ó���ϴ� �ڷ�ƾ   
    private IEnumerator RespawnRoutine()
    {
        canCollect = false;                      //���� �Ұ��� ���·� ����
        GetComponent<MeshRenderer>().enabled = false;                          //��Ƽ���� MeshRenderer�� ���� ������ �ʰ� ��
        GetComponent<MeshCollider>().enabled = false;

        //������ ������ �ð� ��ŭ ���
        yield return new WaitForSeconds(respwanTime);
         
        GetComponent<MeshRenderer>().enabled = true;                          //�������� �ٽ� ���̰� ��
        GetComponent<MeshCollider>().enabled = false;
        canCollect = true;                                                    //���� ���� ���·� ����
    }
}
    