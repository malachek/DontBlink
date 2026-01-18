using UnityEngine;
using UnityEngine.UI;

public class SpriteAnim : MonoBehaviour
{
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    [SerializeField] Image image;
    [SerializeField] float frameRate = 0.3f;
    [SerializeField] bool offsetStart = false;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            image.sprite = sprite1;
            timer = frameRate + (offsetStart ? .15f : .0f);
    }

    // Update is called once per frame

    void Update()
    {
        if ((timer -= Time.deltaTime) <= 0)
        {
            timer = frameRate;
            if (image.sprite == sprite1)
            {
                image.sprite = sprite2;
            }
            else
            {
                image.sprite = sprite1;
            }
        }
    }
}
