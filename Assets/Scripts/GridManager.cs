using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public Tilemap Tilemap;
    public Tile[] Tiles;
    public List<GameObject> UITiles;
    public GameObject SelectedTile;
    public Transform BuildingSelector;
    [SerializeField] public float UnselectedOpacity = 0.5f;

    private void Awake()
    {
        var i = 0;
        foreach (var tile in Tiles)
        {
            // Object Initializer
            var uiTile = new GameObject("UI Tile")
            {
                transform =
                {
                    parent = BuildingSelector,
                    localScale = Vector3.one
                }
            };

            uiTile.AddComponent<TileClick>();
            
            var UIImage = uiTile.AddComponent<Image>(); 
            UIImage.sprite = tile.sprite;
            
            var tileColour = UIImage.color;
            tileColour.a = UnselectedOpacity;
            
            var Button = uiTile.AddComponent<Button>();
            Button.targetGraphic = UIImage;

            UIImage.color = tileColour;
            UITiles.Add(uiTile);
            i++;
        }
    }

    public void UpdateSelectedTile(GameObject Tile, float Opacity)
    {
        SelectedTile = Tile;
        var tileSprite = SelectedTile.GetComponent<Image>();
        var tileColour = tileSprite.color;
        tileColour.a = Opacity;
    }
}