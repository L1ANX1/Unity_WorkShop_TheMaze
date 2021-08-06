using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    Rigidbody2D rb2d;
    Collider2D col2d;
    Animator animator;

    Vector2 _nextDir = Vector2.zero;
    Vector2 _dir = Vector2.zero;
    // Start is called before the first frame update
    void Start() {
        dest = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
        col2d = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        // Move closer to destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        rb2d.MovePosition(p);
        // get the next direction from keyboard
        if ( Input.GetAxis("Horizontal") > 0 )
            _nextDir = Vector2.right;
        if ( Input.GetAxis("Horizontal") < 0 )
            _nextDir = Vector2.left;
        if ( Input.GetAxis("Vertical") > 0 )
            _nextDir = Vector2.up;
        if ( Input.GetAxis("Vertical") < 0 )
            _nextDir = Vector2.down;

        if ( Vector2.Distance(dest, transform.position) < 0.00001f ) {
            if ( Valid(_nextDir) ) {
                dest = (Vector2) transform.position + _nextDir;
                _dir = _nextDir;
            } else {
                if ( Valid(_dir) )
                    dest = (Vector2) transform.position + _dir;
            }
        }

        // Animation Parameters
        Vector2 dir = dest - (Vector2) transform.position;
        animator.SetFloat("DirX", dir.x);
        animator.SetFloat("DirY", dir.y);
    }

    bool Valid(Vector2 dir) {
        // Cast Line from 'next to Pacman' to 'Pacman'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        // Debug.DrawRay(pos + dir, -dir, Color.red);
        return hit.collider == col2d || hit.collider.gameObject.tag == "pacdot";
    }
}
