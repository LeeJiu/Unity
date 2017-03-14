using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BulletLine : MonoBehaviour
{
    private LineRenderer lineRenderer;


    private void Awake()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
    }

    public void SetPos(Vector3 startPos, Vector3 endPos)
    {
        //lineRenderer 의 포지션을 세팅
        this.lineRenderer.SetPosition(0, startPos);
        this.lineRenderer.SetPosition(1, endPos);
    }
}
