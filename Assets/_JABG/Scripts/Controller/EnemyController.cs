using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Health health;
    [SerializeField] private Mover mover;

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
        Vector2 playerDirection = (player.transform.position - transform.position).normalized;
        mover.Move(playerDirection);

    }
}
