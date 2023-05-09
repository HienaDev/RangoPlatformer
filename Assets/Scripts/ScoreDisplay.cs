using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    private ScoreMNG        scoreMNG;

    // Start is called before the first frame update
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        scoreMNG = FindObjectOfType<ScoreMNG>();
    }

    // Update is called once per frame
    private void Update()
    {
        //scoreText.text = $"Score: {scoreMNG.GetScore()}";
    }
}
