using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstep : MonoBehaviour
{
    // Start is called before the first frame update
  public AudioSource footstepsSound;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            footstepsSound.enabled = true;

        }
        else
        {
            footstepsSound.enabled = false;
        }
    }
}
