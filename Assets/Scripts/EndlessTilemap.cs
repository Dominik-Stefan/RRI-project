using System.Collections.Generic;
using UnityEngine;

public class EndlessTilemap : MonoBehaviour
{
    public const float maxViewDistance = 39f;
    public Transform playerTransform;
    public static Vector2 playerPosition;
    public int chunkSize;
    public GameObject tilemapPrefab;
    private int chunksVisible;
    private Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    private List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    void Start()
    {
        chunksVisible = Mathf.RoundToInt(maxViewDistance / chunkSize);
        Debug.Log(chunksVisible);
    }

    void Update()
    {
        playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);
        Debug.Log(playerPosition);
        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {
        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunksVisibleLastUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(playerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(playerPosition.y / chunkSize);

        for (int yOffset = -chunksVisible; yOffset <= chunksVisible; yOffset++)
        {
            for (int xOffset = -chunksVisible; xOffset <= chunksVisible; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    terrainChunkDictionary[viewedChunkCoord].UpdateTerrainChunk();
                    if (terrainChunkDictionary[viewedChunkCoord].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewedChunkCoord]);
                    }
                }
                else
                {
                    terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, chunkSize, tilemapPrefab, transform));
                }
            }
        }
    }

    public class TerrainChunk
    {
        GameObject tilemap;
        Vector2 position;
        Bounds bounds;

        public TerrainChunk(Vector2 coord, int size, GameObject tilemapPrefab, Transform parent)
        {
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);

            tilemap = Instantiate(tilemapPrefab, new Vector2(position.x, position.y), Quaternion.identity);
            tilemap.transform.parent = parent;
            SetVisible(false);
        }

        public void UpdateTerrainChunk()
        {
            float playerDistFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(playerPosition));
            bool isVisible = playerDistFromNearestEdge <= maxViewDistance;
            SetVisible(isVisible);
        }

        public void SetVisible(bool visible)
        {
            tilemap.SetActive(visible);
        }

        public bool IsVisible()
        {
            return tilemap.activeSelf;
        }
    }
}
