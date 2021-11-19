using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] GameObject innerBar;
    [SerializeField] GameObject outerBar;
    [SerializeField] int maxHealth;
    private int currentHealth = 10;
    
    private float innerBarLength;

    void Start(){
        SetMaxHealth(maxHealth);
        Vector2 barlength = innerBar.transform.localScale;
        innerBarLength = barlength.x;
    }

    public void SetMaxHealth(int health) {
        maxHealth = health;
        Vector2 barlength = outerBar.transform.localScale;
        barlength.x = maxHealth;
        outerBar.transform.localScale = barlength;
    }

    //Sets current health and adjusts the health bar interface
    public void SetHealth(int health) {
        currentHealth = Mathf.Clamp(health, 0, maxHealth);

        float ratio = (float)currentHealth/maxHealth*innerBarLength;
        Vector2 barlength = innerBar.transform.localScale;
        barlength.x = ratio;
        innerBar.transform.localScale = barlength;

        float shift = -(innerBarLength - ratio)/2;
        Vector2 barposition = innerBar.transform.localPosition;
        barposition.x = shift;
        innerBar.transform.localPosition = barposition;

    }

    public void TakeDamage(int damage) {
        SetHealth(currentHealth-damage);
    }

}
