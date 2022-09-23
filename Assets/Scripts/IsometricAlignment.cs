using UnityEngine;

public class IsometricAlignment : MonoBehaviour
{
    private Vector3 _pos;
    private void Awake()
    {
        _pos = transform.position;
        _pos.z = _pos.y / 100;
    }
}
