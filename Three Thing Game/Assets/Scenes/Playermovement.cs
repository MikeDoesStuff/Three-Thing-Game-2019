using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
public class Playermovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 500f;
    public float leftForce = -500f;
    public float rightForce = 500f;
    public float backForce = 500f; //only use for debug
    public float jumpForce = 10000f;

    //Timers
    public static float timer;
    public static bool timeStarted = false;
    public static float[] remainingTime = new float[4];//remaining powerup time: (speedTime, slowTime)

    public Text counter_Text;
    public Text winText;
    private int jump_counter = 3;
    private gameplaymanager Gameplaymanager;

    void Awake()
    {
        Gameplaymanager = GameObject.FindObjectOfType<gameplaymanager>();
        Gameplaymanager.UpdateScore(jump_counter);
        timeStarted = true;
        InvokeRepeating("decreaseTimeRemaining", 1, 1);
    }
    void OnCollisionEnter(Collision col)
    {
        string powerupType = col.gameObject.name;
        switch (powerupType)
        {
            case "Jumps":
                jump_counter += 3;
                Destroy(col.gameObject);
                break;
            case "Speed":
                remainingTime[0] = 10;
                Destroy(col.gameObject);
                break;
            case "Slow":
                remainingTime[1] = 10;
                Destroy(col.gameObject);
                break;
            case "Jump":
                remainingTime[2] = 10;
                Destroy(col.gameObject);
                break;
            case "Time":
                remainingTime[3] = 10;
                Destroy(col.gameObject);
                break;
        }
        Gameplaymanager.UpdateScore(jump_counter);
    }
    void Update() //called once per frame
    {

        if (Input.GetKey("w"))//forward
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("a"))//left
        {
            rb.AddForce(leftForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))//right
        {
            rb.AddForce(rightForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, backForce * Time.deltaTime);
        }
        if (Input.GetKeyDown("space"))
        {
            Gameplaymanager.UpdateScore(jump_counter);
            if (jump_counter > 0)
            {
                rb.AddForce(0, jumpForce * Time.deltaTime, 0);
                Debug.Log(jump_counter + "Left");
                jump_counter -= 1;
            }
            else
            {
                Debug.Log("No jumps left");
            }
        }
        if (timeStarted == true)
        {
            timer += Time.deltaTime; //big float
        }
        if (remainingTime[0] > 0) //checks powerup time & applies buff
        {
            forwardForce = 1000f;
            leftForce = -1000f;
            rightForce = 1000f;
            backForce = -1000f;
        }
        else if (remainingTime[1] > 0)
        {
            forwardForce = 250f;
            leftForce = -750f;
            rightForce = 250f;
            backForce = -250f;
        }
        else if (remainingTime[2] > 0)
        {
            jumpForce = 15000f;
        }
        else if (remainingTime[3] > 0)
        {
            Time.timeScale = 0.7f;
        }
        else
        {
            forwardForce = 500f;
            leftForce = -500f;
            rightForce = 500f;
            backForce = -500f;
            jumpForce = 10000f;
            Time.timeScale = 1.0f;
        }
    }
    private void decreaseTimeRemaining()
    {
        for (int i = 0; i < remainingTime.Length; i++)
        {
            if (remainingTime[i] > 0)
            {
                remainingTime[i]--;
            }
        }
    }

    private void OnGUI()
    {
        float speedTime = Mathf.Floor(remainingTime[0]);
        float slowTime = Mathf.Floor(remainingTime[1]);
        float jumpTime = Mathf.Floor(remainingTime[2]);
        float timeScaleTime = Mathf.Floor(remainingTime[3]);
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);
        GUI.Label(new Rect(10, 10, 550, 300), seconds.ToString()); // timer debug
        GUI.Label(new Rect(750, 10, 550, 300), "Forward force: " + forwardForce.ToString() + " Jump force: " + jumpForce.ToString() + " Timescale: " + Time.timeScale.ToString()); // speed / jump / timescale
        GUI.Label(new Rect(300, 10, 550, 300), "Timeouts: " + "Speed: " + speedTime.ToString() + " Slow: " + slowTime.ToString() + " Jump: " + jumpTime.ToString() + " Time: " + timeScaleTime.ToString()); //powerup time debug
    }

}
