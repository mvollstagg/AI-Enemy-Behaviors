using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Range(1, 6f)]
    public float distance = 5f;
    [Range(1, 36)]
    public int count = 1;
    private bool isScanning = true;
    private Transform enemyTransform;
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
        if(isScanning)
            ScanEnemies();
    }

    private void OnTriggerStay(Collider target) {
        Debug.LogWarning(target.name+ " is discovered...");
        enemyTransform = target.transform;
        isScanning = false;
        FollowEnemy();
    }
    void ScanEnemies()
    {
        characterMovement.StaticMovement();
        // RaycastHit hit; 
        // for (int i = 0; i <= 360; i += parser)
        // {
        //     if(Physics.Raycast(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward), out hit, distance, layerMask))
        //     {
        //         if(hit.collider.tag == "Blue")
        //         {
        //             Debug.DrawRay(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward) * hit.distance, Color.blue);
        //             FollowEnemy();
        //             break;
        //         }
                    
        //         else if(hit.collider.tag == "Green")
        //         {
        //             Debug.DrawRay(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward) * hit.distance, Color.green);
        //             FollowEnemy();
        //             break;
        //         }
                    
        //         // characterMovement.DynamicMovement(hit.collider.transform.position);
        //     }
        //     else
        //     {
        //         characterMovement.StaticMovement();
        //         Debug.DrawRay(transform.position, transform.TransformDirection(Quaternion.Euler(0,i,0) * transform.forward) * distance, Color.red);
        //     }
        // }
    }

    void FollowEnemy()
    {
        Debug.Log("Undefined object is following...");
        RaycastHit hit; 
        if(Physics.Raycast(transform.position, enemyTransform.position, out hit, distance, layerMask))
        {
            if(hit.collider.tag == "Blue")
            {
                Debug.DrawRay(transform.position, enemyTransform.position, Color.blue, 3f);
            }
            else if(hit.collider.tag == "Green")
            {
                Debug.DrawRay(transform.position, enemyTransform.position, Color.green, 3f);
            }
                
            characterMovement.StaticMovement();
        }
        else
        {
            Debug.DrawRay(transform.position, enemyTransform.position, Color.red, 3f);
        }
        characterMovement.DynamicMovement(enemyTransform.position);
    }
}