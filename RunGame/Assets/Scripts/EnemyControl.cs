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

    public void Dead()
    {
        anim.SetTrigger("Dead");
        Destroy(this.gameObject, 1.2f);
    }

    void Attack()
    {
        anim.SetBool("Attack", true);
        Destroy(this.gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            Attack();
        }
    }
}
