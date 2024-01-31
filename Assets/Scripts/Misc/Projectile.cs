using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{

    SpriteRenderer sr;
 
    public float lifeTime;
    [HideInInspector] public float speed;


    // Start is called before the first frame update
    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
      

        if (lifeTime <= 0)
        {
            lifeTime = 2.0f;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);

        Destroy(gameObject, lifeTime);

 
    }

    

}
