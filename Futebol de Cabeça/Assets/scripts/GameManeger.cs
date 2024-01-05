using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public int playerScore = 0, aiscore = 0;

    public float timer = 120f;

    public Text ScoreText;

    public string score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Debug.Log("game over");
            
        }

        score = playerScore.ToString() + " - " + aiscore.ToString();
        ScoreText.text = score.ToString();
    }
}
