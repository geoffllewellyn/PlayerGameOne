using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    int shotsFired = 0;
    public Transform muzzle;
    public Projectile projectile;
    public float msBetweenShots = 200;
    public float muzzleVelocity = 45;

    float nextShotTime;

    public void Shoot() 
    {
        if (Time.time > nextShotTime) 
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, 
                                                muzzle.position,
                                                muzzle.rotation
                                                ) as Projectile;
            newProjectile.SetSpeed(muzzleVelocity);
            shotsFired++;
            print(shotsFired);
        }
    }
}