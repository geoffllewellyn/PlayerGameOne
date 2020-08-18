using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;

    public float maxBulletDistance = 20;
    float lifetime = 3;

    void Start() 
    {
        Destroy (gameObject, lifetime);
        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, 0.1f, collisionMask);
        if (initialCollisions.Length > 0)
        {
            OnHitObject(initialCollisions[0]);
        }
    }

    public void SetSpeed (float newSpeed) 
    {
        speed = newSpeed;
    }

    void Update () 
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions (moveDistance);
        transform.Translate (Vector3.forward * moveDistance);
    }

    void CheckCollisions (float moveDistance) 
    {
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit, moveDistance, 
                            collisionMask, QueryTriggerInteraction.Collide))
        {
            // print("HIT");
            OnHitObject (hit);
        }

        if (Mathf.Abs(transform.position.x) > maxBulletDistance |
            Mathf.Abs(transform.position.z) > maxBulletDistance
            )
        {
            GameObject.Destroy (gameObject);
        }
    }

    void OnHitObject (RaycastHit hit)
    {
        // print("HIT");
        print(hit.collider.gameObject.name);
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit (damage, hit);
        }
        GameObject.Destroy (gameObject);
    }

    void OnHitObject (Collider collider)
    {
        IDamageable damageableObject = collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage (damage);
        }
        GameObject.Destroy (gameObject);
    }

}
