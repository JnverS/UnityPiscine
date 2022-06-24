using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private bool mouseUp;
    [HideInInspector] public EnemyController enemyController;
    [HideInInspector] public bool enemySet;
    [HideInInspector] public GameObject enemy;
    public float attackRange;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = 100.0f;
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                _agent.SetDestination(hit.point);
                _agent.isStopped = false;
                if (hit.transform.tag == "Enemy")
                {
                    enemySet = true;
                    mouseUp = false;
                    enemy = hit.transform.gameObject;
                    enemyController = enemy.GetComponent<EnemyController>();
                }
                else
                    enemySet = false;
            }
        }
        else if (Input.GetMouseButtonUp(0))
            mouseUp = true;

        if (enemySet)
            distance = Vector3.Distance(enemy.transform.position, transform.position);
        if (enemySet && distance <= attackRange)
        {
            Vector3 enemyPosition = new Vector3(enemy.transform.position.x, transform.position.y,
                enemy.transform.position.z);
            transform.LookAt(enemyPosition);
            _agent.isStopped = true;
            if (enemyController.enemyState == EnemyController.State.ALIVE)
            {
                _animator.SetTrigger("attack");
                if (mouseUp == true)
                    enemySet = false;
            }
        }
        if (!enemySet && _agent.remainingDistance <= 1.0f)
        {
            _agent.isStopped = true;
        }
            
        if (_agent.isStopped)
            _animator.SetBool("run", false);
        else
            _animator.SetBool("run", true);
    }

    public void Attack()
    {
        if (enemyController.enemyState == EnemyController.State.ALIVE)
        {
            enemyController.Attacked(1f);
        }
        else
            enemySet = false;
    }
    
}
