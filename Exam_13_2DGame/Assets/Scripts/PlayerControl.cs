using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spRender;
    private Collider2D col2D;

    private bool bMove = false;
    private float fMoveSpeed = 2.0f;
    private bool bJump = false;
    private float fJumpPower = 3.0f;

    private bool bHit = false;
    private bool bColorChange = false;
    private float fColorLerp = 0.0f;

    public GameObject gEffect;
    public Transform tfEfxPosL;
    public Transform tfEfxPosR;


    void Awake ()
    {
        anim = this.GetComponent<Animator>();
        spRender = this.GetComponent<SpriteRenderer>();
        col2D = this.GetComponent<CircleCollider2D>();
        col2D.enabled = false;   
	}

    private void Update()
    {
        //Attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Attack", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("Attack", false);
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && bJump == false)
        {
            bJump = true;
        }

        //Move
        if (bMove == true)
        {
            anim.SetFloat("MoveSpeed", fMoveSpeed);
        }
        else
        {
            anim.SetFloat("MoveSpeed", 0.0f);
        }

        if(bHit == true)
        {
            fColorLerp += 1.0f;
            if(Mathf.Abs(1.0f - fColorLerp) < 0.01f)
            {
                bHit = false;
            }
        }
        else if(bColorChange == true)
        {
            fColorLerp -= 0.1f;
            if(fColorLerp < 0.01f)
            {
                bColorChange = false;
            }
        }

        spRender.color = 
            Color.Lerp(new Color(1.0f, 1.0f, 1.0f), new Color(1.0f, 0.0f, 0.0f), fColorLerp);
    }

	void FixedUpdate ()
    {
        //Move
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * fMoveSpeed * Time.deltaTime);
            spRender.flipX = true;  //x방향으로 뒤집힌다.
            bMove = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right* fMoveSpeed * Time.deltaTime);
            spRender.flipX = false;
            bMove = true;
        }
        else
        {
            bMove = false;
        }      

        //Jump
        if (bJump == true)
        {
            this.transform.Translate(Vector3.up * fJumpPower * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(bJump == true && col.transform.tag == "Ground")
        {
            bJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy" && bHit == false && bColorChange == false 
            && col2D.IsTouching(col) == false)  //내 공격 타이밍이 아닐 때
        {
            bHit = true;
            bColorChange = true;
        }
    }

    public void EnableAttackCollider()
    {
        col2D.enabled = true;
    }

    public void DisableAttackCollider()
    {
        col2D.enabled = false;
    }

    public void StartEffect()
    {
        if(gEffect != null)
        {
            GameObject gTemp = null;

            if(spRender.flipX && tfEfxPosL)
            {
                gTemp = Instantiate(gEffect, tfEfxPosL.position, Quaternion.identity);
            }
            else if(tfEfxPosR)
            {
                gTemp = Instantiate(gEffect, tfEfxPosR.position, Quaternion.identity);
            }

            Destroy(gTemp, 2.0f);
        }
    }
}
