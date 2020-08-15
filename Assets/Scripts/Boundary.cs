using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour 
{
    public int boundarySize = 1;

    GameObject[] boundary;
    GameObject ground;
    
    // Start is called before the first frame update
    void Start() 
    {
        // GameObjects set up. boundary is the invisible box colliders in "WALLS"
        boundary = GameObject.FindGameObjectsWithTag ("Boundry");
        ground = GameObject.FindGameObjectsWithTag ("Ground")[0];
        
        // set up scales for angles parts.
        float newScale = (float)boundarySize * 10;
        float offsetScale = 2;

        // loop through the walls.
        // North, South, East and West
        for (int i = 0; i < 4; i++) 
        {
            float offsetX = 0;
            float offsetZ = 0;
            if (i % 2 == 0) // first and third objects
            {
                boundary[i].transform.localScale = new Vector3(newScale, 10, 1);
                if (boundary[i].name == "North") 
                {
                    offsetZ = -(boundarySize - offsetScale) * 0;
                }
                else if (boundary[i].name == "South") 
                {
                    offsetZ = (boundarySize - offsetScale) * 0;
                }
            }
            else 
            {
                boundary[i].transform.localScale = new Vector3(1, 10, newScale);
                if (boundary[i].name == "East") 
                {
                    offsetX = -(boundarySize - offsetScale);
                }
                else if (boundary[i].name == "West") 
                {
                    offsetX = (boundarySize - offsetScale);
                }
            }
            float newX = (boundary[i].transform.position.x * boundarySize) + offsetX;
            float newY = boundary[i].transform.position.y;
            float newZ = (boundary[i].transform.position.z * boundarySize) + offsetZ;
            boundary[i].transform.position = new Vector3(newX, newY, newZ);
        }

        for (int i = 4; i < boundary.Length; i++) 
        {
            float newX = boundary[i].transform.position.x * boundarySize;
            float newY = boundary[i].transform.position.y * 1;
            float newZ = boundary[i].transform.position.z * boundarySize;
            boundary[i].transform.position =  new Vector3(newX, newY, newZ);
        }

        ground.transform.localScale = new Vector3 ( (float)boundarySize, 1, (float)boundarySize);

        // now reback the AI walkable mesh area...
        
    }

    void Update() {
        // maybe refresh if something makes the map change mid game...?
    }
}
