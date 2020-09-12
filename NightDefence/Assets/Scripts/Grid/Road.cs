using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private Grid grid;
    private CubePlacer cube;
    private Vector3 roadPos;

    void Start()
    {
        grid = FindObjectOfType<Grid>();
        cube = FindObjectOfType<CubePlacer>();

        roadPos = grid.GetNearestPointOnGrid(transform.position);

        cube.towerPositions.Add(roadPos);
    }
}
