using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float distance = 10.0f;

	void Update ()
    {
        float moveDelta = speed * Time.deltaTime;

        this.transform.Translate(0, 0, moveDelta);

        this.distance -= moveDelta;

        if(this.distance <= 0.0f)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
