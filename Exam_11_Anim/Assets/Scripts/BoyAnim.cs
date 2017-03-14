using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoyAnim : MonoBehaviour
{
    private Animator charAnim;
    private AnimatorStateInfo animStateInfo;

    private void Awake()
    {
        charAnim = this.GetComponent<Animator>();
    }

    void Update ()
    {
        animStateInfo = charAnim.GetCurrentAnimatorStateInfo(0);

        float InputV = Input.GetAxis("Vertical");

        charAnim.SetFloat("MoveSpeed", InputV); //이름으로 찾아서 값 저장

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(animStateInfo.IsName("Jump") == false)
            {
                charAnim.SetTrigger("Jump");
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(animStateInfo.IsName("Jump") == false)
            {
                charAnim.SetTrigger("Hit");
            }
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (animStateInfo.IsName("Jump") == false)
            {
                charAnim.SetTrigger("Punch");
            }
        }
	}
}
