using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    [Header("Billboard Settings")]
    public bool lockYAxis = false;
    public bool autoFindCamera = true;
    public Transform targetCamera;

    [Header("Hover Settings")]
    [Tooltip("How fast it bobs up and down")]
    public float hoverSpeed = 2.0f;

    [Tooltip("How far it moves from its starting position")]
    public float hoverDistance = 0.1f;

    private float initialLocalY;

    void Start()
    {
        initialLocalY = transform.localPosition.y;

        if (autoFindCamera && Camera.main != null)
        {
            targetCamera = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        if (targetCamera != null)
        {
            if (lockYAxis)
            {
                Vector3 direction = targetCamera.position - transform.position;
                direction.y = 0; 
                if (direction.sqrMagnitude > 0.001f)
                {
                    transform.rotation = Quaternion.LookRotation(-direction);
                }
            }
            else
            {
                transform.rotation = targetCamera.rotation;
            }
        }

        float newY = initialLocalY + (Mathf.Sin(Time.time * hoverSpeed) * hoverDistance);

        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}