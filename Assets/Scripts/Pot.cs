using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject pot;
    private int health = 100;

    public void SetHealth(int hp) {
        health = hp;
        Debug.Log("hi");
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }

    void Update() {
        if (health <= 0) {
            Destroy(pot);
        }
    }

}
