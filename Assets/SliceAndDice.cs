using System;
using UnityEngine;

public class SliceAndDice : Skill {
    [SerializeField] private float dashDistance = 3.5f;
    [SerializeField] private float dashCooldown = 5f; // in seconds
    [SerializeField] private float invulnerabilityTime = 2f; // in seconds
    [SerializeField] private float dashTime = .1f; // in seconds
    private float timeUntilVulnerable = 0; // in seconds
    private float timeUntilAvailable = 0; // in seconds
    private float dashTranslationTime = 0; // in seconds
    private Vector2 dashDirection;
    private int dashCount = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash()) {
            if (dashCount > 0) {
                dashCount--;
            }

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dashDirection = new Vector2(mousePos.x - rb.position.x, mousePos.y - rb.position.y).normalized;
            InitiateDash();
        }

        if (timeUntilVulnerable > 0) {
            timeUntilVulnerable -= Time.deltaTime;
        } else {
            player.invulnerable = false;
        }

        if (timeUntilAvailable > 0) {
            timeUntilAvailable -= Time.deltaTime;
        }

        if (dashTranslationTime > 0 ) {
            dashTranslationTime -= Time.deltaTime;
        }
    }

    // user can dash if the time until available is 0 or they have a charge
    private bool CanDash() {
        return timeUntilAvailable <= 0 || dashCount > 0;
    }

    // make the player invulnerable and set the timers
    private void InitiateDash() {
        player.invulnerable = true;
        timeUntilVulnerable = invulnerabilityTime;
        timeUntilAvailable = dashCooldown;
        dashTranslationTime = dashTime;
    }

    void FixedUpdate() {
        if (dashTranslationTime > 0) {
            transform.Translate(dashDirection * Time.deltaTime * dashDistance / dashTime); // perform the dash
        }
    }

    public void AddDashCharges(int amount) {
        if (amount < 0) {
            throw new ArgumentOutOfRangeException("Dash charges amount must be a positive value");
        }

        dashCount += amount;
    }

    public void RemoveDashCharges(int amount) {
        if (amount < 0) {
            throw new ArgumentOutOfRangeException("Dash charges amount must be a positive value");
        }

        dashCount = Mathf.Max(dashCount - amount, 0); // cant let dash count be negative
    }

    public void SetDashCharges(int numCharges) {
        dashCount = Mathf.Max(numCharges, 0); // cant let dash count be negative
    }

    public int GetDashCharges() {
        return dashCount;
    }

    public float GetTimeUntilAvailable() {
        return timeUntilAvailable;
    }

    public float GetTimeUntilVulnerable() {
        return timeUntilVulnerable;
    }

}