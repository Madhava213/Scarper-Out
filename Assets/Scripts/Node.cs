using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nsMaze
{
    public class Node
    {
        //Variable to store if the current node is path
        public bool freeSpace = true;
        public Vector2 position = new Vector2(0,0);
        public Node(Vector2 pos)
        {
            //Initialized the cell as not used and not connected.
            freeSpace = true;
            position = pos;
        }

        public void setNodeTrue(){
            freeSpace = true;
        }

        public void setNodeFalse(){
            freeSpace = false;
        }
        
        public bool isFreeSpace(){
            return freeSpace;
        }
    }
}
