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
                case 0://기본총알
                    break;

                case 1: // 코코넛
                    playerAttack.attackPower = 3;
                    playerAttack.StartResetAttackPower();
                    // Debug.Log("공격력 증가");
                    break;

                case 2: // 망고
                    playerMove.speed += 10f;
                    playerAttack.bulletDelay = 0.1f;
                    playerMove.StartResetSpeed();
                    playerAttack.StartResetBulletDelay();
                    //Debug.Log("스피드 업");
                    break;

                case 3: // 두리안
                    playerMove.speed -= 25f;
                    playerAttack.bulletDelay = 1f;
                    playerMove.StartResetSpeed();
                    playerAttack.StartResetBulletDelay();
                    //Debug.Log("스피드 다운");
                    break;
            }
        }
    }
}  
