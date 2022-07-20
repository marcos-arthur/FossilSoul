using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCard : MonoBehaviour
{

    private Card cardscript;

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Card")){
            cardscript = collision.gameObject.GetComponent<Card>();
            cardscript.cardInfo.SetActive(true);
            Time.timeScale = 0;
            Destroy(collision.gameObject);
        }
    }

    public void ContinueButton(){
        cardscript.cardInfo.SetActive(false);
        Time.timeScale = 1;
    }
}
