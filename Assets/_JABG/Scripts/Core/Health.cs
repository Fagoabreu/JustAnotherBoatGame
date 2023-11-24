using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Sprite[] boatSprites;
    [Range(0,2f)]
    [SerializeField] float imunityTime=0;
    [SerializeField] int maxLife = 3;
    private int currentLife;
    private bool isImune =false;
    private bool isDead = false;
    [SerializeField] SpriteRenderer renderer;

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
