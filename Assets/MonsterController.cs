using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class MonsterController : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    public float speed = 1f; // Slow movement speed
    public float leftLimit = -5f; // Left boundary
    public float rightLimit = 5f; // Right boundary

    private int direction = 1; // Moving right initially

    void Update()
    {
        // Move the monster
        transform.position += Vector3.right * speed * direction * Time.deltaTime;

        // Check for limits and change direction
        if (transform.position.x >= rightLimit)
        {
            direction = -1; // Move left
        }
        else if (transform.position.x <= leftLimit)
        {
            direction = 1; // Move right
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if player touches the monster
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the scene
        }
    }
}

