using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float fDownSpeed = 2.0f;
    public float fTime = 3.0f;
    public float fWaitTime = 0.0f;

    private bool bDown = false;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            bDown = true;
            Destroy(this.gameObject, fTime);
        }
    }
  
    void Update()
    {
        if (bDown == false)
        {
            return;
        }

        //떨어지는데 대기 시간이 있다면
        if(fWaitTime >= 0.001f)
        {
            fWaitTime -= Time.deltaTime;
            return;
        }

        this.transform.Translate(0, -fDownSpeed * Time.deltaTime, 0);
    }
}
