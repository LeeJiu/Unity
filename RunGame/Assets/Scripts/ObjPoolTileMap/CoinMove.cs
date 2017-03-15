using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    public bool bErase = false;
    public bool bMove = false;

    private float fAngle = 30.0f;

    public float fUpSpeed = 5.0f;
    public float fMoveSpeed = 5.0f;

    private void OnEnable()
    {
        bMove = true;
        bErase = false;
    }

    private void OnDisable()
    {
        Debug.Log("disable");
        bMove = false;
        bErase = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bErase = true;
            other.gameObject.GetComponent<CharacterInfo>().AddCoin();
            StartCoroutine("CoReturnToPool");
        }
    }

    private void Update()
    {
        if (bErase == true)
        {
            this.transform.Rotate(Vector3.up, fAngle);
            this.transform.Translate(0, fUpSpeed * Time.deltaTime, 0);
        }

        if(bMove == true)
        {
            this.transform.Translate(0, 0, -fMoveSpeed * Time.deltaTime);
        }
    }

    IEnumerator CoReturnToPool()
    {
        yield return new WaitForSeconds(0.8f);

        ObjectPool.Instance.PushToPool("Coin", this.gameObject, null);
    }
}
