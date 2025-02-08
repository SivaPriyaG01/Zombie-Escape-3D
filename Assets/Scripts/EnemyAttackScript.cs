using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackScript : MonoBehaviour
{
    [SerializeField] Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] float attackRange = 2.0f;
    [SerializeField] int damage = 10;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            AttackPlayer();
            agent.isStopped = true;
        }
        else
        {
            agent.SetDestination(player.position); // Chase if not in range
            agent.isStopped = false;
        }
    }

    void AttackPlayer()
    {
     // Stop moving when attacking
        animator.SetTrigger("Attack");
        Debug.Log("Enemy Attacks!");
        // Call a method to deal damage to player
    }
}
