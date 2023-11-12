using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SunsetShip : MonoBehaviour
{
    public Vector3 newPos = new Vector3(177.40f, 149.5f, 194.70f);
    public float speed = 5.0f;
    //public Transform point;


    // Start is called before the first frame update
    void Start()
    {
        //GameManager.instance.ShowHands(false);
    }


    // bool couldAnimate = false;
    // Update is called once per frame
    void Update()
    {
        
            ShipAnim();

       if(transform.position == newPos)
        {
            GameManager.instance.ShowHands(true);
            //couldAnimate = true;
            //other.transform.parent = point;
            transform.parent = null;
            Debug.Log("123");
            Destroy(this);
        }
        
    }

    void ShipAnim()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, newPos, speed * Time.deltaTime);
      
    }

    //private void OnTriggerEnter(Collider other)
    //{
        //if (other.gameObject.CompareTag("player"))
        //{

           

            
        //}

        //if (other.gameObject.CompareTag("Airship Target"))
        //{
        //    Debug.Log("cnm");
        //    SceneManager.LoadScene(1);
        //}
    //}
}
