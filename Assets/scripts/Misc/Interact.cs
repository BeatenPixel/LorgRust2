using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactRange = 3f;
    private FoodItem fooditem;
    private Player player;
    public Camera FPSCamera;
    public bool debugRay = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update() {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if(debugRay == true) {
            Debug.DrawRay(ray.origin, ray.direction * interactRange, Color.yellow);
        }


        if(Input.GetKeyDown(KeyCode.E)){
            if (Physics.Raycast(ray, out hitInfo, interactRange)) {
                if (hitInfo.collider.tag == "FoodItem") {
                    fooditem = hitInfo.collider.GetComponent<FoodItem>();
                    if (fooditem.hungerType == FoodItem.HungerType.Food) {
                        player.AddHunger(fooditem.amountToAdd);
                        fooditem.DestroyObject();                  
                    } else if (fooditem.hungerType == FoodItem.HungerType.Water) {
                        player.AddThirst(fooditem.amountToAdd);
                        Destroy(fooditem.GetComponent<GameObject>());
                        fooditem.DestroyObject();
                    }
                }
            }
        }

    }
}
