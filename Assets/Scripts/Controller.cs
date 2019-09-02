using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] tiles;
    GameObject[,] grid;

    Model model;
    View view;

    [SerializeField]
    int sizeX;
    [SerializeField]
    int sizeY;
    [SerializeField]
    Vector2 offset;

    void Start()
    {
        GridInit();
    }

    void Update()
    {
        
    }

    void GridInit()
    {
        grid = new GameObject[sizeX, sizeY];

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                GameObject go =
                    Instantiate(tiles[Random.Range(0, tiles.Length)], new Vector2(i + offset.x, j + offset.y),
                    Quaternion.identity);
                go.transform.SetParent(gameObject.transform);
                go.name = go.name.Replace(" (clone)", " ").Trim();
                grid[i, j] = go;
            }
        }
    }
}
