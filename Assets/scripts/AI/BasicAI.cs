using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    public int health = 100;
    private NavMeshAgent agent;
    private Transform playerTransform;
    private bool isChasing = false;

    private void Start() {
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update() {
        if (isChasing == true)
            agent.SetDestination(playerTransform.position);
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider target) {
        if (target.tag == "Player")
        {
            playerTransform = target.transform;
            isChasing = true;
        }
        
    }
    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("Enemty took damage and now has" + health + "health!");
    }



}
