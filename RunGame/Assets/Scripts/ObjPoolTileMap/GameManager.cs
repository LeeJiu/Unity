using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float fTileInterval = 3.8f;  //타일 간격

    private Vector3 vLastTilePos;          //맨 마지막 타일 게임 오브젝트로 바꿔라
    private int nNumberOfTile;
    private int nObjCount = 0;

    void Awake()
    {
        nNumberOfTile = ObjectPool.Instance.GetPooledObject("Tile").nPoolCount;
        vLastTilePos = Vector3.zero;

        for(int i = 0; i < nNumberOfTile; ++i)
        {
            TileActive();
            vLastTilePos.z += fTileInterval;
        }
    }

    void Update()
    {
        TileActive();

        
    }

    //비활성화 되어있는 타일을 위치를 설정하고 활성화시킨다.
    void TileActive()
    {
        GameObject gNewTile = ObjectPool.Instance.PopFromPool("Tile", null);

        if (gNewTile == null) return;

        gNewTile.transform.position = vLastTilePos;

        gNewTile.SetActive(true);

        //활성화된 타일의 위치를 저장한다.
        vLastTilePos = gNewTile.transform.position;

        //타일이 활성화될 때 오브젝트도 세팅된다.
        //SetObject();
        //nObjCount++;
    }

    void SetObject()
    {
        if (nObjCount == 0) return;

        if(nObjCount % 3 == 0)
        {
            //방해물 놓는다.
            int nRnd = Random.Range(0, 9);
            if(nRnd < 3)
            {
                //곰

            }
            else if(nRnd > 5)
            {
                //슬라이드

            }
            else
            {
                //점프

            }
        }
        else
        {
            //코인 놓는다.

        }
    }
}
