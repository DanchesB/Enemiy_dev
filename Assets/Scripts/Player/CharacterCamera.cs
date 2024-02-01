using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // желаемая позиция камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  // промежуточная координата межну текущей и желаемой
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
