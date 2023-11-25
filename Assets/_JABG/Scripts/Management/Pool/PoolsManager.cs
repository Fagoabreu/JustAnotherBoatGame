using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsManager : MonoBehaviour
{
    public static PoolsManager instance;
    public SpawnerPool cannonBallPool;
    public SpawnerPool EnemyPool;
    public SpawnerPool EnemyShooterPool;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }
}
