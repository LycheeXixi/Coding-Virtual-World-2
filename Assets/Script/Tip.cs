using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{

    public static Tip instance;
    Text xxx;
    // Start is called before the first frame update
    void Start()
    {
        xxx = transform.GetComponent<Text>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void ShowTip(string str)
    {
        StopAllCoroutines();

        ie_Showtip(str);
    }

    IEnumerator ie_Showtip(string str)
    {
        xxx.text = str;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
