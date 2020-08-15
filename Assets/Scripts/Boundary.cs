using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {
    GameObject[] boundary;
    GameObject ground;

    public int boundarySize = 1;

    // Start is called before the first frame update
    void Start() {
        boundary = GameObject.FindGameObjectsWithTag ("Boundry");
        ground = GameObject.FindGameObjectsWithTag ("Ground")[0];
        
    }
}
