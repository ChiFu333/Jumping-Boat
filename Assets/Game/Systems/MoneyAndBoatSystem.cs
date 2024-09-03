using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAndBoatSystem : MonoBehaviour
{
    public int money = 0;
    public int maxFuel = 1000;
    public float acceleration = 0.2f;
    public int doubleJumpCount = 1;
    public static MoneyAndBoatSystem inst;
     private void Awake() {
        if (inst != null && inst != this) {
            Destroy(this);
        } else {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
