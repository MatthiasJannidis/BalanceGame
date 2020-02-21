using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    [SerializeField] int lineNumber;
    [SerializeField] Color lineColor;

    // Start is called before the first frame update
    void Start()
    {
        var lineRenderer = gameObject.GetComponent<LineRenderer>();

        float y = .0f;
        switch (lineNumber) 
        {
            case 1:
                y = settings.weakArrowFirstPointY;
                break;
            case 2:
                y = settings.weakArrowSecondPointY;
                break;
            case 3:
                y = settings.weakArrowThirdPointY;
                break;
            default:
                y = settings.strongArrowGoalY;
                break;
        }

        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, new Vector3(-10.0f, y, .0f));
        lineRenderer.SetPosition(1, new Vector3(10.0f, y, .0f));
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
    }
}
