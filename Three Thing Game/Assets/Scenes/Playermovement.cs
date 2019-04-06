using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Playermovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 0f;
    public float leftForce = 0f;
    public float rightForce = 0f;
    public float backForce = 0f;
    public float jumpForce = 0f;

    public Text counter_Text;
    public Text winText;
    private int jump_counter = 3;
    private gameplaymanager Gameplaymanager ;

    void Awake()
    {
        Gameplaymanager = GameObject.FindObjectOfType<gameplaymanager>();
        Gameplaymanager.UpdateScore(jump_counter);
    }
    // Update is called once per frame

    void OnCollisionEnter(Collision col)
    {
        Gameplaymanager.UpdateScore(jump_counter);
        if (col.gameObject.name == "Power Up")
        {
            jump_counter += 3;
            Gameplaymanager.UpdateScore(jump_counter);
            Destroy(col.gameObject);
        }
    }

    //void Start()
    //{
    //    //rb = GetComponent<Rigidbody>();
    //    jump_counter = 0;
    //    //SetCountText ();
    //    //winText.text = "";
    //}
    void Update () {
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
