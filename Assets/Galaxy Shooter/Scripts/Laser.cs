using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float speed = 10.0f;

    private float destroyCriteriaY = 5.44f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(this.transform.position.y > destroyCriteriaY ) {
            Destroy(this.gameObject);
        }
	}
}
