using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject settingPage;
    public XRUIInputModule uiInput;

    public GameObject[] hands;

    List<InputDevice> all2device = new List<InputDevice>();

    UnityEvent onSettingButtonDown = new UnityEvent();

    bool triggerValue;

    private bool TriggerValue
    {

        set {
            if (triggerValue==false&&value==true)
            {

                onSettingButtonDown.Invoke();
            }
            triggerValue=value;
        }

        get {

            return triggerValue;
        }
    }



    public void ShowHands(bool active)
    {
        hands[0].SetActive(active);
        hands[1].SetActive(active);
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, all2device);



        onSettingButtonDown.AddListener(()=> {


            if (settingPage.activeSelf == true)
            {
                settingPage.SetActive(false);
                //enable clicking
                uiInput.enabled = false;
            }
            else {
                settingPage.SetActive(true);
                //disable clicking
                uiInput.enabled = true;
            }

        });

    }

    // Update is called once per frame
    void Update()
    {

       
        if (all2device.Count==1)
        {
            bool temp;
            all2device[0].TryGetFeatureValue(CommonUsages.secondaryButton, out temp);
            TriggerValue = temp;
           
        }
    }
}
