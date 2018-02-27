using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 0.8f;
    [SerializeField]
    private int powerUpId; //0:tripleshot 1: speed 2: shield

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
                switch (powerUpId){
                    case 0:
                        player.TripleShotPowerUpOn();
                        break;
                    case 1:
                        player.SpeedPowerUpOn();
                        break;
                    case 2:
                        player.ActivateShields();
                        break;
                    default:
                        Debug.Log("Error handling");
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
