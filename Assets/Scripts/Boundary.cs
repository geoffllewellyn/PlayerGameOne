﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Boundary : MonoBehaviour 
{
    public int boundarySize = 1;
    GameObject map;
    
    // Start is called before the first frame update
    void Start() 
    {
        map = GameObject.FindGameObjectWithTag ("Map");
        float newX = map.transform.localScale.x * boundarySize;
        float newZ = map.transform.localScale.z * boundarySize;
        map.transform.localScale = new Vector3 (newX, 1, newZ);
        
        AddNavMeshData();
    }

    void Update() {
        // maybe refresh if something makes the map change mid game...?
    }
    
    void AddNavMeshData() {
        // now rebake the AI Enemy walkable mesh area...
    }
}