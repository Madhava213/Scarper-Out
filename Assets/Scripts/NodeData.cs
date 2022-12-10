using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nsMaze;

public class NodeData : MonoBehaviour
{
    private List<Vector3> connectedNodes = new List<Vector3>();

    public void connectNode(Vector3 newNode){
        connectedNodes.Add(newNode);
    }

    public void clearNodes(){
        connectedNodes.Clear();
    }
    public bool isConnected(Vector3 node){
        return connectedNodes.Contains(node);
    }

    public List<Vector3> getConnections(){
        return connectedNodes;
    }
}