using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    public float pointA = -3f; // Leftmost position
    public float pointB = 3f;  // Rightmost position
    private float target;


    // Start is called before the first frame update
    void Start()
    {
        target = pointB;  // Start moving towards pointB
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(
            Mathf.MoveTowards(transform.position.x, target, speed * Time.deltaTime),
            transform.position.y,
            transform.position.z
        );

        // Switch direction when reaching the target
        if (Mathf.Abs(transform.position.x - target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
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
}
