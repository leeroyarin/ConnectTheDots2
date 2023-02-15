using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject linePrefab;
    GameManager gameManager;
    public LayerMask cantDrawMask;
    int cantDrawOverLayerIndex;

    [Space(30f)]
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;
    public Vector2 offset;
    Line currentLine;

    Camera cam;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        //        cam = Camera.main;
        cam = FindObjectOfType<Camera>();
        cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawMask");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeginDraw();
            
        }

        if(currentLine != null)
        {
            Draw();
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }
    }

    //Begin Draw
    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        currentLine.UsePhysics(false);
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
        currentLine.SetLineWidth(lineWidth);
    }

    void Draw()
    {
        
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.touchCount == 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchedPosition = touch.position;
                mousePosition = Camera.main.ScreenToWorldPoint(touchedPosition);

            }
        }
        RaycastHit2D hit = Physics2D.CircleCast(mousePosition+ offset, lineWidth / 3f, Vector2.zero, 1f, cantDrawMask);
        
        if (hit)
        {
            EndDraw();
        }
        else
        {
            currentLine.Addpoint(mousePosition + offset);
        }

        
    }

    void EndDraw()
    {
        if(currentLine != null)
        {
            if(currentLine.pointsCount < 2)
            {
                //if line has one point
                Destroy(currentLine.gameObject);
            }
            else
            {
                currentLine.gameObject.layer = cantDrawOverLayerIndex;
                currentLine.UsePhysics(true);
                currentLine = null;
                
                gameManager.ActivePhysicsInBalls();
                
            }
           
        }
        
    }
}
