using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacdotController : MonoBehaviour
{
    public GameObject pacdot;
    public Vector2 start;
    public Vector2 end;
    public int step;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0, j = 0;
        float x = start.x, y = start.y;
        for ( i = 0; x + i * step <= end.x; i++ ) {
            for ( j = 0; y + j * step <= end.y; j++ ) {
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(x + i * step, y + j * step), Vector2.zero);
                if ( !hit ) { // without hit on anything
                    GameObject obj = GameObject.Instantiate(pacdot, new Vector3(x + i * step, y + j * step, 0), Quaternion.identity);
                    obj.transform.parent = this.gameObject.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
