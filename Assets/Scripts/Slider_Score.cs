using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider_Score : MonoBehaviour
{
    Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = gameObject.GetComponent<Text>();
        ScoreText.text = "Score: "+ CarMovement.Score;
    }

    // Update is called once per frame
    void Update()
    {
       
        ScoreText.text = "Score: " + CarMovement.Score;
    }
}
