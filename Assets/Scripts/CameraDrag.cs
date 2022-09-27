using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _difference;
    private Vector3 _reset;
    private bool _drag = false;
    public bool canMove = true;
    
    public Camera _camera;
    public float ClampMinX;
    public float ClampMinY;
    public float ClampMaxX;
    public float ClampMaxY;



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

        if (!_drag) return;
        
        _camera.transform.position = _origin - _difference;
        CalculateCamBounds();
    }

    private void CalculateCamBounds()
    {
        _camera.transform.position = new Vector3
        (Mathf.Clamp(_camera.transform.position.x, ClampMinX, ClampMaxX),
            Mathf.Clamp(_camera.transform.position.y, ClampMinY, ClampMaxY), 
            _camera.transform.position.z);
    }
}
