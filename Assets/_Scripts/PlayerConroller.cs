using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    float hor;
    float ver;
    Vector3 dir;
    Rigidbody rb;
    public int speed = 0;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
    }
    void FixedUpdate() {
        if ( gameController.isGameEnd ) {
            // if(!isGameEnd){
            rb.velocity = Vector3.zero;
            return;
        }
        dir = new Vector3(hor, 0, ver);
        rb.AddForce(dir * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if ( other.gameObject.name == "Exit" ) {
            // game end
            gameController.GameEnd(true);     // -> GameEnd();
        } else if (other.gameObject.tag == "Gem") {
            // add hp
            gameController.EditHp(1);
            Destroy(other.gameObject);
        
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.tag == "Enemy" ) {
            gameController.EditHp(-1);
        }
    }
}
