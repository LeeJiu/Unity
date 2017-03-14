using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(NavAgentTest))]
public class NavAgentClickMove : MonoBehaviour
{
    private NavAgentTest navAgentTest;

    private void Awake()
    {
        this.navAgentTest = this.GetComponent<NavAgentTest>();
    }

	void Update ()
    {
		if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                this.navAgentTest.MoveOrder(hit.point);
            }
        }
	}
}
