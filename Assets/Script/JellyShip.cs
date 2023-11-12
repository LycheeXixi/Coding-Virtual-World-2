using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JellyShip : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 newPos = new Vector3(9.26f, 59.10f, 13.50f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShipMoveFwd();
    }

    void ShipMoveFwd()
    {
        gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, newPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Jelly Destination"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
