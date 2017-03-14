using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Animator anim;
    private AnimatorStateInfo aniInfo;

    public TouchPad movePad;

    public float fMoveSpeed = 5.0f;
    public float fRotSpeed = 45.0f;

    private int nKickDelay = 0;

	void Awake ()
    {
        anim = this.GetComponent<Animator>();	
	}
	

	void Update ()
    {
        aniInfo = anim.GetCurrentAnimatorStateInfo(0);
        
        if(aniInfo.IsName("Jump"))
        {
            anim.SetBool("Jump", false);
        }	

        if(nKickDelay > 0)
        {
            --nKickDelay;
        }

        if(nKickDelay == 0)
        {
            anim.SetBool("Kick 1", false);
            anim.SetBool("Kick 2", false);
            anim.SetBool("Kick 3", false);
        }

        anim.SetFloat("MoveSpeed", movePad.ControlDir.y * fMoveSpeed);

        this.transform.Translate(0.0f, 0.0f, movePad.ControlDir.y * Time.deltaTime * fMoveSpeed);
        this.transform.Rotate(Vector3.up, movePad.ControlDir.x * Time.deltaTime * fRotSpeed);

        print(movePad.ControlDir.y);
	}

    public void Jump()
    {
        anim.SetBool("Jump", true);
    }

    public void Kick()
    {
        nKickDelay = 50;

        anim.SetBool("Kick 1", true);

        if(aniInfo.IsName("Kick 1"))
        {
            anim.SetBool("Kick 2", true);
        }
        else if (aniInfo.IsName("Kick 2"))
        {
            anim.SetBool("Kick 3", true);
        }
    }
}
