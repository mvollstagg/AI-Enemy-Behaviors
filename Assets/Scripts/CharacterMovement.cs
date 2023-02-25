using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 1f;
    [HideInInspector]
    public bool isFollowing = false;
    [HideInInspector]
    public Vector3 enemyPosition;
    void Update()
    {
        // Debug.Log("Status: " + isFollowing);
        // if(!isFollowing)
        //     StaticMovement();
        // else
        //     DynamicMovement(enemyPosition);
    }

    public void StaticMovement()
    {
        float scale = 4 / (3 - Mathf.Cos(speed * Time.time));
        transform.position = new Vector3(scale * Mathf.Cos(Time.time), 0, scale * Mathf.Sin(speed * Time.time) / 2);
    }

    public void DynamicMovement(Vector3 enemyPosition)
    {
        // Debug.Log(enemyPosition);
        transform.localPosition = Vector3.Lerp(transform.position, enemyPosition, 0.01f);
    }
}
