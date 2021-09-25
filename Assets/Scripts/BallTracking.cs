using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        Vector3 newPos = Vector3.Lerp(this.transform.position, target.transform.position, 0.5f);
        newPos.z = this.transform.position.z;
        this.transform.position = newPos;
    }
}
