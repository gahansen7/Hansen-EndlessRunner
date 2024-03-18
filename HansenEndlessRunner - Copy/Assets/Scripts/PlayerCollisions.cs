using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerCollisions : MonoBehaviour



{
    public float currentScore = 0f;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D other)


    {
        if (other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            //TO DO connect this to a game Manager and Trigger GameOver();
        }


        if (other.transform.tag == "Collectable")
        {
            gameObject.SetActive(true);
            // global::System.Object value = currentScore + 10f;
            gameManager.currentScore += 10f;
            Destroy(other.gameObject);
        }

    
    }
}
