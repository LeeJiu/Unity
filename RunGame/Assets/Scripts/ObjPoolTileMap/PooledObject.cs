using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{
    public string strPoolName;
    public GameObject gPrefab;
    public int nPoolCount = 0;

    //오브젝트를 담을 직렬화된 공간
    [SerializeField]
    private List<GameObject> lPool = new List<GameObject>();

    public Transform tfParent;     //계층 구조의 부모가 될 변수

    public void Init(GameObject parent)
    {
        if(parent == null)
        {
            parent = new GameObject("ObjectPool");
        }

        tfParent = new GameObject(gPrefab.name + "_Pool").transform;
        tfParent.transform.SetParent(parent.transform);

        for(int i = 0; i < nPoolCount; ++i)
        {
            lPool.Add(CreateObject(tfParent));
        }
    }

    //사용한 오브젝트를 풀에 반환한다.
    public void PushObject(GameObject obj, Transform parent)
    {
        if(parent == null)
        {
            parent = tfParent;
        }

        obj.transform.SetParent(parent);
        obj.SetActive(false);
        lPool.Add(obj);
    }

    //사용할 오브젝트를 풀에서 꺼낸다.
    public GameObject PopObject(Transform parent)
    {
        //풀이 비어있으면 null 반환한다.
        if (lPool.Count == 0)
        {
            return null;
        }

        GameObject obj = lPool[0];  //반환할, 풀의 첫 번째 오브젝트를 저장한다.
        lPool.RemoveAt(0);          //첫 번째 오브젝트를 지운다.

        return obj;
    }

    GameObject CreateObject(Transform parent)
    {
        GameObject obj = Object.Instantiate(gPrefab) as GameObject;

        if (strPoolName == null)
        {
            strPoolName = gPrefab.name;
        }

        obj.name = strPoolName;
        obj.transform.SetParent(parent);
        obj.SetActive(false);

        return obj;
    }

    public int GetPoolSize()
    {
        return lPool.Count;
    }
}
