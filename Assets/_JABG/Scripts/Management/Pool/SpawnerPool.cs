using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerPool : MonoBehaviour
{
    [Header("Variable of Object to Instantiate")]
    [SerializeField] private GameObject gameObjectToInstantiate;

    [Header("Size o object Pool")]
    [SerializeField] private int defaultPoolSize = 5;

    [Tooltip("Para definir se ela é expansivel")]
    [SerializeField] private int maxPoolSize = 5;
    private ObjectPool<GameObject> pool;

    private Vector3 objectposition;
    private Quaternion objectrotation;
    private void Awake() {
        //verifica que o limit é no minimo o mesmo tamanho do pool
        maxPoolSize = maxPoolSize > defaultPoolSize ? maxPoolSize : defaultPoolSize;

        pool = new ObjectPool<GameObject>(
            () => {
                GameObject g = Instantiate(gameObjectToInstantiate);
                g.transform.parent = transform;
                g.SetActive(false);
                return g;
            }, pollObject => {
                pollObject.transform.SetPositionAndRotation(objectposition, objectrotation);
                pollObject.SetActive(true);
            }, pollObject => {
                pollObject.SetActive(false);

            }, pollObject => {
                Destroy(pollObject.gameObject);
            }, false, defaultPoolSize, maxPoolSize);
    }

    //retirar um objeto da lista para ser usável
    public GameObject GetObject(Vector2 position, Quaternion rotation) {
        objectposition = position;
        objectrotation = rotation;
        return pool.Get();
    }

    //Retorna o objeto para a lista de usáveis
    public void ReturnObject(GameObject objToReturn) {
        pool.Release(objToReturn);
    }
}
