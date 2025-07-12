using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float detectionDistance = 5f;

    private Transform playerTransform;
    //public PlayerHealth playerHealth;


    private bool isHit = false;

    //private Animator animator;
    //private bool enemyRun = false;

    private bool canDamage = true;
    public float cooldownTime = 5f;
    private bool isPlayerHidden = false;

    private PatrolEnemy patrolScript;


    [Header("NavMesh")]
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] bool followPlayer;


    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        patrolScript = GetComponent<PatrolEnemy>();

        //playerHealth = FindObjectOfType<PlayerHealth>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isHit && !isPlayerHidden)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= detectionDistance && followPlayer)
            {
                FollowPlayer();
            }
        }
        else if (patrolScript != null)
        {
            patrolScript.Move();
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = playerTransform.position;
    }

    public void StopChasingAndWait()
    {
        followPlayer = false;
        isPlayerHidden = true;
        navMeshAgent.ResetPath(); // Detiene al enemigo
        navMeshAgent.isStopped = true;
    }

    public void ResumePatrolling()
    {
        isPlayerHidden = false;
        followPlayer = false;
        navMeshAgent.isStopped = false;

        if (patrolScript != null)
        {
            patrolScript.Move(); // Comienza a patrullar
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EnableDamageAfterCooldown());
            StartCoroutine(StunEnemy());
        }
    }

    IEnumerator StunEnemy()
    {
        isHit = true;
        yield return new WaitForSeconds(5f);
        isHit = false;
    }

    IEnumerator EnableDamageAfterCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(cooldownTime);
        canDamage = true;
    }
}
