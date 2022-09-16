using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
  //  public GameObject[];
    float radius = 5.0f;
    float power = 1000.0f;
    float coneAngle = 45f;
    Collider coneCollider;
    Rigidbody2D rb2D;
    void Start()
    {
        coneCollider = GetComponent<Collider>();
        rb2D = GetComponent<Rigidbody2D>();
    }
     void Update() {
         {
             FireGun();
         }
     }
 
     void FireGun () {
         Vector3 explosionPos = transform.position;
         Collider[] Colliders = Physics.OverlapSphere (explosionPos, radius);
         
         foreach ( Collider hit in Colliders) {
            if (hit.attachedRigidbody != null && (Vector3.Angle(transform.forward, coneCollider.transform.position - transform.position) <= coneAngle)) {
                 hit.attachedRigidbody.AddExplosionForce(power * 1000, explosionPos, radius, 0.0f);
             }
         }
     }

    
}
