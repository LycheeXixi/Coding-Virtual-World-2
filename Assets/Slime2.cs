using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime2 : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            audioSource.Play();
            Debug.Log("hit!");
        }
        

    }
}
