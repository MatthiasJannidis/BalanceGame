using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    int quickArrows = 0;
    int strongArrows = 0;

    public float MinY { get; private set; } = .0f;

    public enum Direction : int
    {
        Up = 1,
        Down = -1
    }
    void Update()
    {
        Vector3 up = Vector3.up * strongArrows * settings.strongArrowWeight;
        Vector3 down = Vector3.down * quickArrows * settings.quickArrowWeight; 
        transform.Translate((up + down) * settings.slotSpeed * Time.deltaTime);
        MinY = Mathf.Min(transform.position.y, MinY);
    }

    public void AddQuickArrow() 
    {
        quickArrows++;
    }

    public void AddStrongArrow() 
    {
        strongArrows++;
    }    

    public int GetSlotPoints 
    { 
        get
        {
            if (MinY <= settings.weakArrowThirdPointY) return 3;
            if (MinY <= settings.weakArrowSecondPointY) return 2;
            if (MinY <= settings.weakArrowFirstPointY) return 1;
            return 0; 
        } 
    }
}
