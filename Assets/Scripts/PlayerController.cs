using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  //For Scoring system
    public static int score= 0;        //score value to be shared with enemy destroy function
    private Rigidbody2D rb;      // rigidbody for the physics
    public float speed = 0.5f;   //basic movespeed 
    private bool isDead = false; //basic dying implementation
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //takes rigidbody for movement etc
    }

    void Update()
    {
        scoreText.text = " Current Score :" + score.ToString(); //UI assignment done in inspector
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector2.right * speed * horizontalInput);
        rb.AddForce(Vector2.up * speed * verticalInput);

        if (isDead) //the convulted thing is done to separate all dying logic and such in one fucntion for particles etc
        {
            Die();
        }
    }
    //Basically end the game if player hits a wall and stuff
    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.tag ==("Enemy") || collision2D.gameObject.tag == ("Wall") )
        {
        
            isDead = true;
        }
    }
    //the only non performance killer way to stop a game that i could remember at 11 pm
    void Die()
    {
        Destroy(this.gameObject);
        Time.timeScale = 0; //all decorations and restart logic can be placed here
    }
 }



