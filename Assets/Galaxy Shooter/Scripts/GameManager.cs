using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver = true;

    public GameObject playerPrefab;

    private UIManager uiManager;

    void Start() {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

	// Update is called once per frame
	void Update () {
        if(gameOver && Input.GetKey(KeyCode.Space)){
            uiManager.HideTitleDisplay();
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            gameOver = false;
        }
	}
}
