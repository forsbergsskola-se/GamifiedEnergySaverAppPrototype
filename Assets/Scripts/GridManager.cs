using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    private Camera _cam;
    public Tilemap Tilemap;
    public Tile[] Tiles;
    public List<GameObject> UITiles;
    public GameObject SelectedTile;
    private int SelectedTileIndex;
    public Transform BuildingSelector;
    [SerializeField] public float UnselectedOpacity = 0.5f;
    private bool _tileBeingDragged = false;
    private Vector3 _mousePos;


    private void Awake() => _cam = FindObjectOfType<Camera>();

    private void Start()
    {
        var i = 0;
        foreach (var tile in Tiles)
        {
            // Object Initializer
            var uiTile = new GameObject($"UI Tile {i}")
            {
                transform =
                {
                    parent = BuildingSelector,
                    localScale = Vector3.one
                }
            };

            var tileClick = uiTile.AddComponent<TileClick>();
            tileClick.Index = i;
            
            
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


    private void Update()
    {
        if (_tileBeingDragged == false) return;
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void SelectTile(float Opacity, int Index)
    {
        SelectedTileIndex = Index;
        SelectedTile = UITiles[SelectedTileIndex];
        var tileSprite = SelectedTile.gameObject.GetComponent<Image>();
        var tileColour = tileSprite.color;
        tileColour.a = Opacity;
        
        _tileBeingDragged = true;
    }


    public void DropTile()
    {
        Tilemap.SetTile(Tilemap.WorldToCell(_mousePos), Tiles[SelectedTileIndex]);
        SelectedTile = null;
        _tileBeingDragged = false;
    }
}