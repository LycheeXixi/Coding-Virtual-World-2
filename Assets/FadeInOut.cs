using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    //速度
    public float fadeSpeed = 1.5f;
    //是否开启淡入淡出效果
    private bool sceneStarting = true;
    private RawImage rawImage;

    void Start()
    {
        //获取Rawimage实例
        rawImage = GetComponent<RawImage>();
        //将图片大小设置为屏幕大小
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);
    }

    void Update()
    {
        if (sceneStarting)
            StartScene();
    }
    //屏幕渐隐效果方法     
    private void FadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    //屏幕渐显效果方法     
    private void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    //游戏开始时效果
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

    //游戏结束时效果
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

