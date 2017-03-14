using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public GameObject HpBar;
    public float maxHp = 100.0f;
    public float curHp;
    public float damage = 10.0f;

    private Vector3 maxBar;

    private void Awake()
    {
        curHp = maxHp;
        maxBar = HpBar.transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        curHp -= damage;
        Debug.Log(curHp);
        if (curHp <= Mathf.Epsilon)
        {
            curHp = 0.0f;
        }

        float damageClamp = Mathf.Clamp01(curHp / maxHp);

        Vector3 damageVec = maxBar;
        damageVec.x *= damageClamp;
        HpBar.transform.localScale = damageVec;
    }
}
