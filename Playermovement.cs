using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Playermovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 500f;
    public float leftForce = -500f;
    public float rightForce = 500f;
    public float backForce = 500f;
    public float jumpForce = 10000f;

    public Text counter_Text;
    public Text winText;
    private int jump_counter = 3;
    private gameplaymanager Gameplaymanager;

    void Awake()
    {
        Gameplaymanager = GameObject.FindObjectOfType<gameplaymanager>();
        Gameplaymanager.UpdateScore(jump_counter);
    }
    // Update is called once per frame

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
                Destroy(col.gameObject);
                break;
            case "Slow":
                forwardForce += -250f;
                leftForce += 250f;
                rightForce += -250f;
                backForce += 250f;
                Destroy(col.gameObject);
                break;

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
    void Update()
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
    }


}
