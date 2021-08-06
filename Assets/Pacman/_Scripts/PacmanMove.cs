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
        // Check for Input if not moving
        if ( (Vector2) transform.position == dest ) {
            if ( Input.GetKey(KeyCode.UpArrow) && Valid(Vector2.up) )
                dest = (Vector2) transform.position + Vector2.up;
            if ( Input.GetKey(KeyCode.DownArrow) && Valid(Vector2.down) )
                dest = (Vector2) transform.position + Vector2.down;
            if ( Input.GetKey(KeyCode.LeftArrow) && Valid(Vector2.left) )
                dest = (Vector2) transform.position + Vector2.left;
            if ( Input.GetKey(KeyCode.RightArrow) && Valid(Vector2.right) )
                dest = (Vector2) transform.position + Vector2.right;
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
