using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private Transform myTrans;

    void Start()
    {
        //웨이포인트 매니저 List에 접근하여 나를 등록
        WayPointManager.Instance.ways.Add(this);

        //나의 부모(하이어라키) 설정
        this.transform.SetParent(WayPointManager.Instance.transform);
    }

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
        }
	}

    void Reset()
    {
        this.myTrans = this.transform;
    }

    void OnDestroy()
    {
        WayPointManager.Instance.ways.Remove(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(
            this.transform.position,
            1.0f
            );
    }
}
