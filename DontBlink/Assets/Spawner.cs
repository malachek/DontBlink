using UnityEngine;
using UnityEngine.Events; 
public class Spawner : MonoBehaviour
{
    [SerializeField] private float requiredDuration = 0.5f;

    public UnityEvent activated;

    private bool isLooking = false;
    private float currentTimer;

    void OnEnable()
    {
        ResetTimer();
    }

    public void LookAt()
    {
        isLooking = true;
    }

    public void StopLook()
    {
        isLooking = false;
        ResetTimer();
    }

    public void ActivateSpawn()
    {
        activated?.Invoke();
    }

    private void ResetTimer()
    {
        currentTimer = requiredDuration;
    }

    void Update()
    {
        if (isLooking)
        {
            currentTimer -= Time.deltaTime;
            transform.position -= new Vector3(0, 1f * Time.deltaTime, 0); // downward movement

            if (currentTimer <= 0f)
            {
                Debug.Log("Looked at for duration");

                activated?.Invoke();

                isLooking = false;
            }
        }
    }
}