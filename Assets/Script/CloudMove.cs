using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;


public class CloudMove : MonoBehaviour
{
    public List<Transform> pathPoint = new List<Transform>();
    public XROrigin aimXr;
    [Range(0,1f)]
    public float rate = 0.2f;
    //public Rigidbody playerRb;
    //public Vector3 newPos = new Vector3(139.30f,126.10f,37.99f);
    //public GameObject cloudTarget;
    // Start is called before the first frame update

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("player"))
    //    {
    //        Debug.Log("ok");
    //        StartMove();
    //    }
        
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("2");
            StartMove();
        }
    }

    [ContextMenu("shang yun")]

    public void StartMove()
    {
     
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {

        //The player becomes the child of the cloud
        //Disable the player's controller

        aimXr.transform.parent = this.transform;
        GameManager.instance.ShowHands(false);
        aimXr.transform.localPosition = Vector3.up;
        aimXr.transform.localRotation = Quaternion.identity;
        aimXr.transform.GetChild(0).localRotation = Quaternion.identity;


        while (pathPoint.Count != 0)
        {
            Vector3 aimPos = Vector3.LerpUnclamped(transform.position, pathPoint[0].position, rate);

     
            transform.LookAt(new Vector3(aimPos.x,transform.position.y,aimPos.y));
                transform.position = aimPos;
            
            float distance = Vector3.Distance(transform.position, pathPoint[0].position);
            if (distance < 0.01f)
            {
                pathPoint.RemoveAt(0);

                if(pathPoint.Count == 0)
                {
                    break;
                }
            }
            yield return new WaitForEndOfFrame();
        }


        //The player leaves the cloud
        //enable the player's controller



        aimXr.transform.parent = null;
        GameManager.instance.ShowHands(true);
        yield return null;
    }

   
}
