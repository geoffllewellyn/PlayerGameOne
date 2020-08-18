using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float startingHealth;

    // not available to other classes
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }
    public void TakeHit (float damage, RaycastHit hit)
    {
        // Do more stuff w/ hit variable in future...
        // ie detect point of hit for projectile. 
        // create fx at that point for a bullet.
        health -= damage;
        if (health <= 0 && !dead) {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !dead) {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null) 
        {
            OnDeath();
        }
        GameObject.Destroy (gameObject);
    }
}