using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float movementDistance;
    public float speed;

    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;



    // Start is called before the first frame update
    void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        movingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingLeft){
            if(transform.position.x > leftEdge){
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else{
                movingLeft = false;
            }
        }
        else{
            if(transform.position.x < rightEdge){
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else{
                movingLeft = true;
            }
        }
<<<<<<< HEAD
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if it's the player
        {
            // collision.transform.SetParent(transform); // Attach player to platform
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if it's the player
        {
            // collision.transform.SetParent(null); // Detach player from platform
            transform.parent = null;
        }
    }
=======
    }
>>>>>>> e6c0d3a97968e72ca9b9bfac556f7d560c4289c5
}
