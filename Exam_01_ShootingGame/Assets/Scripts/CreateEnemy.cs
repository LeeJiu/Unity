using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateEnemy : MonoBehaviour
{
    public GameObject prefab;
    public int gridX = 2;
    public float spacing = 5.0f;

    void Start()
    {
        for (int x = -gridX; x < gridX; ++x)
        {
            Vector3 pos = new Vector3(x, 2, 35) * spacing;
            Instantiate(prefab, pos, Quaternion.Euler(0, 180, 0));
        }
    }
}
