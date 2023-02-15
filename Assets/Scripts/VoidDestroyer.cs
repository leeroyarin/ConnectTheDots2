using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDestroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("answer"))
        {
            FindObjectOfType<GameManager>().ShowGameOver();
        }
        Destroy(collision.gameObject);
    }
}
