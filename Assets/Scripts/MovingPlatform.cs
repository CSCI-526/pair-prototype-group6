using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startPoint;
    public Transform[] points;  // points where platform needs to move

    private int i;  // index of array

    // Start is called before the first frame update
    void Start()
    {
        // setting the position of platform to the position of one of the points using index "startIndex"
        transform.position = points[startPoint].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check the distance between platform and point
        if(Vector2.Distance(transform.position, points[i].position) < 10f){
            i++;
            // check if platform on last point
            if(i == points.Length){
                i = 0;
            }
        }

        // moving the platform to ith position
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    } 

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collisionInfo.transform.SetParent(transform);
    }

    // private void OnCollisionExit2D(Collision2D collisionInfo)
    // {
    //     collisionInfo.transform.SetParent(null);
    // }
}
