using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public static EnemyObjectPool SharedInstance;
    public List<GameObject> pooledEnemyObjects;
    public GameObject objectToPool1;
    public GameObject objectToPool2;
    public GameObject objectToPool3;
    public GameObject objectToPool4;
    public GameObject objectToPool5;
    public GameObject objectToPool6;

    public int amountToPool;

    void Awake(){
        SharedInstance = this;
    }

    void Start(){
        pooledEnemyObjects = new List<GameObject>();
        AddToPool(objectToPool1);
        AddToPool(objectToPool2);
        AddToPool(objectToPool3);
        AddToPool(objectToPool4);
        AddToPool(objectToPool5);
        AddToPool(objectToPool6);
    }

    private void AddToPool(GameObject objects){
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++){
            tmp = Instantiate(objects);
            tmp.SetActive(false);
            pooledEnemyObjects.Add(tmp);
        }
    }

    public GameObject getPooledEnemyObject(string objectName){
        if(pooledEnemyObjects.FindAll( go => !go.activeInHierarchy ).Count > 250){
            List<GameObject> newList = pooledEnemyObjects.FindAll(x => x.name == objectName);
            for(int i = 0; i < amountToPool; i++){
                if(!newList[i].activeInHierarchy){
                    return newList[i];
                }
            }   
        }
        return null;
    }
}
