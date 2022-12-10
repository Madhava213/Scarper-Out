using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nsMaze
{
    public class Edge
    {
        //Variable to store points
        private Vector3 Node1;
        private Vector3 Node2;
        public Edge(Vector3 node1, Vector3 node2)
        {
            Node1 = node1;
            Node2 = node2;
        }

        public Vector3 getNode1(){
            return Node1;
        }

        public Vector3 getNode2(){
            return Node2;
        }
    }
}
