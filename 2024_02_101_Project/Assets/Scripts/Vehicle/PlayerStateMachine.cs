using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷��̾��� ���¸� ����
public class PlayerStateMachine : MonoBehaviour
{ 
    public PlayerState currentState;                   //���� �÷��̾��� ���¸� ��Ÿ���� ����
    public PlayerController PlayerController;          //PlayerController�� ����

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();   //���� ������Ʈ�� �پ��ִ� PlayerController�� ����
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //�ʱ� ���¸� IdleStatefh ����
        TransitionToState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���°� �����Ѵٸ� �ش� ������ Update �޼��� ȣ��
        if (currentState != null)
        {
            currentState.Update();
        }
    }
    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdate();
        }
    }

    public void TransitionToState(PlayerState newState)
    {
        //���� ���¿� ���ο� ���°� ���� Ÿ�� �� ���
        if(currentState?.GetType() == newState.GetType())
        {
            return;                     //���� Ÿ���̸� ���¸� ��ȯ ���� �ʰ� ����
        }

        //���� ���°� �����Ѵٸ� Exit �޼��带 ȣ��
        currentState?.Exit();    //�˻��ؼ� ȣ�� ���� (?)�� IF ����

        //���ο� ���·� ��ȯ
        currentState = newState;

        //���ο� ������ Enter �޼��� ȣ�� ( ���� ����)
        currentState.Enter();

        //�α׿� ���� ��ȯ ������ ���
        Debug.Log($"���� ��ȯ �Ǵ� ������Ʈ : {newState.GetType().Name}");


    }
}
