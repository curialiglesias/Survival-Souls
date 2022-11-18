using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Transform> lines = new List<Transform>();

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();  
    }

    // Update is called once per frame
    public void setupLine(List<Transform> points)
    {
        lineRenderer.positionCount = points.Count;
        this.lines = points;
    }

    private void Update()
    {
        for(int i = 0; i < lines.Count; i++)
        {
            lineRenderer.SetPosition(i, lines[i].position);
        }
    }
}
