using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    //�ٶ�
    public float fadeSpeed = 1.5f;
    //�Ƿ������뵭��Ч��
    private bool sceneStarting = true;
    private RawImage rawImage;

    void Start()
    {
        //��ȡRawimageʵ��
        rawImage = GetComponent<RawImage>();
        //��ͼƬ��С����Ϊ��Ļ��С
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);
    }

    void Update()
    {
        if (sceneStarting)
            StartScene();
    }
    //��Ļ����Ч������     
    private void FadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    //��Ļ����Ч������     
    private void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    //��Ϸ��ʼʱЧ��
    private void StartScene()
    {
        FadeToClear();
        if (rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            sceneStarting = false;
        }
    }

    //��Ϸ����ʱЧ��
    public void EndScene()
    {
        rawImage.enabled = true;
        FadeToBlack();
        if (rawImage.color.a > 0.95f)
        {
            SceneManager.LoadScene("Demo");
        }
    }
}

