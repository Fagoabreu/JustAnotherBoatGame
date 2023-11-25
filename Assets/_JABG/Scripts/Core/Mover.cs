using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [Range(0.1f, 50f)]
    [SerializeField] protected float turnSpeed = 0.1f;
    [Range(0.1f, 5f)]
    [SerializeField] protected float maxMoveSpeed = 20f;
    [Range(1f, 100f)]
    [SerializeField] protected float aceleration = 1f;

    protected float currentSpeed = 0;
    protected Vector2 currentDirection = Vector2.zero;
    protected Rigidbody2D rb;


    protected virtual void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 direction) {
        currentDirection = direction;
    }

   
}
