using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] GameObject indicatorPrefab;
    [SerializeField] float offset = .5f;
    [SerializeField] float scale = 1.0f;
    int indicatorNumber = 0;
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, .05f);
    }

    public void AddIndicator()
    {
        var indicator = Instantiate(indicatorPrefab, transform);
        indicator.transform.localPosition = Vector3.zero;
        indicator.transform.localScale = new Vector3(scale, scale, scale);
        indicator.transform.Translate(Vector3.down * offset * indicatorNumber);
        indicatorNumber++;
    }
}
