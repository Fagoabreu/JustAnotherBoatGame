using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Health health;
    [SerializeField] private Mover mover;
    [SerializeField] private float attackDistance = 0;
    [SerializeField] private bool explodeOnContact = true;

    private void Awake() {
        mover = GetComponent<Mover>();
        health = GetComponent<Health>();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        Vector2 playerDistance = (player.transform.position - transform.position);
        if (checkAttackRange(playerDistance)) {
            Attack();
        } else {
            MoveToTarget(playerDistance);
        }
    }

    private bool checkAttackRange(Vector2 targetDistance) {
        if (targetDistance.magnitude <= attackDistance) {
            return true;
        }
        return false;
    }

    private void Attack() {
        if (explodeOnContact) {
            Explode();
        }
    }

    private void Explode() {
        throw new NotImplementedException();
    }

    private void MoveToTarget(Vector2 targetDistance) {
        mover.Move(targetDistance.normalized);
    }
}
