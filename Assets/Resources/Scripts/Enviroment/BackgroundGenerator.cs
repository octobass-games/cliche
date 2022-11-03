using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public List<Sprite> Sprites;
    public float Speed = 1;

    public int CanvasWidth = 480;
    private int tileWidth = 10;
    private int tilesPerPage = 0;

    private List<Tile> tiles = new List<Tile>();

    private int getEndPosition() => CanvasWidth;


    void Start()
    {
        tileWidth = Mathf.RoundToInt(Sprites[0].bounds.size.x);
        tilesPerPage = Mathf.RoundToInt(getEndPosition() / tileWidth) + 2 ; // extra tiles to handle edge of page
        for (int i = 0; i < tilesPerPage; i++)
        {
            Tile prevTile = i == 0 ? null : tiles[i - 1];
            Tile tile = AddTile(tileWidth * i, prevTile);
            tiles.Add(tile);
        }

        tiles[0].PrevTile = tiles[tiles.Count - 1];
        tiles.ForEach(t => t.Start());
    }

    Tile AddTile(int position, Tile prevTile)
    {
        GameObject tileGO = new GameObject("Tile");
        SpriteRenderer sprite = tileGO.AddComponent<SpriteRenderer>();
        sprite.sprite = Sprites.PickRandom();
        sprite.sortingLayerName = "Overlay";
        tileGO.transform.position = new Vector2(position, transform.position.y);
        tileGO.transform.SetParent(transform);
        Tile tile = tileGO.AddComponent<Tile>();
        tile.Initialise(() => ResetTile(tile), tileWidth, Speed, prevTile);
        return tile;
    }


    void ResetTile(Tile tile)
    {
        tile.GetComponent<SpriteRenderer>().sprite = Sprites.PickRandom();
        tile.transform.position = new Vector2(tile.PrevTileRightX(), transform.position.y);
    }

    void Update()
    {
        
    }
}
