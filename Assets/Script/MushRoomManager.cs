using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushRoomManager : MonoBehaviour
{
    public Text showScore;

    public int score = 0;

    public static MushRoomManager instance;

    private void Start()
    {
        instance = this;
    }


    private void Update()
    {
        addScore();
    }

    public void addScore()
    {
        showScore.text = ": x " + score;
    }
}
