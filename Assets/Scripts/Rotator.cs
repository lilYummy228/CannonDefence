using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Quaternion LookAt(Vector3 point, float offset = -90f)
    {
        float rotationZ = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg + offset;
        return Quaternion.Euler(0f, 0f, rotationZ);
    }
}
