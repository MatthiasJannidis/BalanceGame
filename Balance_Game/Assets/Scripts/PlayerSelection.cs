using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    int selection = 1;
    [SerializeField] GameObject[] selectionOutlines;
    [SerializeField] Slot[] slots;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    [SerializeField] Slot.Direction direction;
    public int CurrentSelection { get { return selection; } }

    // Start is called before the first frame update
    void Start()
    {
        OnSelect();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(leftKey)) 
        {
            selection--;
            selection = Mathf.Max(selection, 0);
            OnSelect();
        }
        if (Input.GetKeyUp(rightKey)) 
        {
            selection++;
            selection = Mathf.Min(selection, selectionOutlines.Length-1);
            OnSelect();
        }

        for(int i = 0; i < selectionOutlines.Length; i++) 
        {
            if(direction == Slot.Direction.Up) 
            {
                selectionOutlines[i].transform.localPosition = new Vector3(.0f, slots[i].NextBlockYUp+.1f, .0f);
            } else
            {
                selectionOutlines[i].transform.localPosition = new Vector3(.0f, slots[i].NextBlockYDown-.1f, .0f);
            }
        }
    }

    void OnSelect()
    {
        for (int i = 0; i < selectionOutlines.Length; i++)
        {
            selectionOutlines[i].SetActive(false);
        }
        selectionOutlines[selection].SetActive(true);
    }
}
