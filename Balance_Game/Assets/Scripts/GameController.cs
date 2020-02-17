using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] Slot[] slots;
    [SerializeField] PlayerSelection upSelection;
    [SerializeField] PlayerSelection downSelection;

    [Header("Prefabs")]
    [SerializeField] GameObject upBlockPrefab;
    [SerializeField] GameObject downBlockPrefab;

    [Header("Misc")]
    [SerializeField] GameSettings settings;

    Slot.Direction currentDirection = Slot.Direction.Up;
    Timer upTimer = null;
    Timer downTimer = null;

    void Start()
    {
        upTimer = new Timer(settings.initialUpTimer);
        downTimer = new Timer(settings.initialDownTimer);
    }

    void Update()
    {
        upTimer.tick();
        if (upTimer.isDone) 
        {
            var currentSlot = slots[upSelection.CurrentSelection];
            Vector3 slotPos = currentSlot.transform.position;
            var block = Instantiate(upBlockPrefab, new Vector3(slotPos.x, settings.initialBlockHeight, slotPos.z), Quaternion.identity);
            block.GetComponent<Block>().Init(currentSlot, settings, Slot.Direction.Up);           
            upTimer.reset(settings.initialUpTimer);
        }

        downTimer.tick();

        if (downTimer.isDone) 
        {
            var currentSlot = slots[downSelection.CurrentSelection];
            Vector3 slotPos = currentSlot.transform.position;
            var block = Instantiate(downBlockPrefab, new Vector3(slotPos.x, -settings.initialBlockHeight, slotPos.z), Quaternion.Euler(.0f, .0f, 180.0f));
            block.GetComponent<Block>().Init(currentSlot, settings, Slot.Direction.Down);
            downTimer.reset(settings.initialDownTimer);
        }
    }
}
