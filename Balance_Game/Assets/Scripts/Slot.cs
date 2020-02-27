using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Slot : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    int quickArrows = 0;
    int strongArrows = 0;

    [SerializeField] ArrowIndicator upIndicator;
    [SerializeField] ArrowIndicator downIndicator;
    [SerializeField] GameObject fastIndicator;

    float fastIndicatorY;

    public float MaxY { get; private set; } = .0f;

    public enum Direction : int
    {
        Up = 1,
        Down = -1
    }

    void Start()
    {
        fastIndicatorY = fastIndicator.transform.position.y;
    }

    void Update()
    {

        Vector3 down = Vector3.down * strongArrows * settings.strongArrowWeight;
        Vector3 up = Vector3.up * quickArrows * settings.quickArrowWeight; 
        transform.Translate((up + down) * settings.slotSpeed * Time.deltaTime);
        MaxY = Mathf.Max(transform.position.y, MaxY);

        float y = transform.position.y;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(y, -Camera.main.orthographicSize, Camera.main.orthographicSize), transform.position.z);

        if (y > fastIndicatorY)
        {
            fastIndicator.transform.position = new Vector3 (fastIndicator.transform.position.x, y, fastIndicator.transform.position.z);
            fastIndicatorY = y;
        }
    }

    public void AddQuickArrow() 
    {
        quickArrows++;
        downIndicator.AddIndicator();
    }

    public void AddStrongArrow() 
    {
        strongArrows++;
        upIndicator.AddIndicator();
    }    

    public int GetSlotPoints 
    { 
        get
        {
            if (MaxY >= settings.weakArrowThirdPointY) return 3;
            if (MaxY >= settings.weakArrowSecondPointY) return 2;
            if (MaxY >= settings.weakArrowFirstPointY) return 1;
            return 0; 
        } 
    }
}
