using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEAM : MonoBehaviour
{
    public GameObject target;
    public LineRenderer line;

    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, target.transform.position);
    }
}
