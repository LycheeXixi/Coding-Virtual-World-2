using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collisonsound : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float collisionForce = collision.relativeVelocity.magnitude;
        source.PlayOneShot(source.clip, collisionForce);

    }
  
}
