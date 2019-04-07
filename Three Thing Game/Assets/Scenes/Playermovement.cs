using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Playermovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 0f; //change values to 500 etc
    public float leftForce = 0f;
    public float rightForce = 0f;
    public float backForce = 0f;
    public float jumpForce = 0f;

    public static float timer;
    public static bool timeStarted = false;
    public int remainingTime; //remaining powerup time
    public Text counter_Text;
    public Text winText;
    private int jump_counter = 3;
    private gameplaymanager Gameplaymanager;

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

                // forward speed ++
        }
        Gameplaymanager.UpdateScore(jump_counter);
    }
    //void Start()
    //{
    //    //rb = GetComponent<Rigidbody>();
    //    jump_counter = 0;
    //    //SetCountText ();
    //    //winText.text = "";
    //}
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
