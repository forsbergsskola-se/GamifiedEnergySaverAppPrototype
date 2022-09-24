using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public Tilemap Tilemap;
    public Tile[] Tiles;
    public List<GameObject> UITiles;
    public int SelectedTile = 0;
    public Transform BuildingSelector;
    public float UnselectedOpacity = 0.5f;

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

            var UIImage = uiTile.AddComponent<Image>(); 
            UIImage.sprite = tile.sprite;
            
            var tileColour = UIImage.color;
            tileColour.a = UnselectedOpacity;

            if (i == SelectedTile)
                tileColour.a = 1f;
            
            UIImage.color = tileColour;
            UITiles.Add(uiTile);
            i++;
        }
    }
}