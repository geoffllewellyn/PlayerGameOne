using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform target;

    // Start is called before the first frame update
    void Start() 
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform ;

        StartCoroutine (UpdatePath ());
    }

    // Update is called once per frame
    void Update() 
    {
        // potentiall expensive task...
        // pathfinder.SetDestination (target.position);
    }

    IEnumerator UpdatePath() {
        float refreshRate = 1/8f;

        while (target != null) {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination (targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}