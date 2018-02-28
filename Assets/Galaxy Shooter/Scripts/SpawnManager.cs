using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] powerUps;

    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SpawnObjects(){
		StartCoroutine(GenerateEnemy());
		StartCoroutine(GeneratePowerUps());
    }

    IEnumerator GeneratePowerUps(){
        while(!gameManager.gameOver) {
			int randomPowerUpId = Random.Range(0, powerUps.Length);
			Instantiate(powerUps[randomPowerUpId], new Vector3(Random.Range(-7f, 7f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator GenerateEnemy(){
        while (!gameManager.gameOver){
            Instantiate(enemy, new Vector3(Random.Range(-7f, 7f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
