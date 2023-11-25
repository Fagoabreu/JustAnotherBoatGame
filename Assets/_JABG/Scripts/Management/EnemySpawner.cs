using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime=10;
    const float waypointGizmoRadius = 0.3f;
    private float lastSpawnTime = 0;

    private void Start() {
        SpawnEnemy();
    }

    void Update()
    {
        if(transform.childCount < 1) return;

        if (lastSpawnTime + spawnTime < Time.time) {
            SpawnEnemy();
        }

    }
    private void OnDrawGizmos() {
        for (int i = 0; i < transform.childCount; i++) {
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(transform.GetChild(i).position, waypointGizmoRadius);
        }
    }

    private void SpawnEnemy() {
        Transform child = transform.GetChild(Random.Range(0, transform.childCount));
        getRamdomEnemyPool().GetObject(child.position, child.rotation);
        lastSpawnTime = Time.time;
    }

    private SpawnerPool getRamdomEnemyPool() {
        switch ((int)Random.Range(0, 2)) {
            case 0:
                return PoolsManager.instance.EnemyShooterPool;
            case 1:
                return PoolsManager.instance.EnemyPool;
            default:
                Debug.Log("Enemy Spawner fail to get ramdom pool");
                return null;
        }
    }
}
