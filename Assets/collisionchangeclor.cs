using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionchangeclor : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
  var newColor = collision.collider.GetComponent<MeshRenderer>().material.color;
  GetComponent<MeshRenderer>().material.color = newColor;
  }
}
