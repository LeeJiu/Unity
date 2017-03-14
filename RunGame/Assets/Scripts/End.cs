using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            coll.gameObject.GetComponent<CharacterControl>().Clear();
        }
    }
}
