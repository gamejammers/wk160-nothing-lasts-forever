using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager = null;
    [SerializeField] private Tilemap tilemap = null;
    [SerializeField] private GameObject tilePlacer = null;
    [SerializeField] private BuildingGrid centerGrid = null;
    [SerializeField] private SpriteRenderer placingTileSprite = null;
    [SerializeField] private MouseWorldTracker mouseWorldTracker = null;
    private GameObject placingTile = null;
    private Vector2 pos = Vector2.zero;
    private Vector2Int coordinate = Vector2Int.zero;

    public GameObject[] tiles = null;
    bool isCreating = false;

    public void StartCreatingTile(InputAction.CallbackContext _ctx)
    {
        placingTileSprite.enabled = true;
        placingTileSprite.sprite = tiles[0].GetComponent<SpriteRenderer>().sprite;
        isCreating = true;
        tilePlacer.SetActive(true);
        timeManager.DoSlowmotion();
    }

    public void StopCreatingTile(InputAction.CallbackContext _ctx)
    {
        placingTileSprite.enabled = false;
        placingTileSprite.sprite = null;
        tilePlacer.SetActive(false);
        isCreating = false;
        timeManager.BackToNormal();
    }

    public void SetTile(InputAction.CallbackContext _ctx)
    {
        if (centerGrid.alertSprite.enabled == false)
        {
            GameObject placingTile = Instantiate(tiles[0], tilemap.transform);
            placingTile.transform.position = pos;
        }
        else Debug.Log("There is a ground here!!");
    }

    void Update()
    {
        if(isCreating == false && (coordinate != Vector2Int.zero || pos != Vector2.zero))
        {
            coordinate = Vector2Int.zero;
            pos = Vector2.zero;
        }
        if(isCreating == true)
        {
            Vector3 mouseWorldPos = mouseWorldTracker.WorldSpaceMousePosition;
            coordinate = (Vector2Int)tilemap.WorldToCell(mouseWorldPos);
            pos = new Vector2( coordinate.x + 0.5f, coordinate.y + 0.5f );
            tilePlacer.transform.position = pos;
        }
    }
}
