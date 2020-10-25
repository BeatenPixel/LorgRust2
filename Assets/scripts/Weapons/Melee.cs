using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {
    public int minDamage = 25;
    public int maxDamage = 50;
    public float weaponrange = 3.5f;


    public Camera FPSCamera;

    private TreeHealth treeHealth;
    private AdvancedEnemyAI enemyAI;
    private void Update() {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("1");
            if (Physics.Raycast(ray, out hitInfo, weaponrange)) {
                Debug.Log("2" + hitInfo.collider.gameObject.name + " " + hitInfo.collider.tag);
                if (hitInfo.collider.tag == "Tree") {
                    Debug.Log("3");
                    treeHealth = hitInfo.collider.GetComponentInParent<TreeHealth>();
                    AttackTree();

                } else if (hitInfo.collider.tag == "Enemy") {
                    enemyAI = hitInfo.collider.GetComponent<AdvancedEnemyAI>();
                    AttackEnemy();
                }
            }
        }
    }


    private void OnDrawGizmos() {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 100);
    }

    private void AttackTree() {
        Debug.Log("Hit Tree");
        int damage = Random.Range(minDamage, maxDamage);
        treeHealth.health -= damage;
    }

    private void AttackEnemy()
    {
    int damage = Random.Range(minDamage, maxDamage);
    enemyAI.TakeDamage(damage);
    }
}