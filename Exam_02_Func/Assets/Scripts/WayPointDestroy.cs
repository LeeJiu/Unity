using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointDestroy : MonoBehaviour
{
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Backspace))
        {
            if (WayPointManager.Instance.ways.Count == 0)
                return;

            int idx = Random.Range(0, WayPointManager.Instance.ways.Count);

            WayPoint delWay = WayPointManager.Instance.ways[idx];

            //그냥 delWay 만 하면 달려있는 스크립트만 지운다.
            Destroy(delWay.gameObject);     //delWay 의 게임 오브젝트를 지운다.
        }
	}
}
