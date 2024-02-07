using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public static EnemyObjectPool SharedInstance;
    public List<GameObject> pooledEnemyObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake(){
        SharedInstance = this;
    }

    void Start(){
        pooledEnemyObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++){
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledEnemyObjects.Add(tmp);
        }
    }

    public GameObject getPooledEnemyObject(){

        List<GameObject> inactiveObjects = pooledEnemyObjects.FindAll( go => !go.activeInHierarchy );

        return inactiveObjects.Count > 0 ?
         inactiveObjects[ Random.Range(0, inactiveObjects.Count) ] :
         null;

        /*for(int i = 0; i < amountToPool; i++){
            if(!pooledEnemyObjects[i].activeInHierarchy){
                return pooledEnemyObjects[i];
            }
        }
        return null;*/
    }
}
