using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject[,] grid;

    Camera mcamera;
    RaycastHit raycast;

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
        mcamera = Camera.main;
        GridInit();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                               Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                               Vector2.zero);
            if (hit)
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
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
                go.name = "(" + i + "," + j + ")";
                grid[i, j] = go;
            }
        }
    }
}
