using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private PlayerMove PlayerMove;
    private PlayerJump PlayerJump;
    private Animator animator;
    private SpriteRenderer sprite;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMove = player.GetComponentInChildren<PlayerMove>();
        PlayerJump = player.GetComponentInChildren<PlayerJump>();
    }
	
	// Update is called once per frame
	void Update () {
        if(PlayerJump.Ground == false)
        {
            if (PlayerMove.Flip == false)
            {
                sprite.flipX = false;
                Jump();
            }
            else
            {
                sprite.flipX = true;
                Jump();
            }
        }
        else if(PlayerMove.AnimationStart == true)
        {
            if (PlayerMove.Flip == false)
            {
                sprite.flipX = false;
                RightMove();
            }
            else
            {
                sprite.flipX = true;
                LeftMove();
            }
        }
        else
        {
            Stand();
        }

	}

    private void LeftMove() // 왼쪽으로 움직임
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") && PlayerJump.Ground == true)
        {
            animator.Play("Walk");
        }
    }

    private void RightMove() // 오른쪽으로 움직임
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") && PlayerJump.Ground == true)
        {
            animator.Play("Walk");
        }
    }

    private void Jump() // 점프
    {
            animator.Play("Jump");
    }

    private void Stand() // 제자리
    {
        animator.Play("Stand");
    }

}
