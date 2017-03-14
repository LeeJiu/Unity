using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    public GameObject platform;
    public int platNum = 0;


    void Start()
    {
        for (int i = 0; i < platNum; i++)
        {
            Instantiate(platform, new Vector3(0, 0, i), Quaternion.identity);
        }
    }
}