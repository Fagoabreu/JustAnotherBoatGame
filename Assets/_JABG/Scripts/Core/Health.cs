using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Life Parameter")]
    [Range(0,2f)]
    [SerializeField] float imunityTime=0;
    [SerializeField] int maxLife = 3;
    [Header("Render")]
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] Sprite[] boatSprites;

    private int currentLife;
    private bool isImune = false;
    private bool isDead = false;
    private void Awake() {
        if(!renderer)
            renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentLife = maxLife;
        renderer.sprite = boatSprites[0];
    }

    public bool TakeDamage(int value) {
        if (isImune || isDead) {
            return false;
        }

        currentLife = Mathf.Clamp(currentLife-value,0,maxLife);
        if (currentLife == 0) {
            Die();
            return true;
        }
        if (currentLife < (maxLife * 0.4f)) {
            renderer.sprite = boatSprites[2];
        } else if (currentLife < (maxLife * 0.7f)) {
            renderer.sprite = boatSprites[1];
        }
        isImune = true;
        Invoke("ResetImunity", imunityTime);
        return true;
    }

    private void Die() {
        renderer.sprite = boatSprites[3];
        isDead = true;
        Destroy(gameObject, 1f);
    }

    private void ResetImunity() {
        isImune = false;
    }
    public bool IsDead() {
        return isDead;
    }
}
