using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
public class Player : MonoBehaviour {
    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    void Start() {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

    void PrintLoc(float x, float y, float z) {
        // Temp, remove later: Print location vector
        string _msg = string.Format("\nX: {0}\nY: {1}\nZ: {2}", 
                                    x,
                                    y,
                                    z
                                    );
        // Debug.Log(_msg);
    }

    // update is called every frame
    void Update() {
        float x = Mathf.Abs (controller.transform.position.x);
        float y = Mathf.Abs (controller.transform.position.y);
        float z = Mathf.Abs (controller.transform.position.z);
        PrintLoc(x, y, z);
        
        // Movement Input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        if (x > 4) {
            moveVelocity = moveVelocity * 1;
            print("X EDGE!");
        }
        else if (z > 4) {
            moveVelocity = moveVelocity * 1;
            print("Y EDGE!");
        }
        controller.Move(moveVelocity);

        // Look input
        // returns a ray from camera to the mouse position
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPland = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPland.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            // Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        // Weapon Input
        if (Input.GetKey("space") || Input.GetMouseButton(0)) {
            gunController.Shoot();
        }
    }
}