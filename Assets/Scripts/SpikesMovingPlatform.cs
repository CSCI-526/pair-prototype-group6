using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesMovingPlatform : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision with: " + other.gameObject.name);
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

   
}
