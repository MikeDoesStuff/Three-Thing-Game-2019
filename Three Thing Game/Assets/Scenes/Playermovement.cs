using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Playermovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 500f;
    public float leftForce = -500f;
    public float rightForce = 500f;
    public float backForce = 500f; //only use for debug
    public float jumpForce = 10000f;

    public static float timer;
    public static bool timeStarted = false;
    public struct RemainingTime
    {
        public int speedTime; 
        public int slowTime;
        //public remainingTime(int x)
    }
         //remaining powerup time
    public Text counter_Text;
    public Text winText;
    private int jump_counter = 3;
    private gameplaymanager Gameplaymanager;
    RemainingTime remainingTime;

    void Awake()
    {
        Gameplaymanager = GameObject.FindObjectOfType<gameplaymanager>();
        Gameplaymanager.UpdateScore(jump_counter);
        timeStarted = true;
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
                forwardForce += 500f;
                leftForce += -500f;
                rightForce += 500f;
                backForce += -500f;
                remainingTime.speedTime = 10;
                Destroy(col.gameObject);
                break;
            case "Slow":
                forwardForce += -250f;
                leftForce += 250f;
                rightForce += -250f;
                backForce += 250f;
                remainingTime.slowTime = 10;
                Destroy(col.gameObject);
                break;
        }
        Gameplaymanager.UpdateScore(jump_counter);
    }
    void Update() //called once per frame
    {
        // rb.AddForce(0, 0, fowardforcde * Time.deltaTime);

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
            jump_counter -= 1;
            Gameplaymanager.UpdateScore(jump_counter);
            if (jump_counter >= 0)
            {
                rb.AddForce(0, jumpForce * Time.deltaTime, 0);
                Debug.Log(jump_counter + "Left");
            }
            else
            {
                Debug.Log("No jumps left");
            }
        }
        if(timeStarted == true)
        {
            timer += Time.deltaTime; 
        }
    }
    private void OnGUI()
    {
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);
        GUI.Label(new Rect(10, 10, 550, 300), seconds.ToString());
    }

}
