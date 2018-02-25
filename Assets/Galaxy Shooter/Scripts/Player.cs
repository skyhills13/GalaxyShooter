using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _laserDistancefromPlayer = 0.88f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleShotPrefab;
    [SerializeField]
    private float _fireInterval = 0.2f;
    private float fireTime = 0.0f;
    public bool isPoweredUp = false;

	// Use this for initialization
    void Start()
    {
        Debug.Log("Hello world!");

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }
    public void TripleShotPowerUpOn(){
        isPoweredUp = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    private IEnumerator TripleShotPowerDownRoutine(){
        yield return new WaitForSeconds(5.0f);
        isPoweredUp = false;
    }

    private void Shoot(){
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if(Time.time > fireTime) {
                if(isPoweredUp) {
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
        this.transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        this.transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);

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