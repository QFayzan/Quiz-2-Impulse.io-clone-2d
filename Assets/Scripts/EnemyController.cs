using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
private GameObject player;      //so far its being used to search for player
 public float moveSpeed = 0.8f; // movespeed value
 public bool isKillable = false;// used to prevent destruction when they wall collide without player input
 private Rigidbody2D enemyRb;   // rigidbody for movement
 
void Start()
{
    isKillable = false;         //Must be set again in start to make sure new prefab dont spawn with this enabled
    player = GameObject.Find("Player"); //Temporary method to find player
    enemyRb = GetComponent<Rigidbody2D>();//referenced for movement script
}

void Update()
{
    Vector2 lookDirection = (player.transform.position - transform.position).normalized; //Basic tracking using normalized vector to finalize distance
    //Vector2 lookDistance = (player.transform.position - transform.position); //the goal was to make objects seem inactive unless player is close didnt work
    if (Vector3.Distance(transform.position , enemyRb.transform.position) < 10) 
        { 
    enemyRb.AddForce(lookDirection* moveSpeed);
        }
}
void OnCollisionEnter2D(Collision2D collision2D) // Mechanic to destroy when hit walls tagged walls
    {
        if (collision2D.gameObject.tag == ("Bullet")) //the moment our invisible force hits enemy becomes killable by walls
        {
            isKillable = true;
        }
            if (collision2D.gameObject.tag ==("Wall") && isKillable  ) // used in kiling implementation
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        PlayerController.score += 25;  //score system implementation
    }
}
