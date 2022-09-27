using UnityEngine;

public class PinchyZoomy : MonoBehaviour
{
    public Camera Cam;
    private float _pinchPrevPosDiff, _pinchCurrentPosDiff;
    private Vector2 _firstTouchPrevPos, _secondTouchPrevPos;
    private float ZoomModifier;
    
    [SerializeField]public float MinOrthographicSize, MaxOrthographicSize;
    [SerializeField] public float zoomModifierSpeed = 0.1f;
    
    // Update is called once per frame
    private void Update() 
    {
        if (Input.touchCount == 2) 
        {
            var firstTouch = Input.GetTouch (0);
            var secondTouch = Input.GetTouch (1);

            _firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            _secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

            _pinchPrevPosDiff = (_firstTouchPrevPos - _secondTouchPrevPos).magnitude;
            _pinchCurrentPosDiff = (firstTouch.position - secondTouch.position).magnitude;

            ZoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

            if (_pinchPrevPosDiff > _pinchCurrentPosDiff)
                Cam.orthographicSize += ZoomModifier;
            
            if (_pinchPrevPosDiff < _pinchCurrentPosDiff)
                Cam.orthographicSize -= ZoomModifier;
        }
        
        Cam.orthographicSize = Mathf.Clamp (Cam.orthographicSize, MinOrthographicSize, MaxOrthographicSize);
    }
}
