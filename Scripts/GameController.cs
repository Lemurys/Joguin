using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
using UnityEngine.UIElements;


public class GameController : MonoBehaviour
{

    //Public Objs
    public static GameController instance;
    public Text scoreText;
    public GameObject GameOver;
    public GameObject locationNL;
    public AudioClip sfxgameOver;
    public AudioController AudioController;
    public GameObject nextlvl;
    public AudioClip sfxWin;
    public int score;
    public GameObject oGame;



    // Private Objs
    [Serialize]
    private int TotalItems;
    public int CollectedItems;
    private int totalScore;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        TotalItems = GameObject.FindGameObjectsWithTag("Itens").Length;
        CollectedItems = 0;
        totalScore = PlayerPrefs.GetInt("score");
        Debug.Log(PlayerPrefs.GetInt("totalScore"));
    }

    void Update() {
        if (CollectedItems >= TotalItems) {
            locationNL.SetActive(true);
        }
    }

    public void UpdateScoreText() {
        scoreText.text = score.ToString();
        score++;
        PlayerPrefs.SetInt("score", totalScore);
    }

    public void showGameOver() {    
        AudioController.PlaySFX(sfxgameOver);
        GameOver.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Player") {
            ShowNextlvl();
        }

    }

    //private void OnTriggerExit(Collider other) {
    //    if(other.gameObject.tag == "Player") {
    //        boxIn.GetComponent<Collider>().isTrigger = false;
    //    }
    // }

    public void ShowNextlvl() {
        nextlvl.SetActive(true);
        AudioController.PlaySFX(sfxWin);
    }


    public void Next(string lvlname) {
        SceneManager.LoadScene(lvlname);
    }


    public void OGame() {
        oGame.SetActive(true);
        nextlvl.SetActive(false);

    }
}


