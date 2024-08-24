using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Text Object for Displaying Score")]
    public Text scoreText;

    public int souls;

    void Update()
    {
        souls = GameObject.FindGameObjectsWithTag("Collectable").Length;
        scoreText.text = "Souls Left: " + souls.ToString();
    }
}