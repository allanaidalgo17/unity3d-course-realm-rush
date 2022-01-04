using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int key)
    {
        if (!grid.ContainsKey(key)) return null;
        return grid[key];
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int key = new Vector2Int(x, y);
                Node value = new Node(key, true);
                grid.Add(key, value);
            }
        }
    }
}
