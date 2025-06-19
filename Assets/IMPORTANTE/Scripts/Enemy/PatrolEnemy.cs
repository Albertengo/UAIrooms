using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{

    //public Transform[] patrolPoints;
    //public int targetPoint;
    //public float speed;


    //private void Start()
    //{
    //    targetPoint = 0;
    //}

    //private void Update()
    //{
    //    if (transform.position == patrolPoints[targetPoint].position) 
    //    {
    //        ChangeTarget();
    //    }
    //    transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    //}

    //private void ChangeTarget()
    //{
    //    targetPoint++;

    //    if (targetPoint >= patrolPoints.Length)
    //    {
    //        targetPoint = 0;
    //    }
    //}
    public Transform[] waypoints;         // Lista de puntos de patrulla
    public float waitTime = 2f;           // Tiempo de espera en cada punto

    private NavMeshAgent agent;           // Referencia al NavMeshAgent
    private int currentWaypoint = 0;      // Índice del waypoint actual
    private bool isWaiting = false;       // Estado de espera

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    public void Move()
    {
        if (!isWaiting && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(WaitAndMove());
        }
    }

    IEnumerator WaitAndMove()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);

        // Avanza al siguiente waypoint
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;

        // Mover al siguiente destino
        agent.SetDestination(waypoints[currentWaypoint].position);

        isWaiting = false;
    }
}

