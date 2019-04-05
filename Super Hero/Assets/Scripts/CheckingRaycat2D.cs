using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingRaycat2D : MonoBehaviour
{
    public float rayLength;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        Ray();
    }
    void Ray()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.left, rayLength);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.name == "Player")
            {
                Debug.DrawRay(transform.position, Vector2.left * rayLength, Color.green);
                Debug.Log(hit2D.collider.gameObject.name);
                Destroy(hit2D.collider.gameObject,2f);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.left * 10f, Color.red);
        }
    }
}
