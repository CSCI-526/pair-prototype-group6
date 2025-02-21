using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoboBullet : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public Vector2 direction = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime); // Move forward
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player Hit!"); 
            // Add damage logic here
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (!other.CompareTag("Enemy")) // Prevent bullets from destroying enemy
        {
            Destroy(gameObject);
        }
    }
}
