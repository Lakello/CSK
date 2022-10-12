using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1f;
    public float FlightTime = 3f;

    void FixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
