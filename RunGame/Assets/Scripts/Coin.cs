using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Coin : MonoBehaviour
{
    private bool bErase = false;

    private float fAngle = 30.0f;
    private float fUpSpeed = 5.0f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            bErase = true;
            other.gameObject.GetComponent<CharacterInfo>().AddCoin();
            Destroy(this.gameObject, 0.8f);
        }
    }

    private void Update()
    {
        if(bErase == true)
        {
            this.transform.Rotate(Vector3.up, fAngle);
            this.transform.Translate(0, fUpSpeed * Time.deltaTime, 0);
        }
    }
}
