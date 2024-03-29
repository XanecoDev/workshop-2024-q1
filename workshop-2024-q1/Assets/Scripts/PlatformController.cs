using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformController : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 8f;
    public float maxAngle = 45f;

    [Header("Input")]
    public Vector2 rotateInput;

    [Header("Components")]
    public Rigidbody R;


    // Start is called before the first frame update
    void Start()
    {
        // Components
        R = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        CalculateAngularVelocity();
        LimitRotation();
    }


    void GetInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        rotateInput = new Vector2 (xInput, zInput);
    }

    void CalculateAngularVelocity()
    {
        float xVel = rotateInput.x * maxAngle;
        float zVel = rotateInput.y * maxAngle;

        if ((IsAngleInUpperHalf(transform.eulerAngles.x) && xVel > 0)
        || (IsAngleInLowerHalf(transform.eulerAngles.x) && xVel < 0))
            xVel = 0;

        if ((IsAngleInUpperHalf(transform.eulerAngles.z) && zVel > 0)
        || (IsAngleInLowerHalf(transform.eulerAngles.z) && zVel < 0))
            zVel = 0;

        Vector3 targetVelocity = new Vector3(xVel, 0, zVel) * rotationSpeed * Time.fixedDeltaTime;

        R.angularVelocity = targetVelocity;
    }

    bool IsAngleInUpperHalf(float angle)
    {
        return angle > maxAngle && angle < (180 - maxAngle);
    }

    bool IsAngleInLowerHalf(float angle)
    {
        return angle < (360 - maxAngle) && angle > (180 + maxAngle);
    }

    void LimitRotation()
    {
        Vector3 finalRotation = transform.eulerAngles;
        finalRotation.y = 0;
        R.MoveRotation(Quaternion.Euler(finalRotation));
    }
}