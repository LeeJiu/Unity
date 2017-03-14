using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spRender;
    private Collider2D col2D;

    private bool bHit = false;
    private bool bColorChange = false;
    private float fColorLerp = 0.0f;

    public int nHp = 100;
    private float fAlphaLerp = 0.0f;

	void Awake ()
    {
        anim = this.GetComponent<Animator>();
        spRender = this.GetComponent<SpriteRenderer>();
        col2D = this.GetComponent<CircleCollider2D>();
        col2D.enabled = false;
	}
	

	void Update ()
    {
        if (bHit == true)
        {
            fColorLerp += 1.0f;
            if (Mathf.Abs(1.0f - fColorLerp) < 0.01f)
            {
                bHit = false;
            }
        }
        else if (bColorChange == true)
        {
            fColorLerp -= 0.1f;
            if (fColorLerp < 0.01f)
            {
                bColorChange = false;
            }
        }

        spRender.color =
            Color.Lerp(new Color(1.0f, 1.0f, 1.0f), new Color(1.0f, 0.0f, 0.0f), fColorLerp);

        if(nHp <= 0)
        {
            fAlphaLerp += 0.01f;
            anim.Stop();
            spRender.color = 
                Color32.Lerp(new Color32(255, 255, 255, 255), new Color32(255, 255, 255, 0), fAlphaLerp);
            Destroy(this.gameObject, 2.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && bHit == false && bColorChange == false
            && col2D.IsTouching(col) == false)  //내 공격 타이밍이 아닐 때
        {
            bHit = true;
            bColorChange = true;

            nHp -= Random.Range(10, 30);
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
}
