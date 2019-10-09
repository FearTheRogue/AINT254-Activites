using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1000f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
    }

    private void OnBecameInvisible()
    {
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
