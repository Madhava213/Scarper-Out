using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            if(this.gameObject.tag == "SpeedPowerUp"){
                other.gameObject.GetComponent<PlayerMovement>().PowerUpSpeed();
            }
            else if(this.gameObject.tag == "LightPowerUp"){
                other.gameObject.GetComponent<PlayerMovement>().PowerUpLighting();
            }
            else if(this.gameObject.tag == "PathPowerUp"){
                other.gameObject.GetComponent<PlayerMovement>().PowerUpPath();
            }
            Destroy(this.gameObject);
        }
    }
}
