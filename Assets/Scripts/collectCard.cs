using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collectCard : MonoBehaviour
{

    private Card cardscript;
    
    ScoreScript score;

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Card")){
            score = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreScript>();
            score.scoreValue += 1;
            score.score.text = "Cartas: " + score.scoreValue + " / 3";

            cardscript = collision.gameObject.GetComponent<Card>();
            cardscript.cardInfo.SetActive(true);
            Time.timeScale = 0;
            Destroy(collision.gameObject);
        }
    }

    public void ContinueButton(){
        cardscript.cardInfo.SetActive(false);
        Time.timeScale = 1;

        score = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreScript>();
        if(score.scoreValue == 3){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
