using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform player;

    public LayerMask Player, Ground;

    //patrol variables
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking variables
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //to manage states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackrange;

    //Health vars
    public float health;
    private float maxHealth;
    public TextMeshPro HealthTracker;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        

    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
        playerInAttackrange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (!playerInSightRange && !playerInAttackrange)
        {
            Patrol();
        }
        if (playerInSightRange && !playerInAttackrange)
        {
            Chase();
        }
        if (playerInAttackrange)
        {
            Attack();
        }
        HealthTracker.text = "Health:" + health;
        healthBar.fillAmount = health / maxHealth;
    }

    private void Patrol()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkpoint = transform.position - walkPoint;

        //once at walkpoint
        if(distanceToWalkpoint.magnitude < 1f) 
        {
            walkPointSet = false;
        }
        Debug.Log("Patrol");

    }
    private void Chase()
    {
        agent.SetDestination(player.position);
        Debug.Log("Chase");
    }
    private void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            
            Debug.Log("attack here");
            //Attack mechanics here--- Probably need to get child weapon and call shooting function from there.
            alreadyAttacked = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }

    private void SearchWalkPoint()
    {
        //Find random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint,-transform.up, 2f, Ground))
        {
            walkPointSet = true;
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);

        if (health <= 0)
        {
            DisplayManager.EnemiesLeft -= 1;
            Invoke("DestroyEnemy", .5f);
        }
    }
}
