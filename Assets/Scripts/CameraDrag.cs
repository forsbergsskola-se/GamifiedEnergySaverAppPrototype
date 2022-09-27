using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _reset;
    private bool _drag = false;
    public bool canMove = true;
    public Camera _camera;

    private void Awake() => _reset = _camera.transform.position;

    // Update is called once per frame
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && canMove)
        {
            _difference = _camera.ScreenToWorldPoint(Input.mousePosition) - _camera.transform.position;
            if (_drag == false)
            {
                _drag = true;
                _origin = _camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
            _drag = false;

        if (_drag)
            _camera.transform.position = _origin - _difference;
    }
}
