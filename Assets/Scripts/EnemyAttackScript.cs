// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class EnemyAttackScript : MonoBehaviour
// {
//     [SerializeField] Transform player;
//     private NavMeshAgent agent;
//     private Animator animator;
//     [SerializeField] float attackRange = 2.0f;
//     [SerializeField] int damage = 10;

//     void Start()
//     {
//         agent = GetComponent<NavMeshAgent>();
//         animator = GetComponent<Animator>();
//     }

//     void Update()
//     {
//         float distance = Vector3.Distance(transform.position, player.position);

//         if (distance <= attackRange)
//         {
//             AttackPlayer();
//             agent.isStopped = true;
//             animator.SetBool("isChasing",false);
//         }
//         else
//         {
//             agent.SetDestination(player.position); // Chase if not in range
//             agent.isStopped = false;
//             animator.SetBool("isChasing",true);
//         }
//     }

//     void AttackPlayer()
//     {
//      // Stop moving when attacking
//         animator.SetBool("isAttacking",true);
//         Debug.Log("Enemy Attacks!");
//         // Call a method to deal damage to player
//     }
// }


using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackScript : MonoBehaviour
{
    [SerializeField] Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] float attackRange = 2.0f;
    [SerializeField] int damage = 10;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && !isAttacking)
        {
            AttackPlayer();
        }
        else if (distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("isChasing", true);
            animator.SetBool("isAttacking", false); // Ensure attack resets when chasing
        }
    }

    void AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true;
        agent.velocity = Vector3.zero; // Ensure no movement
        animator.SetBool("isChasing", false);
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        animator.SetBool("isAttacking", true);
        Debug.Log("Enemy Attacks!");

        yield return new WaitForSeconds(1.0f); // Adjust based on animation length

        isAttacking = false;
        animator.SetBool("isAttacking", false);

        agent.isStopped = false; // Resume movement after attack
    }
}
