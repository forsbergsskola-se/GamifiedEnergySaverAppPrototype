using UnityEngine;
using UnityEngine.EventSystems;

public class TileClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   private GridManager _gridManager;
   private CameraDrag _cameraDrag;
   [SerializeField] public int Index;


   private void Awake()
   {
      _gridManager = FindObjectOfType<GridManager>();
      _cameraDrag = FindObjectOfType<CameraDrag>();
   }


   public void OnPointerDown(PointerEventData eventData)
   {
      _cameraDrag.canMove = false;
      _gridManager.SelectTile(gameObject,1, Index);
   }


   public void OnPointerUp(PointerEventData eventData)
   {
      _cameraDrag.canMove = true;
      _gridManager.DropTile();
   }
      
}
