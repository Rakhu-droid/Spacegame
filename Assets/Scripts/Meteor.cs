using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
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
            if (collision.gameObject.GetComponent<SpaceShipSwipeScript>().HasShielded)
                return;

            else
            {
                GameManager.instance.PlayerDied();
                SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
                sr.enabled = false;
                collision.gameObject.GetComponent<SpaceShipSwipeScript>().enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
