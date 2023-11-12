using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMove : MonoBehaviour
{
    public Vector3 newPos = new Vector3(152, 123.8f, 270.7f);
    public float speed = 5.0f;
    public Transform point;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    bool couldAnimate = false;
    // Update is called once per frame
    void Update()
    {
        if (couldAnimate)
        {
         ShipAnim();

        }
    }

    void ShipAnim()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, newPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {

            //ba ren yi dong dao chuan shang 

            GameManager.instance.ShowHands(false);
            couldAnimate = true;
            other.transform.parent = point;
            other.transform.localRotation = Quaternion.identity;

            other.transform.localPosition = Vector3.up;
        }

        if (other.gameObject.CompareTag("Airship Target"))
        {
            Debug.Log("cnm");
            SceneManager.LoadScene(1);
        }
    }
}
