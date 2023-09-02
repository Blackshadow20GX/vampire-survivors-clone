using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        // map direction check to vector value?
        if (!currentChunk)
        {
            return;
        }
        // up to here: https://youtu.be/QN8dm0RD3mY?si=vMP9z3cN50RLmdrm&t=1595
        // condition map
        int chunkSize = 16;
        Vector3 screenBoundary = new Vector3();

        if (pm.IsMovingRight() && !pm.IsMovingVertically()) // right
        {
            screenBoundary = currentChunk.transform.Find("Right").position + new Vector3(chunkSize, 0, 0);
        }
        else if (pm.IsMovingLeft() && !pm.IsMovingVertically()) // left
        {
            screenBoundary = currentChunk.transform.Find("Left").position + new Vector3(-chunkSize, 0, 0);
        }
        else if (pm.IsMovingUp() && !pm.IsMovingHorizontally()) // up
        {
            screenBoundary = currentChunk.transform.Find("Up").position + new Vector3(0, chunkSize, 0);
        }
        else if (pm.IsMovingDown() && !pm.IsMovingHorizontally()) // down
        {
            screenBoundary = currentChunk.transform.Find("Down").position + new Vector3(0, -chunkSize, 0);
        }
        else if (pm.IsMovingRight() && pm.IsMovingUp()) // right up
        {
            screenBoundary = currentChunk.transform.Find("Right Up").position + new Vector3(chunkSize, chunkSize, 0);
        }
        else if (pm.IsMovingRight() && pm.IsMovingDown()) // right down
        {
            screenBoundary = currentChunk.transform.Find("Right Down").position + new Vector3(chunkSize, -chunkSize, 0);
        }
        else if (pm.IsMovingLeft() && pm.IsMovingUp()) // left up
        {
            screenBoundary = currentChunk.transform.Find("Left Up").position + new Vector3(-chunkSize, chunkSize, 0);
        }
        else if (pm.IsMovingLeft() && pm.IsMovingDown()) // left down
        {
            screenBoundary = currentChunk.transform.Find("Left Down").position + new Vector3(-chunkSize, -chunkSize, 0);
        }

        if (!Physics2D.OverlapCircle(screenBoundary, checkerRadius, terrainMask))
        {
            noTerrainPosition = screenBoundary;
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
    }
}
