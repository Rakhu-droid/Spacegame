using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSwipeScript : MonoBehaviour
{
    Vector2 _Start_Touch_Position;
    Vector2 _End_Touch_Position;

    [SerializeField] GameObject Shield;

    public bool HasShielded = false;

    private void Update()
    {
        TouchControls();
    }

    private void TouchControls()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _Start_Touch_Position = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _End_Touch_Position = Input.GetTouch(0).position;

            if (_End_Touch_Position.x < _Start_Touch_Position.x)
            {
                transform.position = new Vector3(transform.position.x - 1f, transform.position.y);
            }
            if (_End_Touch_Position.x > _Start_Touch_Position.x)
            {
                transform.position = new Vector3(transform.position.x + 1f, transform.position.y);
            }
        }
    }

    public void MakeShield()
    {
        HasShielded = true;
        Shield.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(ShieldCoroutine());
    }

    IEnumerator ShieldCoroutine()
    {
        yield return new WaitForSeconds(6f);
        Shield.SetActive(false);
        HasShielded = false;
    }
}
