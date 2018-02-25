using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float speed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * speed);	
        if(transform.position.y < -7) {
            transform.position = new Vector3(Random.Range(-7f, 7f), 7, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Laser") {
            if(collision.transform.parent != null) {
                Destroy(collision.transform.parent.gameObject);
            }
            Destroy(collision.gameObject);
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } else if(collision.tag == "Player") {
            collision.GetComponent<Player>().damage();
        }
    }
}
