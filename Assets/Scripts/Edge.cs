using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nsMaze
{
    public class Edge
    {
        //Variable to store points
        private GameObject Node1;
        private GameObject Node2;
        public Edge(GameObject node1, GameObject node2)
        {
            Node1 = node1;
            Node2 = node2;
        }

        public GameObject getNode1(){
            return Node1;
        }

        public GameObject getNode2(){
            return Node2;
        }
    }
}
