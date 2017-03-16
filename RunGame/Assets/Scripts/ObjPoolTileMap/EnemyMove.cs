using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float fMoveSpeed = 5.0f;

    void Update()
    {
        this.transform.Translate(0, 0, -fMoveSpeed * Time.deltaTime, Space.World);

        if (this.transform.position.z < -3.8f)
        {
            ObjectPool.Instance.PushToPool("Enemy", this.gameObject, null);
        }
    }
}
