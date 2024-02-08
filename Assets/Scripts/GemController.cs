using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public int gemWorth = 10;
    private GameObject player;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update(){
        if(Vector3.Distance(transform.position, player.transform.position) < 2){
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 8);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")) {
            player.GetComponent<PlayerController>().AddExpToPlayer(gemWorth);
            Destroy(gameObject);
        }
    }
}
