using UnityEngine;

public enum Hand
{
    right,
    left
}

public class ScaleAnimation : MonoBehaviour
{
    public Hand hand;
    public float minSize;
    public float maxSize;

    bool isGrowing = false;
    float growingSpeedX = 0.01f;
    float growingSpeedY = 0.01f;

    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (hand == Hand.right)
            growingSpeedX = -growingSpeedX;
    }

    void Update()
    {
        if (rectTransform.localScale.y < minSize && !isGrowing)
            isGrowing = true;

        if (rectTransform.localScale.y > maxSize && isGrowing)
            isGrowing = false;

        if (isGrowing)
            rectTransform.localScale += new Vector3(growingSpeedX, growingSpeedY);
        else
            rectTransform.localScale -= new Vector3(growingSpeedX, growingSpeedY);
    }
}
