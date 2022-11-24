using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject Player;
    public ParticleSystem FireParticles;
    public bool onFire = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        FireParticles.Stop();
    }
    private void Update()
    {
        RaycastHit hit;
        Vector3 playerDir = Player.transform.position - this.transform.position;
        if (Physics.Raycast(transform.position, playerDir.normalized, out hit, playerDir.magnitude))
        {
            if(!onFire && hit.collider.gameObject.tag == "Player"){
                transform.position = Vector3.Lerp(transform.position, hit.collider.gameObject.transform.position, 0.05f);
                FireParticles.Play();
                onFire = true;
            }
            else if(onFire){
                onFire = false;
                FireParticles.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player"){
            MazeGenerator mazeScript = other.gameObject.GetComponent<MazeGenerator>();
            other.gameObject.transform.position = new Vector3(Random.Range(0, mazeScript.height) * 2 * mazeScript.wallSeparation,  mazeScript.wallHeight / 2, Random.Range(0,  mazeScript.width) * 2 *  mazeScript.wallSeparation);
            Destroy(this.gameObject);
        }
    }
}
