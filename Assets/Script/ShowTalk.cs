using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTalk : MonoBehaviour
{
    public List<string> words = new List<string>();

    public float timePerWords = 3;

    public Text wordText;

  public  bool startOnawake=false;


    IEnumerator Play()
    {
        wordText.text = "";
        foreach (var item in words)
        {
            wordText.text = item;
            yield return new WaitForSeconds(timePerWords);
        }


        wordText.text = "";
        GameManager.instance.ShowHands(true);
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startOnawake)
        {
            GameManager.instance.ShowHands(false);
            transform.GetChild(0).gameObject.SetActive(true);
            //StopAllCoroutines();
            StartCoroutine(Play());
            
           
        }
    }



    public void playManual()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(Play());
       
    }

   
}
