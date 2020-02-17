using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Slot slot;
    public GameSettings settings;
    bool moving = false;
    Slot.Direction direction;

    public void Init(Slot givenSlot, GameSettings givenSettings, Slot.Direction givenDirection) 
    {
        slot = givenSlot;
        settings = givenSettings;
        moving = true;
        direction = givenDirection;
    } 

    void Update()
    {
        if (moving) 
        {
            if(direction == Slot.Direction.Up)
            {
                transform.Translate(Vector3.down * settings.blockSpeed * Time.deltaTime);
                if (slot.InRangeUp(transform.position.y)) 
                {
                    transform.SetParent(slot.transform); 
                    transform.localPosition = new Vector3(.0f, slot.NextBlockYUp, .0f);
                    moving = false;
                    slot.AddUpBlock();
                }
            }
            else
            {
                transform.Translate(Vector3.down * settings.blockSpeed * Time.deltaTime);
                if (slot.InRangeDown(transform.position.y))
                {
                    moving = false;
                    transform.SetParent(slot.transform);
                    transform.localPosition = new Vector3(.0f, slot.NextBlockYDown, .0f);
                    slot.AddDownBlock();
                }
            }        
        }
    }
}
