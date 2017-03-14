using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAble : MonoBehaviour
{
    public GameObject gRagdoll;
    public float fHp = 100.0f;

    public void HaveDamage(float damage)
    {
        fHp -= damage;
        if(fHp <= 0.0f)
        {
            Destroy(this.gameObject);

            if(this.gRagdoll != null)
            {
                GameObject newRagdoll = 
                    Instantiate(gRagdoll, this.transform.position, this.transform.rotation) as GameObject;

                Destroy(newRagdoll, 20.0f);
            }
        }
    }
}
