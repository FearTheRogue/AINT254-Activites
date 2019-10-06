using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public Rigidbody rb;
    public int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxisRaw("Horizontal"))
        //{

        //}


    }
}
