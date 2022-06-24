using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
     public GameObject player;
    private PlayerController playerController;

    public float detectRange;
    public float attackRange;
    public State enemyState;
    public float curHealth = 3;
    private bool playerDetected;

    public float sinkSpeed;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    public enum State
    {
        ALIVE, DYING, SINKING
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.isStopped = true;
    }

    void Update()
    {
        if (enemyState == State.ALIVE)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= detectRange)
            {
                navMeshAgent.SetDestination(player.transform.position);
                navMeshAgent.isStopped = false;
                playerDetected = true;
            }
            if (distance <= attackRange)
            {
                transform.LookAt(player.transform.position);
                navMeshAgent.isStopped = true;
                animator.SetBool("attack", true);
            }
            if (distance > attackRange && playerDetected)
            {
                navMeshAgent.SetDestination(player.transform.position);
                navMeshAgent.isStopped = false;
                animator.SetBool("attack", false);
            }
            if (navMeshAgent.isStopped)
                animator.SetBool("run", false);
            else
                animator.SetBool("run", true);
        }
        else if (enemyState == State.SINKING)
        {
            float sinkDistance = sinkSpeed * Time.deltaTime;
            transform.Translate(new Vector3(0, -sinkDistance, 0));
        }
    }

    public void Attacked(float damage)
    {
        if (enemyState == State.ALIVE)
        {
            curHealth -= damage;
            if (curHealth <= 0)
                Die();
        }
    }

    private void Die()
    {
        enemyState = State.DYING;
        navMeshAgent.isStopped = true;
        animator.SetTrigger("death");
    }

    private IEnumerator StartSinking()
    {
        yield return new WaitForSeconds(2.0f);
        navMeshAgent.enabled = false;
        enemyState = State.SINKING;
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    public void Attack()
    {
    }
}
