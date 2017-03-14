using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//싱글톤
public class ObjectPoolTest : MonoBehaviour
{
    private static ObjectPoolTest sInstance;
    public static ObjectPoolTest Instance
    {
        get
        {
            if(sInstance == null)
            {
                GameObject newObj = new GameObject("_ObjectPoolTest");
                sInstance = newObj.AddComponent<ObjectPoolTest>();
            }

            return sInstance;
        }
    }

    public GameObject gParent;

    public GameObject gPrefab;         //오브젝트 프리팹
    public int nNumberOfObj = 5;       //풀에 담을 오브젝트 개수

    public List<GameObject> lObjPool;  //오브젝트를 담을 리스트로된 풀

    public int nLastActIdx = -1;       //가장 마지막에 활성화된 오브젝트의 인덱스 번호


    void Awake()
    {
        sInstance = this;

        if(gParent == null)
        {
            gParent = new GameObject(gPrefab.name + "_Parent");
        }

        for(int i = 0; i < nNumberOfObj; ++i)
        {
            GameObject gNewObj = Instantiate(gPrefab) as GameObject;

            gNewObj.transform.parent = gParent.transform;

            gNewObj.SetActive(false);

            lObjPool.Add(gNewObj);
        }
    }

    public GameObject GetPooledObj()
    {
        for(int i = 0; i < lObjPool.Count; ++i)
        {
            //활성화가 되어 있지 않은 오브젝트를 반환한다.
            if(lObjPool[i].activeInHierarchy == false)
            {
                nLastActIdx = i;
                if(nLastActIdx == -1)
                {
                    nLastActIdx = lObjPool.Count - 1;
                }
                return lObjPool[i];
            }
        }

        //오브젝트가 모두 활성화되어 있기 때문에 반환할 오브젝트가 없으므로 null 반환한다.
        return null;
    }

    public Vector3 GetLastPosition()
    {
        return lObjPool[nLastActIdx].transform.position;
    }
}
