using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float shootTime = 1;
    [SerializeField] private Transform cannonSpawnTransform;

    private float lastShootTime = -100f;
    void Start()
    {
        
    }

    void Update()
    {
        Shoot();
    }

    public void Shoot() {
        if (!cannonSpawnTransform)
            return;
        if (lastShootTime + shootTime > Time.time)
            return;
        GameObject cannonBall = PoolsManager.instance.cannonBallPool.GetObject(cannonSpawnTransform.position, cannonSpawnTransform.rotation);
        cannonBall.tag = transform.tag;
        lastShootTime = Time.time;
    }
}
