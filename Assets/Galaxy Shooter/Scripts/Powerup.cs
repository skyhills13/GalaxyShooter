using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
	}

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag =="Player") {
			Player player = collision.GetComponent<Player>();

            if(player != null) {
				player.TripleShotPowerUpOn();                
			}
		    
            Destroy(this.gameObject);
        }
    }
}
