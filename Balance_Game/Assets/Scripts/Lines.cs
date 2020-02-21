using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    [SerializeField] Color lineColor;
    [SerializeField] GameObject linePrefab;

    [SerializeField] float startY;
    [SerializeField] float endY;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++) 
        {
            var currentLine = Instantiate(linePrefab);
            var lineRenderer = currentLine.GetComponent<LineRenderer>();

            float y = startY + (i/10.0f)*(endY-startY);


            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, new Vector3(-10.0f, y, .0f));
            lineRenderer.SetPosition(1, new Vector3(10.0f, y, .0f));
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
        }


        
    }
}
