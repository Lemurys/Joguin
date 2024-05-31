using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D cc;

    public GameObject collected;
    public int score;
    public int collectedItems;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
       
        if(collision.gameObject.tag == "Player") {

            sr.enabled = false;
            cc.enabled = false;
            collected.SetActive(true);

            GameController.instance.score += score;
            GameController.instance.CollectedItems += collectedItems;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.3f);

        }
    }
}
