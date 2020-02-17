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
    [SerializeField] GameObject blockPrefab;

    [Header("Misc")]
    [SerializeField] GameSettings settings;

    Slot.Direction currentDirection = Slot.Direction.Up;
    Timer playTimer = null;

    void Start()
    {
        playTimer = new Timer(settings.initialPlayTimer);
    }

    void Update()
    {
        playTimer.tick();
        if (playTimer.isDone) 
        {
            {
                var currentSlot = slots[upSelection.CurrentSelection];
                Vector3 slotPos = currentSlot.transform.position;
                var block = Instantiate(blockPrefab, new Vector3(slotPos.x, settings.initialBlockHeight, slotPos.z), Quaternion.identity);
                block.GetComponent<Block>().Init(currentSlot, settings, Slot.Direction.Up);

            }

            {
                var currentSlot = slots[downSelection.CurrentSelection];
                Vector3 slotPos = currentSlot.transform.position;
                var block = Instantiate(blockPrefab, new Vector3(slotPos.x, -settings.initialBlockHeight, slotPos.z), Quaternion.Euler(.0f, .0f, 180.0f));
                block.GetComponent<Block>().Init(currentSlot, settings, Slot.Direction.Down);
            }

            playTimer.reset(settings.initialPlayTimer);
        }
    }
}
