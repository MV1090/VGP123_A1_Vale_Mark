using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PickUp : MonoBehaviour
{
    Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
        }
                
    }
}

