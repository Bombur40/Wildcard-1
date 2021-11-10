using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Healthbar healthBar;
    private int currentHealth;
    private int goldBalance = 0;
    private List<Item> items;
    public bool invulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        if (damage < 0) {
            throw new ArgumentOutOfRangeException("Damage amount must be a positive value");
        }

        if (!invulnerable) {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void Heal(int amount) {
        if (amount < 0) {
            throw new ArgumentOutOfRangeException("Healing amount must be a positive value");
        }

        currentHealth += amount;
    }

    public int GetCurrentHealth() {
        return currentHealth;
    }

    public int GetMaxHealth() {
        return maxHealth;
    }

    public int GetGoldBalance() {
        return goldBalance;
    }

    public void AddGold(int amount) {
        if (amount < 0) {
            throw new ArgumentOutOfRangeException("Gold amount must be a positive value");
        }

        goldBalance += amount;
    }

    public void RemoveGold(int amount) {
        if (amount < 0) {
            throw new ArgumentOutOfRangeException("Gold amount must be a positive value");
        }

        goldBalance -= amount;
    }
}
