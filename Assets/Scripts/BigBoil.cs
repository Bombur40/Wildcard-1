using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoil : MonoBehaviour
{
    [SerializeField] private GameObject potPrefab;
    [SerializeField] private int health = 100;
    [SerializeField] private float cooldown = 5;
    
    //Creates a clone of the pot
    private void Spawn(Vector2 mousePos) {
        GameObject pot = Instantiate(potPrefab) as GameObject;
        Pot p = pot.GetComponent<Pot>();
        p.SetHealth(health);

        pot.transform.position = mousePos;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown >= 5){
            if (Input.GetKeyDown(KeyCode.Space)) {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Spawn(mousePos);
                cooldown = 0;
            }
        }
        else {
            cooldown = cooldown + Time.deltaTime;
        }
    }
}
