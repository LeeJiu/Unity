using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    [Range(0, 10)]
    public float range = 5.0f;

    public LayerMask maskValue = -1;


	void Update ()
    {
        //반경 내에 들어온 콜라이더들은 전부 모아 넣어라.
        Collider[] cols = Physics.OverlapSphere(
            this.transform.position,
            this.range,
            this.maskValue.value
            );

        for(int i = 0; i < cols.Length; ++i)
        {
            Destroy(cols[i].gameObject);
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, this.range);
    }
}
