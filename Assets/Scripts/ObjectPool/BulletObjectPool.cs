using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool SharedInstance;
    public List<GameObject> pooledBulletObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake(){
        SharedInstance = this;
    }

    void Start(){
        pooledBulletObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++){
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledBulletObjects.Add(tmp);
        }
    }

    public GameObject getPooledBulletObject(){
        for(int i = 0; i < amountToPool; i++){
            if(!pooledBulletObjects[i].activeInHierarchy){
                return pooledBulletObjects[i];
            }
        }
        return null;
    }
}
