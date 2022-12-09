using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nsMaze;

public class GameManager : MonoBehaviour
{
    public List<GameObject> allNodes;
    public List<nsMaze.Edge> allEdges;
    private List<int> pathNodes;
    public GameObject Player;
    public GameObject Goal;
    public AStarAlgorithm AStarAlgorithm;

    void Start()
    {
        AStarAlgorithm = this.gameObject.GetComponent<AStarAlgorithm>();
    }

    public void runAStar(){
        List<Vector3> allNodePositions = new List<Vector3>();

        float playerDis = -1.0f;
        float goalDis = -1.0f;

        int startIndex = 0;
        int goalIndex = 0;

        foreach (GameObject node in allNodes)
        {
            float distanceToPlayer = Vector3.Distance(node.transform.position,Player.transform.position);
            float distanceToGoal = Vector3.Distance(node.transform.position,Player.transform.position);

            if(playerDis == -1.0f || distanceToPlayer < playerDis){
                startIndex = allNodes.IndexOf(node);
                playerDis = distanceToPlayer;
            }

            if(goalDis == -1.0f || distanceToGoal < goalDis){
                goalIndex = allNodes.IndexOf(node);
                goalDis = distanceToGoal;
            }
            allNodePositions.Add(node.transform.position);

        }
        pathNodes = AStarAlgorithm.AStar(goalIndex, startIndex, allNodePositions, allEdges);

        foreach (int nodeIndex in pathNodes)
        {
                allNodes[nodeIndex].transform.GetChild(0).gameObject.SetActive(true);
                allNodes[nodeIndex].transform.GetChild(1).gameObject.SetActive(true);
            
        }
    }

    public void resetPath(){
        foreach (int nodeIndex in pathNodes)
        {
                allNodes[nodeIndex].transform.GetChild(0).gameObject.SetActive(false);
                allNodes[nodeIndex].transform.GetChild(1).gameObject.SetActive(false);
            
        }
    }
    public void setEdges()
    {
        foreach (GameObject node in allNodes)
        {
            node.GetComponent<NodeData>().clearNodes();
            foreach (GameObject nodeAlt in allNodes)
            {
                if (node != nodeAlt)
                {
                    RaycastHit hit;
                    Vector3 rayDir = (nodeAlt.transform.position - node.transform.position).normalized;
                    float rayDis = Vector3.Distance(node.transform.position, nodeAlt.transform.position);
                    if (Physics.Raycast(transform.position, rayDir, out hit, rayDis))
                    {
                        if (hit.collider.gameObject.tag == "Node")
                        {
                            if (!node.GetComponent<NodeData>().isConnected(nodeAlt))
                            {
                                allEdges.Add(new nsMaze.Edge(node, nodeAlt));
                                node.GetComponent<NodeData>().connectNode(nodeAlt);
                                nodeAlt.GetComponent<NodeData>().connectNode(node);
                            }
                        }
                    }
                }
            }
        }
    }
}
