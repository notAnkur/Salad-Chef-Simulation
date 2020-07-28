using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;

    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {

        if (targets.Count == 0)
            return;

        Vector3 centerPoint = GetCenterPoint();
        Vector3 offsetPosition = centerPoint + offset;
        transform.position = offsetPosition;

    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
            return targets[0].position;
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0; i<targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }

}
