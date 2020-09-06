using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField]
    private float sizeDefault = 1f;

    public float size { get { return sizeDefault; } }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / sizeDefault);
        int yCount = Mathf.RoundToInt(position.y / sizeDefault);
        int zCount = Mathf.RoundToInt(position.z / sizeDefault);

        Vector3 result = new Vector3(
            (float)xCount * sizeDefault,
            (float)yCount * sizeDefault,
            (float)zCount * sizeDefault);
        result += transform.position;

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 100; x += sizeDefault)
        {
            for (float z = 0; z < 210; z += sizeDefault)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0, z));
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
