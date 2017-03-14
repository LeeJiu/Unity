using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoyAnim2 : MonoBehaviour
{

    private Animator charAnim;
    private AnimatorStateInfo animStateInfo;

    private float runFactor = 0.0f;
    private bool bMoveAble = true;

    private void Awake()
    {
        charAnim = this.GetComponent<Animator>();
        charAnim.SetLayerWeight(1, 1.0f);
    }

    void Update()
    {
        animStateInfo = charAnim.GetCurrentAnimatorStateInfo(0);
        bMoveAble = animStateInfo.IsName("Idle") || animStateInfo.IsName("Move");

        float InputV = Input.GetAxis("Vertical");

        Vector3 moveSpeed = new Vector3(0.0f, 0.0f, InputV);

        if(moveSpeed != Vector3.zero)
        {
            if(moveSpeed.sqrMagnitude > 1.0f)
            {
                moveSpeed.Normalize();
            }

            MoveControl(moveSpeed, Input.GetKey(KeyCode.LeftShift));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (animStateInfo.IsName("Jump") == false)
            {
                charAnim.SetTrigger("Hit");
            }
        }

        if (bMoveAble)
        {
            charAnim.SetBool("Kick 0", false);
            charAnim.SetBool("Kick 1", false);
            charAnim.SetBool("Kick 2", false);

            charAnim.SetBool("Punch 0", false);
            charAnim.SetBool("Punch 1", false);
            charAnim.SetBool("Punch 2", false);
        }

        Attack();
    }

    void MoveControl(Vector3 moveSpeed, bool run)
    {
        float target = run ? 1.0f : 0.5f;

        //runFactor 보간
        float dist = Mathf.Abs(target - runFactor);
        float delta = Time.deltaTime;
        float t = Mathf.Clamp01(delta / dist);
        print(t);

        runFactor = Mathf.Lerp(runFactor, target, t);

        moveSpeed *= runFactor;

        float moveAmount = moveSpeed.magnitude;

        charAnim.SetFloat("MoveSpeed", moveAmount);
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            charAnim.SetBool("Kick 0", true);

            if(animStateInfo.IsName("Kick 0") == true)
            {
                charAnim.SetBool("Kick 1", true);
            }
            else if(animStateInfo.IsName("Kick 1") == true)
            {
                charAnim.SetBool("Kick 2", true);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            charAnim.SetBool("Punch 0", true);

            if (animStateInfo.IsName("Punch 0") == true)
            {
                charAnim.SetBool("Punch 1", true);
            }
            else if (animStateInfo.IsName("Punch 1") == true)
            {
                charAnim.SetBool("Punch 2", true);
            }
        }
    }
}
