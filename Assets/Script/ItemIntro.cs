using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.XR.Interaction.Toolkit;
public class ItemIntro : MonoBehaviour
{

    private XRGrabInteractable grab;
  public  GameObject introPrefab;
    private GameObject entity;
    private Text text;
    public string introStr;

    public float distenceFromObject=3;
    // Start is called before the first frame update
    void Start()
    {
        grab = transform.GetComponent<XRGrabInteractable>();
        if (grab==null)
        {
            grab = transform.GetComponentInChildren<XRGrabInteractable>();
        }
       entity= Instantiate(introPrefab,transform);
        entity.transform.localPosition = Vector3.zero;
        text = entity.transform.GetComponentInChildren<Text>();
        text.text = introStr;
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.isSelected)
        {
            entity.SetActive(true);

        }
        else {
            entity.SetActive(false);
        }

        entity.transform.LookAt(Camera.main.transform.position);
        Vector3 aimPos = transform.position;
        aimPos.y += distenceFromObject;
        entity.transform.position =aimPos;
    }
}
