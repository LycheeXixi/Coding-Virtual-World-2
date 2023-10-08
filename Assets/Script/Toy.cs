using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Toy : MonoBehaviour
{

    XRGrabInteractable grab;
    Vector3 pos;
    Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        grab = transform.GetComponent<XRGrabInteractable>();
        pos = transform.position;
        rot = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (grab.isSelected==false&&collision.gameObject.name!="Desk" && collision.gameObject.tag != "toy")
        {
             transform.position=pos;
             transform.rotation=rot;

        }
    }


}
