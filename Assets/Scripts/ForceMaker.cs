using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMaker : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float pushStrength = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        float activated = 0.0f;
        activated += Time.deltaTime;
        if (activated > 1.0f)
        {
            gameObject.SetActive(false);
            PlayerController.forceON = false;

        }
    }
        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            collision.gameObject.GetComponent<EnemyController>();
            EnemyController.isKillable = true;
            Vector3 awayFromPlayer = collision.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * pushStrength, ForceMode.Impulse);
        }
    }
    }
