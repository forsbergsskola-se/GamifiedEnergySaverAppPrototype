using UnityEngine;
public class TileClick : MonoBehaviour
{
   private SpriteRenderer _sr;
   private void Awake() => _sr = gameObject.GetComponent<SpriteRenderer>();


   private void OnMouseDown() => _sr.flipY = true;

   private void OnMouseUp() => _sr.flipY = false;
}
