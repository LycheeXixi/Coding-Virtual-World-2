using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 oringnaleuler = transform.eulerAngles;

        Quaternion fullRotion = Quaternion.LookRotation(Camera.main.transform.position-transform.position);

        Vector3 fulleuler = fullRotion.eulerAngles;


        Vector3 aimeuler = oringnaleuler;
        aimeuler.y = fulleuler.y;

    }
}
