using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    [SerializeField] Color lineColor;
    [SerializeField] GameObject linePrefab;

    [SerializeField] float startY;
    [SerializeField] float endY;
    [SerializeField] int lineNumber = 10;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < lineNumber; i++) 
        {
            var currentLine = Instantiate(linePrefab);
            var lineRenderer = currentLine.GetComponent<LineRenderer>();

            float y = startY + (i/(float)lineNumber)*(endY-startY);


            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, new Vector3(-7.0f, y, .0f));
            lineRenderer.SetPosition(1, new Vector3(7.0f, y, .0f));
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
        }


        
    }
}
