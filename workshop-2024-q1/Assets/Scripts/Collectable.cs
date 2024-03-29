using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 360f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y += rotationSpeed * Time.deltaTime;
        transform.eulerAngles = newRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            ball.collected++;
            Destroy(gameObject);
        }
    }
}
