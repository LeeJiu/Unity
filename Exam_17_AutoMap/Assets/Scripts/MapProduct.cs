using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProduct : MonoBehaviour
{
    enum E_DIR { START = 0, FRONT, LEFT, RIGHT,
    FTOLEFT, FTORIGHT, LTOFRONT, RTOFRONT, DIRMAX }

    public GameObject[] gMapType = new GameObject[(int)E_DIR.DIRMAX];

    int nMapX = 0;
    int nMapY = 0;

    E_DIR eCurrDir = E_DIR.START;
    Vector3 v3Pos;

	void Awake ()
    {
		for(int i = 0; i < 1000; ++i)
        {
            v3Pos = new Vector3(nMapX * 10, 0, nMapY * 10);
            GameObject gObj = 
                Instantiate(gMapType[(int)eCurrDir], v3Pos, Quaternion.identity);

            SetNextPos();
        }
	}

    void SetNextPos()
    {
        int nRand = Random.Range(0, 7);

        switch (eCurrDir)
        {
            case E_DIR.START: case E_DIR.FRONT:
            {
                ++nMapY;
                if (nRand == 0)
                {
                    eCurrDir = E_DIR.FTOLEFT;
                }
                else if (nRand == 1)
                {
                    eCurrDir = E_DIR.FTORIGHT;
                }
                else
                {
                    eCurrDir = E_DIR.FRONT;
                }
            }
                break;

            case E_DIR.FTOLEFT:
            {
                --nMapX;
                eCurrDir = E_DIR.LEFT;
            }
                break;

            case E_DIR.FTORIGHT:
            {
                ++nMapX;
                eCurrDir = E_DIR.RIGHT;
            }
                break;

            case E_DIR.LEFT:
            {
                --nMapX;
                if(nRand == 0 || nRand == 1)
                {
                    eCurrDir = E_DIR.LTOFRONT;
                }
            }
                break;

            case E_DIR.RIGHT:
            {
                ++nMapX;
                if (nRand == 0 || nRand == 1)
                {
                    eCurrDir = E_DIR.RTOFRONT;
                }
            }
                break;

            case E_DIR.LTOFRONT: case E_DIR.RTOFRONT:
            {
                ++nMapY;
                eCurrDir = E_DIR.FRONT;
            }
                break;
        }
    }
}
