using UnityEngine;
using UnityEngine.EventSystems;

public class TileClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   private SpriteRenderer _sr;
   private GridManager _gridManager;
   private float _dimmedOpacity;

   private void Awake()
   {
      _sr = gameObject.GetComponent<SpriteRenderer>();
      _gridManager = FindObjectOfType<GridManager>();
      _dimmedOpacity = _gridManager.UnselectedOpacity;
   }

   private void OnMouseDown() => _sr.flipY = true;

   private void OnMouseUp() => _sr.flipY = false;

   public void OnPointerDown(PointerEventData eventData)
   {
      _gridManager.UpdateSelectedTile(gameObject, 1);
   }

   public void OnPointerUp(PointerEventData eventData)
   {
      _gridManager.UpdateSelectedTile(gameObject, _dimmedOpacity);
   }
}
