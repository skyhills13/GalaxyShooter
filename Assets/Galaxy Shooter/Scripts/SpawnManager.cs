using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] powerUps;

	// Use this for initialization
	void Start () {
		StartCoroutine(GenerateEnemy());
		StartCoroutine(GeneratePowerUps());
    }

    IEnumerator GeneratePowerUps(){
        while(true) {
			int randomPowerUpId = Random.Range(0, powerUps.Length);
			Instantiate(powerUps[randomPowerUpId], new Vector3(Random.Range(-7f, 7f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator GenerateEnemy(){
        while(true) {
            Instantiate(enemy, new Vector3(Random.Range(-7f, 7f), 7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
