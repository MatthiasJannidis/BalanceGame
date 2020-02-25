using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] Slot[] slots;
    [SerializeField] PlayerSelection quickSelection;
    [SerializeField] PlayerSelection strongSelection;

    [Header("Misc")]
    [SerializeField] GameSettings settings;


    [Header("UI")]
    [SerializeField] Image strongTimerImage;
    [SerializeField] Image fastTimerImage;

    Timer quickTimer = null;
    Timer strongTimer = null;
    int[] lastSlotPoints;
    int quickPoints = 0;

    void Start()
    {
        lastSlotPoints = new int[slots.Length];
        for(int i = 0; i < lastSlotPoints.Length; i++) 
        {
            lastSlotPoints[i] = 0;
        }
        quickTimer = new Timer(settings.quickArrowPlaceTimer);
        strongTimer = new Timer(settings.strongArrowPlaceTimer);
    }

    void Update()
    {
        quickTimer.tick();
        fastTimerImage.fillAmount = (quickTimer.PassedTime / quickTimer.GetTimer);
        if (quickTimer.isDone) 
        {
            var currentSlot = slots[quickSelection.CurrentSelection];
            currentSlot.AddQuickArrow();
            quickTimer.reset(settings.quickArrowPlaceTimer);
        }
        
        strongTimer.tick();
        strongTimerImage.fillAmount = (strongTimer.PassedTime/strongTimer.GetTimer);
        if (strongTimer.isDone) 
        {
            var currentSlot = slots[strongSelection.CurrentSelection];
            currentSlot.AddStrongArrow();
            strongTimer.reset(settings.strongArrowPlaceTimer);
        }

        for(int i = 0; i < slots.Length; i++) 
        {
            //todo : communicate this to a game controller-like object
            if (slots[i].transform.position.y > settings.strongArrowGoalY)
            {
                Debug.Log("STRONG PLAYER WON");
            }

            int slotPoints = slots[i].GetSlotPoints;

            if (slotPoints > lastSlotPoints[i]) 
            {
                quickPoints += slotPoints - lastSlotPoints[i];
                if(quickPoints >= settings.weakArrowPointGoal)
                {
                    Debug.Log("QUICK PLAYER WON");
                }
            }
            lastSlotPoints[i] = slotPoints;
        }
    }
}
