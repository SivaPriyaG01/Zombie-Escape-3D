// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class EnemyAI : MonoBehaviour
// {
//     public Transform player;  // Reference to the player
//     private NavMeshAgent agent;
//     private Animator animator;

//     void Start()
//     {
//         agent = GetComponent<NavMeshAgent>();
//         animator = GetComponent<Animator>();
//     }

//     void Update()
//     {
//         if (player != null)
//         {
//             agent.SetDestination(player.position);
//             animator.SetBool("isChasing",true); // Chase the player
//         }
//     }
// }


using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;  // Reference to the player
    private NavMeshAgent agent;
    private Animator animator;

    [SerializeField] private float attackRange = 2.0f;
    //[SerializeField] private float attackCooldown = 1.5f; // Delay between attacks
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return; // Prevent errors if player is missing

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && !isAttacking)
        {
           AttackPlayer();
        }
        else
        {
            ChasePlayer(); // Always chase, no range limit
        }
    }

    void ChasePlayer()
    {
        if (!isAttacking)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("isChasing", true);
            animator.SetBool("isAttacking", false);
        }
    }

    void AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true;
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", true);
        transform.LookAt(player); // Face the player before attacking

        Debug.Log("Enemy Attacks!");

        //yield return new WaitForSeconds(attackCooldown); // Wait for attack to finish

        isAttacking = false;
    }
}

