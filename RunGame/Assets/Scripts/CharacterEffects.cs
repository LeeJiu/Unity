using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
    public Transform tfAtkTrans;
    public string targetTag;
    public float fAtkRange = 0.25f;


    //============Events============
    void AttackEffect(GameObject efx)
    {
        Collider[] cols = Physics.OverlapSphere(tfAtkTrans.position, fAtkRange);

        for(int i = 0; i < cols.Length; ++i)
        {
            if(cols[i].gameObject.tag == targetTag)
            {
                if(targetTag == "Enemy")
                {
                    if (cols[i].isTrigger == true)
                    {
                        break;
                    }

                    //damage
                    cols[i].gameObject.GetComponent<EnemyControl>().Dead();
                }
                else if(targetTag == "Player")
                {
                    //damage
                    cols[i].gameObject.GetComponent<CharacterInfo>().Damaged(10);
                }

                //effect
                Object obj = Instantiate(efx, tfAtkTrans.position, Quaternion.identity);
                Destroy(obj, 1.5f);

                break;
            }
        }
    }
}
