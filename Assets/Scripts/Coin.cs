using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed;
  
    private void FixedUpdate()
    {
        transform.Translate(0f, -speed * Time.deltaTime, transform.position.z);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(GameManager.instance != null)
            {
                GameManager.instance.SetCoin();
            }
            else
            {
                Debug.Log("GameManager instance is not Initialized yet");
            }
            Destroy(gameObject);
        }
    }
}
