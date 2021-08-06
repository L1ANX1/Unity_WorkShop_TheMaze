using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;
    public float speed = 0.3f;
    Rigidbody2D rb2d;
    Animator animator;
    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        // Waypoints not reached yet, then move closer
        if ( transform.position != waypoints[cur].position ) {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            rb2d.MovePosition(p);
        }
        // Waypoint reached, select next one
        else
            cur = ( cur + 1 ) % waypoints.Length;

        //Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        animator.SetFloat("DirX", dir.x);
        animator.SetFloat("DirY", dir.y);
    }
}
