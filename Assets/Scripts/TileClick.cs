using UnityEngine;
using UnityEngine.EventSystems;

public class TileClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   private GridManager _gridManager;
   [SerializeField] public int Index;

   
   private void Awake() =>
      _gridManager = FindObjectOfType<GridManager>();


   public void OnPointerDown(PointerEventData eventData) =>
      _gridManager.SelectTile(gameObject,1, Index);


   public void OnPointerUp(PointerEventData eventData) =>
      _gridManager.DropTile();
}
