using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public TimeManager timeManager = null;
    public Tilemap tilemap = null;
    public GameObject tilePlacer = null;
    public BuildingGrid centerGrid = null;
    GameObject placingTile = null;
    // Added by Danny
    [SerializeField]
    private MouseWorldTracker mouseWorldTracker = null;

    public GameObject[] tiles = null;
    bool isCreating = false;
    public void StartCreatingTile()
    {
        isCreating = true;
        tilePlacer.SetActive(true);
        placingTile = Instantiate( tiles[0], tilePlacer.transform.position, Quaternion.identity );
        placingTile.GetComponent<BoxCollider2D>().enabled = false;

        timeManager.DoSlowmotion();
    }

    public void SetTile( )
    {
        placingTile.transform.SetParent(tilemap.transform);

        tilePlacer.SetActive(false);
        
        placingTile.GetComponent<BoxCollider2D>().enabled = true;

        isCreating = false;

        timeManager.BackToNormal();
    }



    /// 
    /// -------------------MONOBEHAVIOUR STUFF-------------------------
    /// 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCreatingTile();
        }
        if(isCreating)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int coordinate = (Vector2Int)tilemap.WorldToCell(mouseWorldPos);
            Vector2 pos = new Vector2( coordinate.x + 0.5f, coordinate.y + 0.5f );
            placingTile.transform.position = pos;
            tilePlacer.transform.position = pos;

            if(Input.GetMouseButtonDown(1))
            {
                if(centerGrid.alertSprite.enabled == false) // there is no ground
                    SetTile();
                else
                    Debug.Log("There is a ground here!!");
            }
        }
    }
}
