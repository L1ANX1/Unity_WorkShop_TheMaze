using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour
{
    public GameObject explodeParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject explode=  GameObject.Instantiate(explodeParticle, this.gameObject.transform.position, Quaternion.identity);
        Destroy(explode, 1);       
        Destroy(this.gameObject);

    }
}
