using UnityEngine;
using UnityEngine.EventSystems;

public class TileClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   //private SpriteRenderer _sr;
   private GridManager _gridManager;
   [SerializeField] public int Index;

   private void Awake()
   {
      //_sr = gameObject.GetComponent<SpriteRenderer>();
      _gridManager = FindObjectOfType<GridManager>();
   }

   //private void OnMouseDown() => _sr.flipY = true;

   //private void OnMouseUp() => _sr.flipY = false;

   public void OnPointerDown(PointerEventData eventData)
   {
      _gridManager.SelectTile(1, Index);
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      _gridManager.DropTile();
   }
}
