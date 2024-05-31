using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    // Public
    public float speed;
    public float JumpForce;
    public bool isJumping;

    // Private
    private Rigidbody2D rb;
    public static Animator anime;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();



    }

    void Move() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
       
        if(Input.GetAxis("Horizontal") > 0f) 
        { 

            anime.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);

        }
        else if (Input.GetAxis("Horizontal") < 0f) {

            anime.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else { 
            anime.SetBool("run", false); 
        }
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && !isJumping) {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            anime.SetBool("jump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.layer == 8) {
            isJumping = false;
            anime.SetBool("jump", false);
        }
        if(collision.gameObject.layer == 9) {

            GameController.instance.showGameOver();
            anime.SetTrigger("die");
            Destroy(gameObject, 0.5f);

        }
        if (collision.gameObject.tag == "Trap") {

            GameController.instance.showGameOver();
            anime.SetTrigger("die");
            Destroy(gameObject, 0.5f);

        }


    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == 8) {
            isJumping = true;
        }
    }
}
