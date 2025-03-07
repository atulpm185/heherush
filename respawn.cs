using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if(Collision.gameObject.name == "player")
        {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
