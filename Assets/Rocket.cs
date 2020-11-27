using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour

{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    
    public Rigidbody rb;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("ok");
                break;
            case "Fuel":
                print("ok");
                break;
            default:
                print("dead");
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        Rotate();
        Thrust();
    }
    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // relative force goes up in the way it is pointing
            rb.AddRelativeForce(Vector3.up*mainThrust);
            if(!audio.isPlaying)
            {
                audio.Play();
            } 
            else 
            {
                audio.Stop();
            }
        }
    }



    private void Rotate()
    {
        rb.freezeRotation = true;
        
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }
        rb.freezeRotation = false;
    }
}
