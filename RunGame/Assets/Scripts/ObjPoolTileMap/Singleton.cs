using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T sInstance;

    public static T Instance
    {
        get
        {
            if(sInstance == null)
            {
                //첫 번째 활성 로드된 오브젝트 찾는다.
                sInstance = (T)FindObjectOfType(typeof(T));

                //없으면 만든다.
                if(sInstance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    sInstance = obj.AddComponent<T>();
                }
            }

            return sInstance;
        }
    }
}
