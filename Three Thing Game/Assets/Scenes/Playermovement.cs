using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Playermovement : MonoBehaviour {

    public Rigidbody rb;

    public float fowardforcde = 0f;
    public float leftforce = 0f;
    public float rightforce = 0f;
    public float backforce = 0f;
    public float jumpforce = 0f;

    public Text counter_Text;
    public Text winText;
    private int jump_counter = 3;
    // Update is called once per frame

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Power_Up_Cube")
        {
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
            rb.AddForce(0, 0, fowardforcde * Time.deltaTime);
        }
        if (Input.GetKey("a"))//left
        {
            rb.AddForce(leftforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))//right
        {
            rb.AddForce(rightforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, backforce * Time.deltaTime);
        }
        if (Input.GetKeyDown("space"))
        {
            
            if (jump_counter > 0)
            {
                rb.AddForce(0, jumpforce * Time.deltaTime, 0);
                Debug.Log(jump_counter + "Left");
            }
            else
            {
                Debug.Log("No jumps left");
            }
        }
    }

    void SetCountText()
    {
        counter_Text.text = "Count: " + jump_counter.ToString();
        //if (count >= 12)
        //{
        //    winText.text = "You Win!";
        //}
    }
}
