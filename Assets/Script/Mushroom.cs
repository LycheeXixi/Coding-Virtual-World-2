using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.XR.Interaction.Toolkit;

public class Mushroom : XRGrabInteractable
{



    protected override void OnSelectEntered(XRBaseInteractor args)
    {


        base.OnSelectEntered(args);
        // 获取被抓住的物体
        GameObject grabbedObject = args.selectTarget.gameObject;



        // 然后您可以对 grabbedObject 进行任何您想要的操作

        if (grabbedObject.tag == "mushroom")
        {
           
            MushRoomManager.instance. score++;
            Destroy(grabbedObject, 0.5f);

        }
    }












}
