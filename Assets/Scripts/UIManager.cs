using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public Text bunnyScore;
    public Text timer;

    public void ShowGameOver()
    {
        panel.SetActive(true);
    }

    public void ShowScore(int score)
    {
        bunnyScore.text = "Bunnies collected: " + score;
    }

    public void UpdateTime(float time)
    {
        timer.text = "Time remaining: " + (int)time;
    }
}
