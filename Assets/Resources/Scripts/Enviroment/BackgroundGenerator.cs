using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public List<Sprite> Sprites;
    public float Speed = 1;

    private int tileWidth = 10;
    private int tilesPerPage = 0;
    public string Layer = "Overlay";
    public List<Color> Colours;
    public bool RandomOpacity = false;
    public int sortingOrder = 0;
    public bool Sporadic = false;
    public float MinScale = 1;
    public float MaxScale = 1;
    public int MaxYRange = 0;

    private List<Tile> tiles = new List<Tile>();

    private int getEndPosition() => Mathf.RoundToInt(ScreenSize().x) + calcTileWidth();

    private int calcTileWidth() => Mathf.RoundToInt(Sprites[0].bounds.size.x);

    private Vector2 ScreenSize()
    {
        float height = UnityEngine.Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return new Vector2(width, height);
    }

    void Start()
    {
        if (!Sporadic)
        {
            RenderContinuosly();
        }else
        {
            RenderSporadicly();
        }
    }

    private void RenderContinuosly()
    {
        tileWidth = calcTileWidth();
        tilesPerPage = Mathf.RoundToInt(getEndPosition() / tileWidth) + 2; // extra tiles to handle edge of page
        for (int i = 0; i < tilesPerPage; i++)
        {
            Tile prevTile = i == 0 ? null : tiles[i - 1];
            Tile tile = AddTile(tileWidth * i, prevTile, true);
            tiles.Add(tile);
        }

        tiles[0].PrevTile = tiles[tiles.Count - 1];
        tiles.ForEach(t => t.Start());
    }
    private void RenderSporadicly()
    {
        tileWidth = calcTileWidth() + Random.Range(100, 300);
        tilesPerPage = Mathf.RoundToInt(getEndPosition() / tileWidth) + 2; // extra tiles to handle edge of page
        for (int i = 0; i < tilesPerPage; i++)
        {
            Tile prevTile = i == 0 ? null : tiles[i - 1];
            Tile tile = AddTile(tileWidth * i, prevTile, false);
            tiles.Add(tile);
        }

        tiles[0].PrevTile = tiles[tiles.Count - 1];
        tiles.ForEach(t => t.Start());
    }

    Tile AddTile(int position, Tile prevTile, bool considerPrevTile)
    {
        GameObject tileGO = new GameObject("Tile");
        SpriteRenderer sprite = tileGO.AddComponent<SpriteRenderer>();
        sprite.sprite = Sprites.PickRandom();
        sprite.color = Colours.PickRandom();

        SetOpacity(sprite);
        sprite.sortingLayerName = Layer;
        sprite.sortingOrder = sortingOrder;
        tileGO.transform.position = new Vector2(position, YPos());
        tileGO.transform.SetParent(transform);
        float scale = Random.Range(MinScale, MaxScale);
        tileGO.transform.localScale = new Vector2(scale, scale);
        Tile tile = tileGO.AddComponent<Tile>();
        tile.Initialise(() => ResetTile(tile, considerPrevTile), tileWidth, Speed, prevTile);
        return tile;
    }

    float YPos()
    {
        var y = transform.position.y;
        return Random.Range(y - MaxYRange, y + MaxYRange);
    }


    void ResetTile(Tile tile, bool considerPrevTile)
    {
        var renderer = tile.GetComponent<SpriteRenderer>();
        renderer.sprite = Sprites.PickRandom();
        SetOpacity(renderer);
        float scale = Random.Range(MinScale, MaxScale);
        renderer.transform.localScale = new Vector2(scale, scale);
        var x = considerPrevTile ? tile.PrevTileRightX() : getEndPosition();
        tile.transform.position = new Vector2(x, YPos());
    }
    public void Pause()
    {
        tiles.ForEach(tile => tile.Pause());
    }

    private void SetOpacity(SpriteRenderer sprite)
    {
        if (RandomOpacity)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Random.Range(0.2f, 1f));
        }
    }

    void Update()
    {
        
    }
}
