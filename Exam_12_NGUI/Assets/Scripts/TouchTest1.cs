using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest1 : MonoBehaviour
{
    private Vector3 v3Start;
    private Vector3 v3Dest;

    private void Awake()
    {
        v3Start = v3Dest = this.transform.position;
    }

    void Update ()
    { 
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.transform.tag == "Ground")
            {
                v3Start = this.transform.position;
                v3Dest = hit.point;
                v3Dest.y = 0.5f;
            }           
        }

        if (this.transform.position != v3Dest)
        {
            this.transform.Translate((v3Dest - v3Start) / 10);
        }
    }

    void OnPress()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit) && hit.transform.tag == "Ground")
        {
            v3Start = this.transform.position;
            v3Dest = hit.point;
            v3Dest.y = 0.5f;
        }
    }
}
