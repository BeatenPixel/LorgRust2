using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {
    public float weaponRange = 100f;
    public Camera FPSCamera;
    public int minimumDamage = 15;
    public int maximumDamage = 30;
    private AdvancedEnemyAI enemy;


    private void Update() {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.green);

        if (Input.GetKeyDown(KeyCode.Mouse0)) {

            if (Physics.Raycast(ray, out hitInfo, weaponRange)) {
                if (hitInfo.collider.tag == "Enemy") ;
                {
                    enemy = hitInfo.collider.GetComponent<AdvancedEnemyAI>();
                    enemy.TakeDamage(Damage());
                    Debug.Log("We attacked an Enemy!");
                }

            }
        }
    }   
    private int Damage() {
        return Random.Range(minimumDamage, maximumDamage);
    }



}
