using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class MascaradoEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float speed;
    public Transform rightCol;
    public Transform leftCol;

    public Transform topCol;
    public LayerMask layer;

    private bool colliding;

    public CapsuleCollider2D capsuleCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding) {

            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;

        }
    }

    bool PlayerDestroyed;
    private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.layer == 9) {
            anim.SetTrigger("Die");
            Destroy(gameObject, 0.5f);
            }
            if (col.gameObject.tag == "Player") {

            float height = col.contacts[0].point.y - topCol.position.y;

            if (height > 0 && !PlayerDestroyed) {

                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5,ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("Die");
                capsuleCollider.enabled = false;
                rb.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 1f);

            }
            else  {
                PlayerDestroyed = true;
                GameController.instance.showGameOver();
                Player.anime.SetTrigger("die");
                Destroy(col.gameObject, 0.5f);

            }
        }
    }
}
