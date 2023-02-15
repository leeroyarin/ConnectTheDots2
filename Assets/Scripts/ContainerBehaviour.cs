using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour
{
    public event Action OnBallEnter;
    public event Action OnWrongBallEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("answer"))
        {
            OnBallEnter?.Invoke();
        }else if (collision.CompareTag("ball"))
        {
           
            OnWrongBallEnter?.Invoke();
        }
    }


    
}
