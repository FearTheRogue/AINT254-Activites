using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5.0f;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        // Walk Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, 5), ForceMode.VelocityChange);
            //rb.rotation = Quaternion.LookRotation(Vector3.forward);
            //transform.position += Vector3.forward * Time.deltaTime * speed;
        }

        // Walk Backwards
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -5), ForceMode.VelocityChange);
            //rb.rotation = Quaternion.LookRotation(Vector3.back);
            //transform.position += Vector3.back * Time.deltaTime * speed;   
        }

        // Walk Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-5, 0, 0), ForceMode.VelocityChange);
            //rb.rotation = Quaternion.LookRotation(Vector3.left);
            //transform.position += Vector3.left * Time.deltaTime * speed;
        }

        // Walk Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(5, 0, 0), ForceMode.VelocityChange);
            //rb.rotation = Quaternion.LookRotation(Vector3.right);
            //transform.position += Vector3.right * Time.deltaTime * speed;
        }

    }
}
