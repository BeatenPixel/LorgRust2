using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdvancedEnemyAI : MonoBehaviour {
    public int health = 100;
    public float viewRange = 25f;
    public float attackRange = 5f;
    public float eyeHeight;
    public float thinkTimer = 5f;
    public float randomUnitCircleRadius = 25f;
    public bool isAttacking = false;
    public float attackTime = 1f;
    public float distanceToPlayer;
    public float distanceToAttack = 1.8f;
    public RaycastHit hitInfo;
    public Ray ray;
    
    private float attackTimeStart;
    private float thinkTimerMin = 5f;
    private float thinkTimerMax = 15f;
    public bool isChasing = false;
    public Transform playerTransform;
    public Transform playerTransformDist;
    private NavMeshAgent agent;
    private Player player;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        thinkTimer = Random.Range(thinkTimerMin, thinkTimerMax);
        attackTimeStart = attackTime;
        playerTransformDist = GameObject.FindGameObjectWithTag("Player").transform;
        
    
    }

    private void Update() {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransformDist.position);
        
        Vector3 eyePosition = new Vector3(transform.position.x, transform.position.y + eyeHeight, transform.position.z);
        
        ray = new Ray(eyePosition, transform.forward);

        CheckHealth();

        if (distanceToPlayer <= distanceToAttack && isChasing == true) {
            isAttacking = true;
        }

        if(isAttacking == true) {
            attackTime -= Time.deltaTime;
        }

        if (attackTime <= 0) {
            Attack();
            attackTime = attackTimeStart;
        }

    thinkTimer -= Time.deltaTime;
        if(thinkTimer <= 0) {
            Think();
            thinkTimer = Random.Range(thinkTimerMin, thinkTimerMax);
        }

        if (Physics.Raycast(ray, out hitInfo, viewRange)) {

            if (hitInfo.collider.tag == "Player") {
                if (isChasing == false) {
                    isChasing = true;
                    
                    if(playerTransform == null) {
                        playerTransform = hitInfo.collider.GetComponent<Transform>();
                    }

                }
            }

        }

        Debug.DrawRay(ray.origin, ray.direction * viewRange);

        if (isChasing == true) 
        {
            _ = agent.SetDestination(playerTransform.position);
        
            
        
        }

    }

    public void TakeDamage(int damage) {

        health -= damage;
       
        if(playerTransform != null) {
            isChasing = true;
        }
        
        Debug.Log("Enemy took damage and now has" + health + " health!");
    }
    private void CheckHealth() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
    private void Think() {
        if (isChasing == false) ;
        Vector3 newPos = transform.position + new Vector3(Random.insideUnitCircle.x * randomUnitCircleRadius, transform.position.y, Random.insideUnitCircle.y * randomUnitCircleRadius);
        agent.SetDestination(newPos);
    

    }
        
    private void Attack() {
        if(distanceToPlayer <= distanceToAttack) {
            if (Physics.Raycast(ray, out hitInfo, attackRange)) {
                if(hitInfo.collider.tag == "Player") {

                }
            }
        }
    }
}