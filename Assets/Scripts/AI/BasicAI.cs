using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    public float speed;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
    }
}
