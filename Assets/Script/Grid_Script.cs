using UnityEngine;

public class Grid_Script : MonoBehaviour
{
    public int width = 10;
    public int height = 10;

    private float cellSize = 1f;

    private Color lineColor = Color.white;

    public Color LineColor
    {
        get; set;
    }

    
    void Start()
    {
        DrawGrid();
    }

     void DrawGrid()
    {
        for (int x = 0; x <= width; x++)
        {
            CreateLine(new Vector3(x * cellSize, 0, 0), new Vector3(x * cellSize, height * cellSize, 0));
        }

        for (int y = 0; y <= height; y++)
        {
            CreateLine(new Vector3(0, y * cellSize, 0), new Vector3(width * cellSize, y * cellSize, 0));
        }
    }

    void CreateLine(Vector3 start, Vector3 end)
    {
        GameObject lineObj = new GameObject("GridLine");
        lineObj.transform.parent = transform;

        var lr = lineObj.AddComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        lr.startWidth = 0.05f;
        lr.endWidth = 0.05f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        
        lr.useWorldSpace = true;
    }

}
