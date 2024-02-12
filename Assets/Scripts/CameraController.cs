using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    private PlayerController playerController;
    private bool played = false;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerController.playerHealth <= 0 && !played)
        {
            audioSource.clip = audioClip;
            audioSource.loop = false;
            audioSource.PlayOneShot(audioClip);
            played = true;
        }
    }
}
