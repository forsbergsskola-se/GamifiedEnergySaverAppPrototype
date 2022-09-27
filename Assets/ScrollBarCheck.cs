using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollBarCheck : MonoBehaviour
{
    private CameraDrag _cameraDrag;
    
    
    private void Awake() => _cameraDrag = FindObjectOfType<CameraDrag>();
    
    
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(0))
            _cameraDrag.canMove = false;
        else
            _cameraDrag.canMove = true;
    }
}
