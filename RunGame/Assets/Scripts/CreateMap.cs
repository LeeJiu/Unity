using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    //F = Front, L = Left, R = Right, T = To
    enum TILETYPE
    {
        START, FTL, FTR, LTF, RTF, TF, TL, TR, END
    }

    enum OBJTYPE
    {
        COIN, HURDLE_JUMP, HURDLE_SLIDE, ENEMY, NONE
    }

    //타일 길이 설정
    public int tileLength = 50;

    //타일 간격 설정
    public float tileInterval = 3.6f;

    //타일 타입
    public GameObject[] gTileType = new GameObject[(int)TILETYPE.END + 1];

    //타일 위에 놓일 오브젝트 타입
    public GameObject[] gObjType = new GameObject[(int)OBJTYPE.NONE];

    private TILETYPE eCurTile = TILETYPE.START; //맨 처음 타일은 무조건 시작 타일
    private TILETYPE ePreTile = TILETYPE.START; // Cur 이전 타일 타입
    private int nTileX = 0;
    private int nTileZ = 0;
    private Vector3 vPos;
    private GameObject[] gTile;
    private GameObject gObject;

    private OBJTYPE ePrevObj = OBJTYPE.NONE;

    void Awake()
    {
        gTile = new GameObject[tileLength];

        for (int i = 0; i < tileLength; ++i)
        {
            vPos = new Vector3(nTileX * tileInterval, 0, nTileZ * tileInterval);

            gTile[i] = Instantiate(gTileType[(int)eCurTile], vPos, Quaternion.identity) as GameObject;

            SetObject();

            if (i == tileLength - 1)
            {
                SetLastTile();
                break;
            }

            SetNextTile();
        }
    }

    void SetNextTile()
    {
        int nRnd = Random.Range(0, 7);

        ePreTile = eCurTile;

        switch (eCurTile)
        {
            case TILETYPE.START:
                ++nTileZ;
                eCurTile = TILETYPE.TF;
                break;

            case TILETYPE.FTL:
                --nTileX;
                eCurTile = TILETYPE.TL;
                break;

            case TILETYPE.TL:
                --nTileX;
                if (nRnd == 0)
                {
                    eCurTile = TILETYPE.LTF;
                }
                else
                {
                    eCurTile = TILETYPE.TL;
                }
                break;

            case TILETYPE.FTR:
                ++nTileX;
                eCurTile = TILETYPE.TR;
                break;

            case TILETYPE.TR:
                ++nTileX;
                if (nRnd == 0)
                {
                    eCurTile = TILETYPE.RTF;
                }
                else
                {
                    eCurTile = TILETYPE.TR;
                }
                break;

            case TILETYPE.LTF: case TILETYPE.RTF:
                ++nTileZ;
                eCurTile = TILETYPE.TF;
                break;

            case TILETYPE.TF:
                ++nTileZ;
                if (nRnd == 0)
                {
                    eCurTile = TILETYPE.FTL;
                }
                else if (nRnd == 1)
                {
                    eCurTile = TILETYPE.FTR;
                }
                else
                {
                    eCurTile = TILETYPE.TF;
                }
                break;
        }
    }

    void SetLastTile()
    {
        switch (eCurTile)
        {
            case TILETYPE.FTL: case TILETYPE.TL:
                print("FTL | TL");
                eCurTile = TILETYPE.END;
                --nTileX;
                vPos = new Vector3(nTileX * tileInterval, 0, nTileZ * tileInterval);
                gTile[tileLength - 1] = 
                    Instantiate(gTileType[(int)eCurTile], vPos, Quaternion.AngleAxis(-90.0f, Vector3.up)) as GameObject;
                break;

            case TILETYPE.FTR: case TILETYPE.TR:
                print("FTR | TR");
                eCurTile = TILETYPE.END;
                ++nTileX;
                vPos = new Vector3(nTileX * tileInterval, 0, nTileZ * tileInterval);
                gTile[tileLength - 1] = 
                    Instantiate(gTileType[(int)eCurTile], vPos, Quaternion.AngleAxis(90.0f, Vector3.up)) as GameObject;
                break;

            case TILETYPE.LTF: case TILETYPE.RTF: case TILETYPE.TF:
                print("LTF | RTF | TF");
                eCurTile = TILETYPE.END;
                ++nTileZ;
                vPos = new Vector3(nTileX * tileInterval, 0, nTileZ * tileInterval);
                gTile[tileLength - 1] = 
                    Instantiate(gTileType[(int)eCurTile], vPos, Quaternion.identity) as GameObject;
                break;
        }
    }

    void SetObject()
    {
        int rnd = Random.Range(0, 6);
        
        switch(eCurTile)
        {
            case TILETYPE.START: case TILETYPE.END:
                ePrevObj = OBJTYPE.NONE;
                break;

            case TILETYPE.FTL: case TILETYPE.FTR: case TILETYPE.LTF: case TILETYPE.RTF:
                SetCoin();
                break;

            case TILETYPE.TF: case TILETYPE.TL: case TILETYPE.TR:
                if (rnd == 0)
                {
                    if ((ePreTile == TILETYPE.TF || ePreTile == TILETYPE.TL || ePreTile == TILETYPE.TR)
                            && (ePrevObj == OBJTYPE.COIN))
                    {
                        SetEnemy();
                    }
                    else
                    {
                        SetCoin();
                    }
                }
                else if(rnd == 1 || rnd == 2)
                {
                    if ((ePreTile == TILETYPE.TF || ePreTile == TILETYPE.TL || ePreTile == TILETYPE.TR)
                            && (ePrevObj == OBJTYPE.COIN))
                    {
                        SetHurdle();
                    }
                    else
                    {
                        SetCoin();
                    }
                }
                else
                {
                    SetCoin();
                }
                break;
        }
    }

    void SetCoin()
    {
        ePrevObj = OBJTYPE.COIN;

        Vector3 pos = vPos;
        pos.y += 1.5f;

        switch (eCurTile)
        {
            case TILETYPE.FTL: case TILETYPE.FTR: case TILETYPE.TF: 
                gObject = Instantiate(gObjType[(int)ePrevObj], pos, Quaternion.identity) as GameObject;
                break;

            case TILETYPE.LTF: case TILETYPE.RTF: case TILETYPE.TL: case TILETYPE.TR:
                gObject = Instantiate(gObjType[(int)ePrevObj], pos, Quaternion.AngleAxis(90.0f, Vector3.up)) as GameObject;
                break;
        }
    }

    void SetHurdle()
    {
        int rnd = Random.Range(0, 2);

        if(rnd == 0)
        {
            ePrevObj = OBJTYPE.HURDLE_JUMP;
        }
        else
        {
            ePrevObj = OBJTYPE.HURDLE_SLIDE;
        }

        switch (eCurTile)
        {
            case TILETYPE.TF:
                gObject = Instantiate(gObjType[(int)ePrevObj], vPos, Quaternion.identity) as GameObject;
                break;

            case TILETYPE.TL: case TILETYPE.TR:
                gObject = Instantiate(gObjType[(int)ePrevObj], vPos, Quaternion.AngleAxis(90.0f, Vector3.up)) as GameObject;
                break;
        }
    }

    void SetEnemy()
    {
        ePrevObj = OBJTYPE.ENEMY;

        switch (eCurTile)
        {
            case TILETYPE.FTL: case TILETYPE.FTR: case TILETYPE.TF:
                gObject = Instantiate(gObjType[(int)ePrevObj], vPos, Quaternion.AngleAxis(180.0f, Vector3.up)) as GameObject;
                break;

            case TILETYPE.TL: case TILETYPE.TR:
                gObject = Instantiate(gObjType[(int)ePrevObj], vPos, Quaternion.AngleAxis(90.0f, Vector3.up)) as GameObject;
                break;
        }
    }
}
