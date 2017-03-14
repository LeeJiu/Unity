using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoyAnim3 : MonoBehaviour
{

    private Animator charAnim;
    private AnimatorStateInfo animStateInfo;

    private float runFactor = 0.0f;
    private bool bMoveAble = true;

    public Transform tfAtkEfxPos;

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
        float InputH = Input.GetAxis("Horizontal");

        Vector3 moveSpeed = new Vector3(0.0f, 0.0f, InputV);

        if(moveSpeed != Vector3.zero || InputH != 0.0f)
        {
            if(moveSpeed.sqrMagnitude > 1.0f)
            {
                moveSpeed.Normalize();
            }

            MoveControl(moveSpeed, InputH, Input.GetKey(KeyCode.LeftShift));
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

    void MoveControl(Vector3 moveSpeed, float turn, bool run)
    {
        float target = run ? 1.0f : 0.5f;

        //runFactor 보간
        float dist = Mathf.Abs(target - runFactor);
        float delta = Time.deltaTime;
        float t = Mathf.Clamp01(delta / dist);

        runFactor = Mathf.Lerp(runFactor, target, t);

        //회전 / y축 = up 을 기준으로 회전한다.
        this.transform.Rotate(Vector3.up, turn);

        moveSpeed *= runFactor;

        float moveAmount = moveSpeed.magnitude;

        charAnim.SetFloat("MoveSpeed", moveAmount);

        if(moveAmount > 0.49f)
        {
            this.transform.Translate(moveSpeed * 3.0f * Time.deltaTime);
        }
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

    void AttackEffect(GameObject effect)
    {
        Object ob = Instantiate(effect, tfAtkEfxPos.position, Quaternion.identity);
        Destroy(ob, 1.0f);

        //타격 위치의 0.5 반경 안의 모든 콜리더를 가져온다.
        Collider[] cols = Physics.OverlapSphere(tfAtkEfxPos.position, 0.5f);

        for(int i = 0; i < cols.Length; ++i)
        {
            if(cols[i].gameObject.tag.CompareTo(this.gameObject.tag) == 0)
            {
                continue;
            }

            //때릴 수 있는 오브젝트라면
            HitAble hitAble = cols[i].gameObject.GetComponent<HitAble>();
            
            if(hitAble != null)
            {
                hitAble.HaveDamage(Random.Range(10.0f, 30.0f));
            }
        }
    }
}
