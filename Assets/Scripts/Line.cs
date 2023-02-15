using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private EdgeCollider2D edgeCollider;
    [SerializeField] private Rigidbody2D rb;

    [HideInInspector]public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;

    float pointsMinDistance = 0.1f;
    float circleColliderRadius; 


    public void Addpoint (Vector2 newPoint)
    {
        if(pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint())< pointsMinDistance)
        {
            return;
        }

        points.Add(newPoint);
        pointsCount++;

        //Add CircleCollider to the point
        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = circleColliderRadius;

        //Line Renderer
        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        //EdgeCollider
        if( pointsCount > 1)
        {
            edgeCollider.points = points.ToArray();
        }
    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }

    public void UsePhysics(bool usePhysics)
    {
        rb.isKinematic = !usePhysics;
    }

    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        circleColliderRadius = width / 2f;
        edgeCollider.edgeRadius = width / 2f;
    }
}
