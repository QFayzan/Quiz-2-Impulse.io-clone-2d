using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject Forcemaker;
    public static int score= 0;
    public static bool forceON= false;
    private Rigidbody2D rb;      // rigidbody for the physics
    public float speed = 2.0f;   //basic movespeed 
    private bool isDead = false; //basic dying implementation
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       scoreText.text = " Current Score is :" + score.ToString();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(Vector2.right * speed * horizontalInput);
        rb.AddForce(Vector2.up * speed * verticalInput );
        
        if (Input.GetMouseButtonDown(0) && !forceON)
        {
            Forcemaker.gameObject.SetActive(true);
            forceON = true;
        }

    void OnCollisionEnter2D(Collision2D collision2D) // will be replaced by Die()
    {
        if (collision2D.gameObject.tag ==("Enemy")  )
        {
        Destroy(this.gameObject);
        }
        else if (collision2D.gameObject.tag == ("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
    }
}


