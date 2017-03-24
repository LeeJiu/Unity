using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffects : MonoBehaviour
{
    public Transform tfAtkTrans;
    public string targetTag;
    public float fAtkRange = 0.25f;
    public int nDamage = 5;


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
                    cols[i].gameObject.GetComponent<CharacterInfo>().Damaged(nDamage);
                }

                //effect
                GameObject obj = ObjectPool.Instance.PopFromPool("Effect", null);
                obj.transform.position = tfAtkTrans.position;
                obj.SetActive(true);

                StartCoroutine(CoReturnToPool(1.0f, obj));

                break;
            }
        }
    }

    IEnumerator CoReturnToPool(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);

        ObjectPool.Instance.PushToPool("Effect", obj, null);
        Debug.Log("return to pool");
    }
}
