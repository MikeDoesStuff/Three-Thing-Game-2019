using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplaymanager : MonoBehaviour {

    public Text counter_Text;
    public Text time_debug;
    private Time time = new Time();
    private int currentScore;
    private float currTime = 0f;
    private float timeScale = 1.0f;

    public void UpdateScore(int jump_counter)
    {
        currentScore = jump_counter;
        counter_Text.text = "JUMPS LEFT  " + currentScore.ToString();
    }
    public void GetTime()
    {
        currTime = float.Parse(Time.time.ToString());
        time_debug.text = "Time: " + currTime.ToString();
    }
}
