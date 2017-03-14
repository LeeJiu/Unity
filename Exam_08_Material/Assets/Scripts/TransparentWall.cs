using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class TransparentWall : MonoBehaviour
{
    public Transform camTrans;

    private Camera cam;
    private Ray ray;
    private Color color;
    private GameObject hitObject;
    private Renderer renderMt;

    void Update ()
    {
        Vector3 dir = this.transform.position - this.camTrans.position;
        ray.origin = camTrans.position;
        ray.direction = dir;
        float distance = Vector3.Distance(this.transform.position, this.camTrans.position);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, distance))
        {
            if(hit.collider.gameObject.tag != "Player")
            {
                this.hitObject = hit.collider.gameObject;
                this.color = hitObject.GetComponent<Renderer>().material.color;
                color.a = 0.5f;
                hitObject.GetComponent<Renderer>().material.SetColor("_Color", color);
            }
        }
        

        if(hit.collider.gameObject.tag == "Player")
        {
            print("장애물 없니?");
            color.a = 1.0f;
            hitObject.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
	}
}
