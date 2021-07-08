using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColision : MonoBehaviour
{

    private bool isTouch = false;

    private PlayerAttack playerAttack;

    private PlayerMove playerMove;

    public int index;

    void Start()
    {
        if (isTouch) return;
        playerAttack = FindObjectOfType<PlayerAttack>();
        playerMove = FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isTouch) return;
        if (collision.CompareTag("Player"))
        {
            switch (index)
            {
                case 0://�⺻�Ѿ�
                    break;

                case 1: // ���ڳ�
                    playerAttack.attackPower = 3;
                    playerAttack.StartResetAttackPower();
                    break;

                case 2: // ����
                    playerMove.speed += 10f;
                    playerAttack.bulletDelay = 0.1f;
                    playerMove.StartResetSpeed();
                    playerAttack.StartResetBulletDelay();
                    break;

                case 3: // �θ���
                    playerMove.speed -= 25f;
                    playerAttack.bulletDelay = 1f;
                    playerMove.StartResetSpeed();
                    playerAttack.StartResetBulletDelay();
                    break;
            }
        }
    }
}  
