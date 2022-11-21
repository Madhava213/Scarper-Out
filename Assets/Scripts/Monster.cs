using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject skeleton;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player"){
            MazeGenerator mazeScript = other.gameObject.GetComponent<MazeGenerator>();
            other.gameObject.transform.position = new Vector3(Random.Range(0, mazeScript.height) * 2 * mazeScript.wallSeparation,  mazeScript.wallHeight / 2, Random.Range(0,  mazeScript.width) * 2 *  mazeScript.wallSeparation);
            Destroy(this.gameObject);
        }
    }
}
