using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public GameObject effect;

    public void CallButton()
    {
        GameObject gOb = 
            Instantiate(effect, this.transform.position, Quaternion.identity) as GameObject;

        Destroy(gOb, 1.0f);
    }
}
