using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform tranns;
    public static Door instance;

    private void Start()
    {
        instance = this;
    }

    // Start is called before the first frame update
  public  void PLayAnimation()
    {
        StartCoroutine(ie_playe());
    }



    IEnumerator ie_playe()
    {
        while (tranns.eulerAngles.y<89)
        {
            tranns.eulerAngles = Vector3.Lerp(tranns.eulerAngles, new Vector3(0, 90, 0), 0.1f);

            yield return new WaitForEndOfFrame();

        }

        tranns.eulerAngles = new Vector3(0, 90, 0);

    }
}
