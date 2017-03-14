using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private bool isOn;

    void Awake()
    {
        isOn = false;
        MeshRenderer quadRender = this.GetComponent<MeshRenderer>();
        quadRender.enabled = isOn;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isOn = !isOn;
            MeshRenderer quadRender = this.GetComponent<MeshRenderer>();
            quadRender.enabled = isOn;
        }  
    }
}
