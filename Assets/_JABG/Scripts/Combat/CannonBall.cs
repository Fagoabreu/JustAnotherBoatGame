using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private bool explode=false;
    private float updateTime = 0f;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        updateTime = Time.time;
        rb.velocity = transform.right * moveSpeed;
    }

    private void Update() {
        if (updateTime + lifetime < Time.time) {
            PoolReturn();
        }
    }

    private void PoolReturn() {
        PoolsManager.instance.cannonBallPool.ReturnObject(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != gameObject.tag) {
            explode = true;
            updateAnimation();
        }
    }
    private void updateAnimation() {
        if (explode) {
            animator.SetTrigger("Explode");
        }
    }

}
