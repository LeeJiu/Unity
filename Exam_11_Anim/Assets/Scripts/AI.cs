using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class AI : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private Animator anim;
    private AnimatorStateInfo aniInfo;

    public Transform tfAtkPos;

    private int rndNum;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        rndNum = Random.Range(0, 100);
    }

    void Update ()
    {
        aniInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (target == null)
        {
            anim.SetBool("Kick 0", false);
            anim.SetBool("Kick 1", false);
            anim.SetBool("Kick 2", false);

            anim.SetBool("Punch 0", false);
            anim.SetBool("Punch 1", false);
            anim.SetBool("Punch 2", false);

            anim.SetFloat("MoveSpeed", 0.0f);
            return;
        }

        float fDist = Vector3.Distance(target.transform.position, this.transform.position);

        if (fDist > 2.0f)
        {
            agent.SetDestination(target.transform.position);
            anim.SetFloat("MoveSpeed", agent.speed);

            anim.SetBool("Kick 0", false);
            anim.SetBool("Kick 1", false);
            anim.SetBool("Kick 2", false);

            anim.SetBool("Punch 0", false);
            anim.SetBool("Punch 1", false);
            anim.SetBool("Punch 2", false);

            rndNum = Random.Range(0, 1);
        }
        else
        {
            if(rndNum < 50)
            {
                anim.SetBool("Kick 0", true);

                if (aniInfo.IsName("Kick 0") == true)
                {
                    anim.SetBool("Kick 1", true);
                }
                else if (aniInfo.IsName("Kick 1") == true)
                {
                    anim.SetBool("Kick 2", true);
                }
            }
            else
            {
                anim.SetBool("Punch 0", true);

                if (aniInfo.IsName("Punch 0") == true)
                {
                    anim.SetBool("Punch 1", true);
                }
                else if (aniInfo.IsName("Punch 1") == true)
                {
                    anim.SetBool("Punch 2", true);
                }
            }

            //타격 위치의 0.5 반경 안의 모든 콜리더를 가져온다.
            Collider[] cols = Physics.OverlapSphere(tfAtkPos.position, 0.5f);

            for (int i = 0; i < cols.Length; ++i)
            {
                if (cols[i].gameObject.tag.CompareTo(this.gameObject.tag) == 0)
                {
                    continue;
                }

                //때릴 수 있는 오브젝트라면
                HitAble hitAble = cols[i].gameObject.GetComponent<HitAble>();

                if (hitAble != null)
                {
                    hitAble.HaveDamage(Random.Range(10.0f, 30.0f));
                }
            }
        }
    }
}
