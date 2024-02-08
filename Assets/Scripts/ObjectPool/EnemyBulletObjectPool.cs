using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletObjectPool : MonoBehaviour
{
    public static EnemyBulletObjectPool SharedInstance;
    public List<GameObject> pooledEnemyBulletObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake(){
        SharedInstance = this;
    }

    void Start(){
        pooledEnemyBulletObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++){
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledEnemyBulletObjects.Add(tmp);
        }
    }

    public GameObject getPooledEnemyBulletObject(){
        for(int i = 0; i < amountToPool; i++){
            if(!pooledEnemyBulletObjects[i].activeInHierarchy){
                return pooledEnemyBulletObjects[i];
            }
        }
        return null;
    }
}
