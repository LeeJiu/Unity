using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer myRenderer;

    void Awake ()
    {
        myRenderer = this.GetComponent<Renderer>();
	}

    private void OnTriggerEnter(Collider other)
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);

        Color myColor = new Color(r, g, b);

        myRenderer.material.SetColor("_Color", myColor);
    }
}
