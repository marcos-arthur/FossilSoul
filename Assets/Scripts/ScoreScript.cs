using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    
    public int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        score.text = "Cartas: " + scoreValue;
    }

}
