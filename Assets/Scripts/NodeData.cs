using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nsMaze;

public class NodeData : MonoBehaviour
{
    private List<GameObject> connectedNodes;

    public void connectNode(GameObject newNode){
        connectedNodes.Add(newNode);
    }

    public void clearNodes(){
        connectedNodes.Clear();
    }
    public bool isConnected(GameObject node){
        return connectedNodes.Contains(node);
    }
}