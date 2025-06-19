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
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private float stoppingDistance = 0.5f;

    private int currentWaypoint = 0;
 


    public void Patrol()
    {
      

        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) > stoppingDistance)
        {
            navMeshAgent.destination = waypoints[currentWaypoint].position;
            Debug.Log("moviendose");
        }
        else
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
     
        yield return new WaitForSeconds(waitTime);

        currentWaypoint++;


        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
    }
}

