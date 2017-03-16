using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Animator anim;
    private AnimatorStateInfo animLayer0;

    private float fAngle = 30.0f;
    private float fUpSpeed = 5.0f;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update ()
    {
        animLayer0 = anim.GetCurrentAnimatorStateInfo(0);
        
        if(animLayer0.IsName("Up") == true)
        {
            this.transform.Rotate(Vector3.up, fAngle);
            this.transform.Translate(0, fUpSpeed * Time.deltaTime, 0);
        }
    }

    private void OnEnable()
    {
        this.GetComponent<CapsuleCollider>().isTrigger = false;
        anim.Play("Idle");
    }

    public void Dead()
    {
        anim.SetTrigger("Dead");
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        StartCoroutine("CoReturnToPool", 1.2f);
    }

    void Attack()
    {
        anim.SetBool("Attack", true);
        this.GetComponent<CapsuleCollider>().isTrigger = true;
        StartCoroutine("CoReturnToPool", 1.5f);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            Attack();
        }
    }

    IEnumerator CoReturnToPool(float time)
    {
        yield return new WaitForSeconds(time);

        ObjectPool.Instance.PushToPool("Enemy", this.gameObject, null);
    }
}
