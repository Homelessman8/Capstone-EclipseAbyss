using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class MazeSimplified : MonoBehaviour
{
    public GameObject Floor;
    public GameObject Wall;
    public GameObject Pillar;
    public GameObject GoalPrefab;
    public GameObject FinishPortalPrefab;
    public GameObject EnemyPrefab;
    public GameObject PlayerPrefab; // Add reference to the player prefab
    public NavMeshSurface surface;
    public int Rows = 5;
    public int Columns = 5;
    public float CellWidth = 5;
    public float CellHeight = 5;
    public bool AddGaps = true;
    public int MaxEnemies = 5;
    public float MinDistanceFromPlayer = 10f;

    private Transform playerTransform;

    void Start()
    {
        Random.InitState(12345); // Set a fixed random seed for deterministic results

        FindPlayer();

        GenerateMazeElements();

        //Update Nav mesh
        surface.BuildNavMesh();
    }

    void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player?.transform;

        // If the player is not found, spawn a new player
        if (playerTransform == null && PlayerPrefab != null)
        {
            SpawnPlayer();
        }
    }

    void GenerateMazeElements()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                float x = column * (CellWidth + (AddGaps ? 0.2f : 0));
                float z = row * (CellHeight + (AddGaps ? 0.2f : 0));
                MazeCell cell = GenerateMazeCell(row, column);

                Instantiate(Floor, new Vector3(x, 0, z), Quaternion.identity);

                if (cell.WallRight) InstantiateWall(x + CellWidth / 2, z, 90);
                if (cell.WallFront) InstantiateWall(x, z + CellHeight / 2, 0);
                if (cell.WallLeft) InstantiateWall(x - CellWidth / 2, z, 270);
                if (cell.WallBack) InstantiateWall(x, z - CellHeight / 2, 180);

                if (cell.IsGoal) Instantiate(GoalPrefab, new Vector3(x, 1, z), Quaternion.identity);

                SpawnEnemies(x, z);
            }
        }

        InstantiateFinishPortal();

        // Ensure the player exists
        if (PlayerPrefab != null && playerTransform == null)
        {
            SpawnPlayer();
        }
    }

    void InstantiateWall(float x, float z, float rotationY)
    {
        Instantiate(Wall, new Vector3(x, 0, z), Quaternion.Euler(0, rotationY, 0));
    }

    void SpawnEnemies(float x, float z)
    {
        if (EnemyPrefab != null && playerTransform != null && MaxEnemies > 0)
        {
            if (Vector3.Distance(playerTransform.position, new Vector3(x, 0, z)) > MinDistanceFromPlayer)
            {
                Instantiate(EnemyPrefab, new Vector3(x, 1, z), Quaternion.identity);
                MaxEnemies--;
            }
        }
    }

    void InstantiateFinishPortal()
    {
        if (FinishPortalPrefab != null && playerTransform != null)
        {
            Vector3 portalPosition;
            do
            {
                int randomRow = Random.Range(0, Rows);
                int randomColumn = Random.Range(0, Columns);

                float x = randomColumn * (CellWidth + (AddGaps ? 0.2f : 0));
                float z = randomRow * (CellHeight + (AddGaps ? 0.2f : 0));

                portalPosition = new Vector3(x, 1, z);
            } while (Vector3.Distance(playerTransform.position, portalPosition) < MinDistanceFromPlayer);

            Instantiate(FinishPortalPrefab, portalPosition, Quaternion.identity);
        }
    }

    void SpawnPlayer()
    {
        int randomRow = Random.Range(0, Rows);
        int randomColumn = Random.Range(0, Columns);

        float x = randomColumn * (CellWidth + (AddGaps ? 0.2f : 0));
        float z = randomRow * (CellHeight + (AddGaps ? 0.2f : 0));

        Instantiate(PlayerPrefab, new Vector3(x, 1, z), Quaternion.identity);
    }

    MazeCell GenerateMazeCell(int row, int column)
    {
        // Implement your maze generation logic here and return the MazeCell object
        // For simplicity, a dummy MazeCell is returned in this example.
        return new MazeCell();
    }
}

//public class MazeCell
//{
//    public bool WallRight1;
//    public bool WallFront1;
//    public bool WallLeft1;
//    public bool WallBack1;
//    public bool IsGoal1;

//    // You can add more properties or methods as needed
//}