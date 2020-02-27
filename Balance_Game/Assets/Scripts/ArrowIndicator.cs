using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] GameObject indicatorPrefab;
    [SerializeField] float offset = .5f;
    [SerializeField] float scale = 1.0f;

    float yEnd = 3.0f, yStart = .0f;

    List<Transform> indicators = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, .05f);
    }

    public void AddIndicator()
    {
        var indicator = Instantiate(indicatorPrefab, transform);
        indicator.transform.localPosition = Vector3.zero;
        indicator.transform.localScale = new Vector3(scale, scale, scale);
        indicators.Add(indicator.transform);
        UpdateIndicators();
    }

    void UpdateIndicators()
    {
        int indicatorCount = indicators.Count;
        for (int i = 0; i < indicatorCount; i++) 
        {
            indicators[i].transform.localPosition = Vector3.zero;
            indicators[i].transform.Translate(Vector3.down * yStart + Vector3.down * (i * (yEnd-yStart) / indicators.Count));
        }
    }
}
