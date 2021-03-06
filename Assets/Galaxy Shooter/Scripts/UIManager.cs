﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public int score = 0;
    public GameObject titleScreen;

    public void UpdateLives(int currentLifeCount){
        livesImageDisplay.sprite = lives[currentLifeCount];
    }

    public void UpdateScore(){
        score += 10;
        scoreText.text = "Score : " + score;
    }

    public void InitScore(){
        score = 0;
        scoreText.text = "Score : " + score;
    }
    public void ShowTitleDisplay(){
        titleScreen.SetActive(true);
    }    

    public void HideTitleDisplay(){
        InitScore();
        titleScreen.SetActive(false);
    }
}
