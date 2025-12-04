using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
 //public variable used to determine the fall height
    public float deathY = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= deathY){

            Scene scene = SceneManager.GetActiveScene();

            Debug.Log("I fell");
            Destroy(gameObject);
            SceneManager.LoadScene(scene.name);
        }
        
    }
}
