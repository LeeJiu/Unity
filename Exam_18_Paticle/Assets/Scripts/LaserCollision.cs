using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public ParticleSystem laserHit;
    static private BoxCollider col;

    private void OnParticleCollision(GameObject other)
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        RaycastHit hit;

        //충돌한 박스의 콜라이더 가져온다.
        col = other.GetComponent<BoxCollider>();

        if (col.Raycast(ray, out hit, 1000.0f))
        {
            Vector3 vHit = hit.point;
            vHit.x -= 0.005f;

            laserHit.transform.position = vHit;
            laserHit.transform.rotation = Quaternion.LookRotation(hit.normal);
            laserHit.Emit(Random.Range(1, 3));

            col.size = new Vector3(col.size.x - 0.005f, col.size.y, col.size.z);
            col.center = new Vector3(col.center.x - 0.0025f, col.center.y, col.center.z);

            if(col.size.x < 0)
            {
                col.enabled = false;
            }
        }
    }
}
