using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Settings")]
    public float gravity = 10f;
    public float deathY = -20f;
    public Transform spawnPoint;

    [Header("Components")]
    public Rigidbody R;

    [Header("State")]
    public int collected;


    // Start is called before the first frame update
    void Start()
    {
        // Components
        R = GetComponent<Rigidbody>();

        transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }

    private void FixedUpdate()
    {
        AddGravity();
    }


    void AddGravity()
    {
        R.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    void CheckDeath()
    {
        if (transform.position.y < deathY)
        {
            R.velocity = Vector3.zero;
            R.angularVelocity = Vector3.zero;
            transform.position = spawnPoint.position;
        }
    }
}