using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    public float FallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {

            Invoke("falling", FallingTime);

        }    

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == 9) {

            Destroy(gameObject);
        }
}
    void falling() {

        target.enabled = false;
        boxCollider.isTrigger = true;
    }
}
