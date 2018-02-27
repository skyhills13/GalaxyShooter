﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public int score;

    public void UpdateLives(int currentLifeCount){
        livesImageDisplay.sprite = lives[currentLifeCount];
    }

    public void UpdateScore(){
        score += 10;
        scoreText.text = "Score : " + score;
    }
}
