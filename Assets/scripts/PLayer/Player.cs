using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

   public GameObject deathCanvas;
   
    public Vector3 spawnPoint = Vector3.zero;
    public float health = 100f;
    public float hunger = 100f;
    public float thirst = 100f;

    public Image healthBar;
    public Image hungerBar;
    public Image thirstBar;
    public float hungerSpeedMultiplier = 0.10f;
    public float thirstSpeedMultiplier = 0.25f;
    public float healthSpeedMultiplier = 0.25f;
    private bool isDying = false;


    private void Update () 
        {
            CheckDeath();
        
        if(hunger > 0) {
            hunger -= Time.deltaTime * hungerSpeedMultiplier;
        }
        if (thirst > 0) {
            thirst -= Time.deltaTime * thirstSpeedMultiplier;
        }
        if(hunger <= 0 || thirst <= 0) {
            isDying = true;
        } else {
            isDying = false;
        }
        if (isDying == true){
            health -= Time.deltaTime * healthSpeedMultiplier;
        }
        if(hunger > 100) {
            hunger = 100f;
        }

        if(thirst > 100) {
            thirst = 100f;
        }

        healthBar.fillAmount = health / 100;
        hungerBar.fillAmount = hunger / 100;
        thirstBar.fillAmount = thirst / 100;
    }

    private void Start() 
        {
        deathCanvas.SetActive(false);
    }

    private void CheckDeath() 
    {
        if (health <= 0)
        {
            Die();
        }

    }
    private void Die() {
        deathCanvas.SetActive(true);
    } 
    
    public void Respawn() {
        hunger = 100;
        thirst = 100;
        health = 100;
        deathCanvas.SetActive(false);
        transform.position = spawnPoint;
    }
   public void AddHunger(float amount) {
        hunger += amount;
    } 
   public void AddThirst(float amount) {
        thirst += amount;
    }
    public void AttackPlayer(float amount) {
        health -= amount;
    }

}
