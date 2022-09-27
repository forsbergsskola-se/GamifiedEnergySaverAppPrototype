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

    public bool ToggleSelectUI = true;
    public GameObject BuildingSelector;
    private Image _uiGrid;

    [SerializeField] public float UnselectedOpacity = 0.5f;
    private bool _tileBeingDragged = false;
    private Vector3 _mousePos;
    public GameObject DragTile;
    private Vector3 DragTileDefaultPos;
    private SoundManager _soundManager;
    

    private void Awake()
    {
        _cam = FindObjectOfType<Camera>();
        _uiGrid = BuildingSelector.GetComponent<Image>();
        DragTileDefaultPos = DragTile.transform.position;
        _soundManager = FindObjectOfType<SoundManager>();
    }

    
    
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
                    parent = BuildingSelector.transform,
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
        DragTile.transform.position = new Vector3(_mousePos.x, _mousePos.y, DragTile.transform.position.z);
    }

    
    
    public void SelectTile(GameObject TileSprite, float Opacity, int Index)
    {
        _soundManager.PlaySnapSFX();
        SelectedTileIndex = Index;
        SelectedTile = UITiles[SelectedTileIndex];
        
        var tileSprite = SelectedTile.gameObject.GetComponent<Image>();
        var tileColour = tileSprite.color;
        tileColour.a = Opacity;

        ToggleUI(false);
        AddDragSprite(TileSprite);
        _tileBeingDragged = true;
    }


    
    public void DropTile()
    {
        _soundManager.PlayPlaceBuildingSFX();
        TileBase tileBase = Tiles[SelectedTileIndex];
        var chosenCell = new Vector3(_mousePos.x, _mousePos.y, 0);
        
        // can't place tile where there's no grass already
        if (Tilemap.GetTile(Tilemap.WorldToCell(chosenCell)) != null)
            Tilemap.SetTile(Tilemap.WorldToCell(chosenCell), tileBase);
        
        if (Tilemap.GetTile(Tilemap.WorldToCell(chosenCell)).GetTileData() )

        DragTile.transform.position = DragTileDefaultPos;
        SelectedTile = null;
        ToggleUI(true);
        _tileBeingDragged = false;
    }



    private void AddDragSprite(GameObject TileSprite)
    {
        var tileTransform = TileSprite.transform;

        DragTile.transform.position = tileTransform.position;
        DragTile.transform.rotation = tileTransform.rotation;
        DragTile.GetComponent<Image>().sprite = TileSprite.GetComponent<Image>().sprite;
        DragTile.transform.localScale = tileTransform.localScale * 2;
    }


    
    private void ToggleUI(bool toggle)
    {
        if (ToggleSelectUI == false) return;
        _uiGrid.enabled = toggle;
        foreach (var tile in UITiles)
            tile.GetComponent<Image>().enabled = toggle;
    }
    
    
    
    private void UpdateAlpha(Image image, int alpha)
    {
        var colour = image.color;
        colour.a = alpha;
    }
}