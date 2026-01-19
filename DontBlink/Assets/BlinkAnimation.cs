using UnityEngine;
using UnityEngine.Playables;

public class BlinkAnimation : MonoBehaviour
{
    [SerializeField] Sprite closeEye1;
    [SerializeField] Sprite closeEye2;
    [SerializeField] Sprite openingEye;
    [SerializeField] Sprite openEye1;
    [SerializeField] Sprite openEye2;

    [SerializeField] SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.sprite = openEye1;
        timer = .3f;
    }
    float timer = .3f;

    bool isLookedAt = false;
    // Update is called once per frame
    void Update()
    {
        if ((timer -= Time.deltaTime) <= 0)
        {
            timer = .3f;
            if (isLookedAt)
            {
                if (spriteRenderer.sprite == openEye1)
                {
                    spriteRenderer.sprite = openEye2;
                }
                else
                {
                    spriteRenderer.sprite = openEye1;
                }
            }
            else
            {
                if (spriteRenderer.sprite == closeEye1)
                {
                    spriteRenderer.sprite = closeEye2;
                }
                else
                {
                    spriteRenderer.sprite = closeEye1;
                }
            }
        }
    }

    public void LookedAt()
    {
        isLookedAt = true;
    }

    public void LookedAwayFrom()
    {
        isLookedAt = false;
    }
}
