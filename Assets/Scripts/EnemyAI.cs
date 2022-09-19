using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private Transform target;
    public float speed = 100.0f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        seeker = GetComponent<Seeker>();
        rb2D = GetComponent<Rigidbody2D>();
        InvokeRepeating ("UpdatePath", 0f , 0.5f);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0 ;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2D.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb2D.AddForce(force);

        float distance = Vector2.Distance(rb2D.position , path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
     void UpdatePath()
        {
            if (seeker.IsDone())
            seeker.StartPath(rb2D.position ,  target.position, OnPathComplete);
        }
}
