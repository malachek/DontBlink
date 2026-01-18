using UnityEngine;

public class LookAtDuration : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        
    }
    bool looking = false;
    float timer = .5f;
    public void LookAt()
    {
        looking = true;
    }
    public void StopLook()
    {
        timer = .5f;
        looking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(looking)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                Debug.Log("Looked at for duration");
                looking = false;
            }
        }
    }

    public delegate void LookAtEvent();
    public LookAtEvent onLookedAtDuration;
}
