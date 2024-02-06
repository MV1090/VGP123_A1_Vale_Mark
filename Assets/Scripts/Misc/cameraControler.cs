using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class cameraControler : MonoBehaviour
{

 
    [SerializeField] public Transform Player;
    [SerializeField] public float aHeadDistance;
    [SerializeField] public float cameraSpeed;
    private float lookAhead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
      transform.position = new Vector3(Player.position.x + lookAhead, transform.position.y, transform.position.z);
      lookAhead = Mathf.Lerp(lookAhead, (aHeadDistance * Player.localScale.x), Time.deltaTime * cameraSpeed);
        
                      
    }
}
