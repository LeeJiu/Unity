using System.Collections;
using System.Collections.Generic;   //List 를 사용하기 위한 Using
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    //싱글톤
    private static WayPointManager sInstance;
    public static WayPointManager Instance
    {
        get
        {
            return sInstance;
        }
    }

    public List<WayPoint> ways;

    void Awake()
    {
        sInstance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < this.ways.Count; ++i)
            {
                this.ways[i].gameObject.SetActive(true);
            }
        }  
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        for(int i = 0; i < this.ways.Count; ++i)
        {
            for(int j = i+1; j < this.ways.Count; ++j)
            {
                Gizmos.DrawLine(
                    this.ways[i].transform.position,    //from
                    this.ways[j].transform.position     //to
                    );
            }
        }
    }
}
