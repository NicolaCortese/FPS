using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float provokedDistance = 10f;
    [SerializeField] float turnSpeed = 5f;
     float distanceToTarget = Mathf.Infinity;
     
     NavMeshAgent navMeshAgent;
     EnemyHealth enemyHealth;
     Collider capsuleCollider;
     bool isProvoked = false;
     


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
        enemyHealth = GetComponent<EnemyHealth>(); 
        capsuleCollider = GetComponent<Collider>();
    }


    void Update()
    {   
        if(enemyHealth.isDead){
            enabled = false;
            navMeshAgent.enabled = false;
            capsuleCollider.enabled = false;
            }

        distanceToTarget = Vector3.Distance(target.position,transform.position);

        if(isProvoked){
            EngageTarget();
        }
        else if (distanceToTarget<=provokedDistance){
            isProvoked = true;
        }
        
        
    }

    public void OnDamageTaken(){
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget>=navMeshAgent.stoppingDistance){
            GetComponent<Animator>().SetBool("Attack",false);
            ChaseTarget();
        }
        if (distanceToTarget<=navMeshAgent.stoppingDistance){
            AttackTarget();
        }
    }

    private void ChaseTarget(){
        if(navMeshAgent.enabled){
        navMeshAgent.SetDestination(target.position);
        GetComponent<Animator>().SetTrigger("Move");        
        }
    }

    private void AttackTarget(){
        GetComponent<Animator>().SetBool("Attack",true);
        
    }

    private void FaceTarget(){
        Vector3 direction = (target.position-transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected(){        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, provokedDistance);
    }
}
