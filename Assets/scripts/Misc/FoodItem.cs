using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public HungerType hungerType = new HungerType();
    public enum HungerType {Food, Water};
    public float amountToAdd = 25f;


    public void DestroyObject() {
        Destroy(gameObject);
    }

    



}
