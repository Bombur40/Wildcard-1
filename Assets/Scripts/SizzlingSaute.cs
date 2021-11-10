using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizzlingSaute : Skill
{

    [SerializeField] private float distanceFromPlayer; // how far out from the player the pan is being held
    [SerializeField] private GameObject panPrefab;
    private GameObject pan;

    void Start() {
        pan = Instantiate(panPrefab, Vector3.zero, Quaternion.identity, transform);
        pan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rawPanDirection = new Vector2(mousePos.x - rb.position.x, mousePos.y - rb.position.y);
            Vector2 panDirection = RoundTo45Deg(rawPanDirection);

            Quaternion panRotation = Quaternion.Euler(0, 0, GetAngleDeg(panDirection) - 90);
            Vector2 panPosition = (Vector2) transform.position + panDirection * distanceFromPlayer;

            if (!pan.activeSelf) {
                pan.SetActive(true);
            }

            pan.transform.SetPositionAndRotation(panPosition, panRotation);
        } else if (pan.activeSelf) {
            pan.SetActive(false);
        }
    }

    void FixedUpdate() {
        
    }

    // takes a vector and rounds it to the nearest 45 degree angle
    private Vector2 RoundTo45Deg(Vector2 direction) {
        float angle = GetAngle(direction);
        float roundedAngle = Mathf.Round(angle / Mathf.PI * 4) * Mathf.PI / 4; // rounds to the nearest 45deg angle (b/c 8 directions)

        float x = Mathf.Cos(roundedAngle);
        float y = Mathf.Sin(roundedAngle);

        if (direction.x < 0 && x > 0 || direction.x > 0 && x < 0) {
            x*=-1;
        }

        if (direction.y < 0 && y > 0 || direction.y > 0 && y < 0) {
            y*=-1;
        }

        return new Vector2(x, y); // returns normalized vector of pan direction
    }

    private float GetAngle(Vector2 direction) {
        float angle = Mathf.Atan(direction.y / direction.x); // gets current angle of cursor from player

        if (direction.x < 0) {
            angle += Mathf.PI;
        }

        return angle;
    }

    private float GetAngleDeg(Vector2 direction) {
        return GetAngle(direction)  * 180 / Mathf.PI;
    }
}
