using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleMove : MonoBehaviour
{
    public string fHurdleName;
    public float fMoveSpeed = 5.0f;
    public int nDamage = 5;

    void Update()
    {
        this.transform.Translate(0, 0, -fMoveSpeed * Time.deltaTime);

        if (this.transform.position.z < -3.8f)
        {
            ObjectPool.Instance.PushToPool(fHurdleName, this.gameObject, null);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterInfo>().Damaged(nDamage);
            ObjectPool.Instance.PushToPool(fHurdleName, this.gameObject, null);
        }
    }
}
