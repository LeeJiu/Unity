using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float fTileInterval = 3.5f;  //타일 간격

    private GameObject gLastTile;       //마지막에 활성화된 타일을 저장
    private Vector3 vStartPos;
    private int nNumberOfTile;
    private int nObjCount = 0;

    void Awake()
    {
        nNumberOfTile = ObjectPool.Instance.GetPooledObject("Tile").nPoolCount;
        vStartPos = Vector3.zero;

        for(int i = 0; i < nNumberOfTile; ++i)
        {
            TileActive();
            vStartPos.z += fTileInterval;
        }
    }

    void Update()
    {
        vStartPos = gLastTile.transform.position;
        vStartPos.z += fTileInterval;
        TileActive();
    }

    //비활성화 되어있는 타일을 위치를 설정하고 활성화시킨다.
    void TileActive()
    {
        GameObject gNewTile = ObjectPool.Instance.PopFromPool("Tile", null);

        if (gNewTile == null) return;

        gNewTile.transform.position = vStartPos;

        gNewTile.SetActive(true);

        //활성화된 타일을 저장한다.
        gLastTile = gNewTile;

        //타일이 활성화될 때 오브젝트도 세팅된다.
        ObjectActive();
        nObjCount++;
    }

    void ObjectActive()
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
            GameObject gNewCoin = ObjectPool.Instance.PopFromPool("Coin", null);

            if (gNewCoin == null)
            {
                Debug.Log("No have available coin in coin pool.");
                return;
            }

            Vector3 pos = vStartPos;
            pos.y += 1.5f;
            gNewCoin.transform.position = pos;
            gNewCoin.SetActive(true);
        }
    }
}
