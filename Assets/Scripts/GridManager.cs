using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public Tilemap Tilemap;
    public Tile[] Tiles;
    public List<GameObject> UTiles;
    public int SelectedTile = 0;
    public Transform TileGridUI;
    public float UnselectedOpacity = 0.5f;

    private void Awake()
    {
        var i = 0;
        foreach (Tile tile in Tiles)
        {
            var UTile = new GameObject("UI Tile");
            UTile.transform.parent = TileGridUI;
            UTile.transform.localScale = Vector3.one; 
            Image UIImage = UTile.AddComponent<Image>(); 
            UIImage.sprite = tile.sprite;

            Color TileColour = UIImage.color;
            TileColour.a = UnselectedOpacity;

            if (i == SelectedTile)
                TileColour.a = 1f;

            UIImage.color = TileColour;
            UTiles.Add(UTile);
        }
    }

}