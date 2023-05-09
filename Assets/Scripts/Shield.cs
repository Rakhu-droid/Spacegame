using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
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
            collision.gameObject.GetComponent<SpaceShipSwipeScript>().MakeShield();
            Destroy(gameObject);
        }
    }
}
