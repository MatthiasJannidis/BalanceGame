using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] GameObject[] selectionOutlines = default;
    [SerializeField] Slot[] slots = default;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] Slot.Direction direction;

    public int CurrentSelection { get; private set; } = 1;

    void Start()
    {
        OnSelect();
    }

    void Update()
    {
        if (Input.GetKeyUp(leftKey)) 
        {
            CurrentSelection--;
            CurrentSelection = Mathf.Max(CurrentSelection, 0);
            OnSelect();
        }
        if (Input.GetKeyUp(rightKey)) 
        {
            CurrentSelection++;
            CurrentSelection = Mathf.Min(CurrentSelection, selectionOutlines.Length-1);
            OnSelect();
        }
    }

    void OnSelect()
    {
        for (int i = 0; i < selectionOutlines.Length; i++)
        {
            selectionOutlines[i].SetActive(false);
        }
        selectionOutlines[CurrentSelection].SetActive(true);
    }
}
