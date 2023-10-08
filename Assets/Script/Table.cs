using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    public   List<GameObject> alltriggerObj = new List<GameObject>();
  public  Transform head;
    public static bool isok=false;
    public static Table instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alltriggerObj.Contains(other.gameObject))
        {


            if (alltriggerObj.Count !=0&&other.gameObject.tag=="toy")
            {
                foreach (var item in alltriggerObj)
                {
                    if (item.tag != "toy")
                    {
                        //pop up tips
                        Tip.instance.ShowTip("Still something on the desk");
                        return;
                    }
                }
            }

            alltriggerObj.Add(other.gameObject);
            Debug.Log(other.gameObject.name);
            if (alltriggerObj.Count==3)
            {
                foreach (var item in alltriggerObj)
                {
                    if (item.tag != "toy")
                    {
                        return;
                   }
                }


                foreach (var item in alltriggerObj)
                {
                   
                        item.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;                      
                    
                }
                Debug.Log("fsdfsdlfk;sdlkf;lsdk;lk;kl;kf;lsdkf;lsd");
                isok = true;
                
                Tip.instance.ShowTip("door is open^^^^^^^^^^^^^^^^^^^^^");
                //open the door
                Door.instance.PLayAnimation();
                head.LookAt(this.transform.position);
                head.transform.eulerAngles = new Vector3(0, head.transform.eulerAngles.y, 0);
            }
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (alltriggerObj.Contains(other.gameObject))
        {
            alltriggerObj.Remove(other.gameObject);
        }
    }
}
