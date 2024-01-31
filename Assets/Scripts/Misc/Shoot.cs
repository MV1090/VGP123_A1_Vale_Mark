using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    SpriteRenderer sr;

    public float projectileSpeed = 7.0f;
    public Transform RightFire;
    public Transform LeftFire;

    public Projectile projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (projectileSpeed <= 0)
        {
            projectileSpeed = 7.0f;
        }
    }

 public void Fire()
    {

        if(!sr.flipX) 
        {
            Projectile curProjectile = Instantiate(projectilePrefab, RightFire.position, RightFire.rotation);
            curProjectile.speed = projectileSpeed; 
            curProjectile.GetComponent<SpriteRenderer>().flipX = true;

        }
        else
        {
            Projectile curProjectile = Instantiate(projectilePrefab, LeftFire.position, LeftFire.rotation);
            curProjectile.speed = projectileSpeed * -1;
         
                
        }
    }



}
