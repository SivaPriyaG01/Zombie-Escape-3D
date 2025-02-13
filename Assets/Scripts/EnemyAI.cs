using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player;  // Reference to the player
    private NavMeshAgent agent;
    private Animator animator;
    private List<string> animationStates = new List<string> {"isPunching","isKicking","isBiting"};

    [SerializeField] private float attackRange = 2.0f;
    //[SerializeField] private float attackCooldown = 1.5f; // Delay between attacks
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
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
            animator.SetBool("isPunching", false);
            animator.SetBool("isKicking", false);
            animator.SetBool("isBiting", false);

        }
    }

    void AttackPlayer()
    {
        isAttacking = true;
        agent.isStopped = true;
        animator.SetBool("isChasing", false);

        int randomIndex = UnityEngine.Random.Range(0, animationStates.Count);
        animator.SetBool(animationStates[randomIndex], true);
        transform.LookAt(player); // Face the player before attacking

        

        //yield return new WaitForSeconds(attackCooldown); // Wait for attack to finish

        isAttacking = false;
    }
}

