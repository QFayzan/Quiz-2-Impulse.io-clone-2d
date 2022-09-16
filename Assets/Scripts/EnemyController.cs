using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
private GameObject player;
 public float moveSpeed = 0.8f;
 public static bool isKillable = false;
 private Rigidbody2D enemyRb;
 
void Start()
{
    player = GameObject.Find("Player");
    enemyRb = GetComponent<Rigidbody2D>();
}

void Update()
{
    Vector2 lookDirection = (player.transform.position - transform.position).normalized;
    Vector2 lookDistance = (player.transform.position - transform.position);
    if (lookDistance.x < -4 || lookDistance.x >4)
    {
    enemyRb.AddForce(lookDirection* moveSpeed);
    }
}
void OnCollisionEnter2D(Collision2D collision2D) // Mechanic to destroy when hit walls tagged walls
    {
        if (collision2D.gameObject.tag ==("Wall") && isKillable  ) // used in kiling implementation
        {
            Die();
        }
    }
    
    void Die()
    {
        Destroy(this.gameObject);
        PlayerController.score += 25;
    }
}
