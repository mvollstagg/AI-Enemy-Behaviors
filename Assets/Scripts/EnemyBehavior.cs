using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Range(1, 6f)]
    public float distance = 5f;
    [Range(1, 36)]
    public int count = 1;
    public CharacterMovement characterMovement;
    private int parser;
    private int layerMask = 1 << 8; 
    void Start()
    {
        layerMask = ~layerMask;
        // characterMovement = FindObjectOfType<CharacterMovement>();
    }

    void FixedUpdate()
    {
        parser = 360 / count;
        ScanEnemies();             
    }

    void ScanEnemies()
    {
        RaycastHit hit; 
        for (int i = 0; i <= 360; i += parser)
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward), out hit, distance, layerMask))
            {
                if(hit.collider.tag == "Blue")
                    Debug.DrawRay(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward) * hit.distance, Color.blue);
                else if(hit.collider.tag == "Green")
                    Debug.DrawRay(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward) * hit.distance, Color.green);
                
                characterMovement.DynamicMovement(hit.collider.transform.position);
            }
            else
            {
                characterMovement.StaticMovement();
                Debug.DrawRay(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward) * distance, Color.red);
            }
        }
    }
}
