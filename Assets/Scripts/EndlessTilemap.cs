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
    private List<TerrainChunk> terrainChunksVisibleThisUpdate = new List<TerrainChunk>();

    void Start()
    {
        chunksVisible = Mathf.RoundToInt(maxViewDistance / chunkSize);
    }

    void Update()
    {
        playerPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);
        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {
        terrainChunksVisibleLastUpdate = new List<TerrainChunk>(terrainChunksVisibleThisUpdate);
        terrainChunksVisibleThisUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(playerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(playerPosition.y / chunkSize);

        for (int yOffset = -chunksVisible; yOffset <= chunksVisible; yOffset++)
        {
            for (int xOffset = -chunksVisible; xOffset <= chunksVisible; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);
                TerrainChunk currentTerrainChunk;

                if (terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    currentTerrainChunk = terrainChunkDictionary[viewedChunkCoord];
                    currentTerrainChunk.UpdateTerrainChunk();
                    if (currentTerrainChunk.IsVisible())
                    {
                        terrainChunksVisibleThisUpdate.Add(currentTerrainChunk);
                    }
                }
                else
                {
                    currentTerrainChunk = new TerrainChunk(viewedChunkCoord, chunkSize, tilemapPrefab, transform);
                    terrainChunkDictionary.Add(viewedChunkCoord, currentTerrainChunk);
                }
            }
        }

        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            bool visible = false;
            for (int j = 0; j < terrainChunksVisibleThisUpdate.Count; j++)
            {
                if (terrainChunksVisibleLastUpdate[i].Equals(terrainChunksVisibleThisUpdate[j]))
                {
                    visible = true;
                    break;
                }
            }

            terrainChunksVisibleLastUpdate[i].SetVisible(visible);
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
