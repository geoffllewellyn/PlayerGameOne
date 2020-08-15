using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {
    public int boundarySize = 1;

    GameObject[] boundary;
    GameObject ground;
    
    // Start is called before the first frame update
    void Start() {
        boundary = GameObject.FindGameObjectsWithTag ("Boundry");
        ground = GameObject.FindGameObjectsWithTag ("Ground")[0];
        
        Vector3 setScale = new Vector3((float)boundarySize, 1, (float)boundarySize);
        
        print(boundary[0].name);
        print(boundary[0].transform.localScale);
    }
}
