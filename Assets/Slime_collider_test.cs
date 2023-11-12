using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_collider_test : MonoBehaviour
{
    
    public Transform player;
    public Transform originalPoint;
    /*public Transform left_down, right_up;*/

    public float moveSpeed = 0.4f;
    public float rotateSpeed = 0.5f;
    /*private float left, down, right, up;*/
    private float outrange = 4.0f;
    private float inrange = 1.0f;

    private Vector3 originalPosition;

    private bool hostile = false;
    private bool goback = false;

    private Transform slimeTransform;

    void awake()
    {
        slimeTransform = this.transform;

    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {

        CheckRange();
        if (goback)
        {
            Debug.Log("goback!");
            GoBackMove();
        }
        else if (hostile && (!goback))
        {
            Debug.Log("hostile!");
            HostileMove();
        }
        
    }

    //check if the slime is out of range
    private void CheckRange()
    {
        if (out_range())
        {
            Debug.Log("out!");
            goback = true;
            hostile = false;
        }

        if (in_return_range())
        {
            goback = false;
        }
    }

    private void GoBackMove()
    {
        transform.LookAt(originalPoint); 
        transform.position = Vector3.MoveTowards(transform.position, originalPoint.position, moveSpeed * Time.deltaTime);
    }
        
    private void HostileMove()
    {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && goback == false)
        {
            Debug.Log("Meet!");
            hostile = true;
        }
    }

    private bool in_return_range()
    {
        float pos_x = Mathf.Abs(transform.position.x - originalPosition.x);
        float pos_y = Mathf.Abs(transform.position.y - originalPosition.y);
        float pos_z = Mathf.Abs(transform.position.z - originalPosition.z);
        return pos_x <= inrange && pos_y <= inrange && pos_z <= inrange;

    }

    // ????slime????????????
    bool out_range()
    {
        float pos_x = Mathf.Abs(transform.position.x - originalPosition.x);
        float pos_y = Mathf.Abs(transform.position.y - originalPosition.y);
        float pos_z = Mathf.Abs(transform.position.z - originalPosition.z);
        return pos_x >= outrange || pos_y >= outrange || pos_z >= outrange;
    }
}
