using UnityEngine;

public class ToggleObjectStationary : MonoBehaviour
{
    [SerializeField] GameObject toggle1;
    [SerializeField] GameObject toggle2; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggle1.SetActive(true);
        toggle2.SetActive(false);
    }

    private bool canToggle = true;
    
    public void TogglePermanent()
    {
        if (!canToggle) return;
        canToggle = false;
        toggle1.SetActive(!toggle1.activeSelf);
        toggle2.SetActive(!toggle2.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
