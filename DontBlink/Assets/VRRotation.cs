using UnityEngine;

public class VRRotation : MonoBehaviour
{
    [Header("Settings")]
    public float rotationSpeed = 60f;
    public float deadzone = 0.1f;

    void Update()
    {
        float leftX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).x;
        float rightX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;

        float turningInput = 0f;

        if (Mathf.Abs(leftX) > Mathf.Abs(rightX))
        {
            turningInput = leftX;
        }
        else
        {
            turningInput = rightX;
        }

        if (Mathf.Abs(turningInput) > deadzone)
        {
            float rotationAmount = turningInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationAmount, 0);
        }
    }
}