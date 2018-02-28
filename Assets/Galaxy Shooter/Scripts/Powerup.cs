using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int powerUpId; //0:tripleshot 1: speed 2: shield
    [SerializeField]
    private AudioClip audioClip;
	
    void Update () {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y < -7) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag =="Player") {
            Player player = collision.GetComponent<Player>();

            if(player != null) {
                switch (powerUpId){
                    case 0:
                        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
                        player.TripleShotPowerUpOn();
                        break;
                    case 1:
                        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
                        player.SpeedPowerUpOn();
                        break;
                    case 2:
                        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, 1f);
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
