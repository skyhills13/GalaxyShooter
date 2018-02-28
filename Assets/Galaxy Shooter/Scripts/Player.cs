using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _laserDistancefromPlayer = 0.88f;
    [SerializeField]
    private GameObject explosionPrefab;
	[SerializeField]
	private GameObject tripleShotPrefab;
    [SerializeField]
    private GameObject laserPrefab;
	[SerializeField]
    private GameObject shieldsGameObject;

    private UIManager uiManager;
    private GameManager gameManager;

    private float _fireInterval = 0.2f;
    private float fireTime = 0.0f;

    private bool isShotTripled = false;
    private bool isSpeedBoosted = false;
    private bool shieldActive = false;

    private int score;


    // Use this for initialization
    void Start()
    {
        Debug.Log("Hello world!");
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(uiManager == null || gameManager == null) {
            throw new UnityException();
        }
        uiManager.UpdateLives(lives);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }


	public void ActivateShields(){
		shieldActive = true;
		shieldsGameObject.SetActive(true);
	}
	
    public void Damage(){
        if(shieldActive) {
            shieldActive = false;
            shieldsGameObject.SetActive(false);
			return;
		}
		
		lives--;
		uiManager.UpdateLives(lives);
		if(lives <= 0) {
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
            gameManager.gameOver = true;
            uiManager.ShowTitleDisplay();
		}
	}
    public void TripleShotPowerUpOn(){
        isShotTripled = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedPowerUpOn(){
        isSpeedBoosted= true;
        StartCoroutine(SpeedPowerDownRoutine());
    }

    private IEnumerator SpeedPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoosted = false;
    }

    private IEnumerator TripleShotPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        isShotTripled = false;
    }

    private void Shoot(){
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if(Time.time > fireTime) {
                if(isShotTripled == true) {
                    Instantiate(tripleShotPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
                } else {
					Instantiate(laserPrefab, new Vector3(this.transform.position.x, this.transform.position.y + _laserDistancefromPlayer, 0), Quaternion.identity);
                }
                fireTime = Time.time + _fireInterval;
            }
        }
    }

    private void Movement()
    {
        //When push the up direction key completely, it goes 1. 
        //So this variable decides the directions.
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float boostedDegree = 1.0f;
        if(isSpeedBoosted) {
            boostedDegree = 2.0f;
        }
        this.transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput * boostedDegree);
        this.transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput * boostedDegree);
        CheckEdge();
    }

    private void CheckEdge(){
		float xBound = 9.5f;
		float yBound = 4.5f;
		if (this.transform.position.x >= xBound)
		{
			this.transform.position = new Vector3(-xBound, this.transform.position.y, 0);
		}
		else if (this.transform.position.x <= -xBound)
		{
			this.transform.position = new Vector3(xBound, this.transform.position.y, 0);
		}
		
		if (this.transform.position.y <= -yBound)
		{
			this.transform.position = new Vector3(this.transform.position.x, -yBound, 0);
		}
		else if (this.transform.position.y >= 0)
		{
			this.transform.position = new Vector3(this.transform.position.x, 0, 0);
    	}
    }
}