using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplaymanager : MonoBehaviour
{

    public Text counter_Text;
    public Text time_debug;
    private int currentScore;
    private float timeScale = 1.0f;

    public void UpdateScore(int jump_counter)
    {
        currentScore = jump_counter;
        counter_Text.text = "JUMPS LEFT  " + currentScore.ToString();
    }
}