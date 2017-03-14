using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentTest : MonoBehaviour
{
    private NavMeshAgent agent;

    public GUIStyle guiStyle;
    public GameObject target;

    private void Awake()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            this.agent.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.agent.Resume();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            this.agent.ResetPath();
        }
        this.MoveOrder(this.target.transform.position);
    }

    public void MoveOrder(Vector3 worldPosition)
    {
        this.agent.SetDestination(worldPosition);
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.yellow;

        //진행 방향에 대한 라인
        Gizmos.DrawLine(
            this.transform.position,
            this.transform.position + this.agent.velocity
            );

        //경로의 코너 개수만큼 돈다.
        for(int i = 0; i < this.agent.path.corners.Length; ++i)
        {
            if(i == 0)
            {
                Gizmos.color = Color.white;
            }
            else
            {
                Gizmos.color = Color.black;
            }

            Gizmos.DrawSphere(
                this.agent.path.corners[i],
                1.0f
                );
        }
    }
}
