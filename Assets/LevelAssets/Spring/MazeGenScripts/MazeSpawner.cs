using UnityEngine;
using System.Collections;

//<summary>
//Game object, that creates maze and instantiates it in scene
//</summary>
public class MazeSpawner : MonoBehaviour
{
    public enum MazeGenerationAlgorithm
    {
        PureRecursive,
        RecursiveTree,
        RandomTree,
        OldestTree,
        RecursiveDivision,
    }

    public MazeGenerationAlgorithm Algorithm = MazeGenerationAlgorithm.PureRecursive;
    public bool FullRandom = false;
    public int RandomSeed = 12345;
    public GameObject Floor = null;
    public GameObject Wall = null;
    public GameObject Pillar = null;
    public int Rows = 5;
    public int Columns = 5;
    public float CellWidth = 5;
    public float CellHeight = 5;
    public bool AddGaps = true;
    public GameObject GoalPrefab = null;
    public GameObject FinishPortalPrefab; // Reference to the finish portal prefab
    public float MinDistanceFromPlayer = 10f; // Minimum distance from the player

    private BasicMazeGenerator mMazeGenerator = null;
    private Transform playerTransform; // Reference to the player's transform

    [System.Obsolete]
    void Start()
    {
        // Set random seed for deterministic randomization (optional)
        if (!FullRandom)
        {
            Random.seed = RandomSeed;
        }

        // Initialize maze generator based on selected algorithm
        switch (Algorithm)
        {
            case MazeGenerationAlgorithm.PureRecursive:
                mMazeGenerator = new RecursiveMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RecursiveTree:
                mMazeGenerator = new RecursiveTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RandomTree:
                mMazeGenerator = new RandomTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.OldestTree:
                mMazeGenerator = new OldestTreeMazeGenerator(Rows, Columns);
                break;
            case MazeGenerationAlgorithm.RecursiveDivision:
                mMazeGenerator = new DivisionMazeGenerator(Rows, Columns);
                break;
        }

        // Generate the maze
        mMazeGenerator.GenerateMaze();

        // Find the player in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        // Instantiate maze elements
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                float x = column * (CellWidth + (AddGaps ? 0.2f : 0));
                float z = row * (CellHeight + (AddGaps ? 0.2f : 0));
                MazeCell cell = mMazeGenerator.GetMazeCell(row, column);
                GameObject tmp;

                // Instantiate floor
                tmp = Instantiate(Floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                tmp.transform.parent = transform;

                // Instantiate walls based on maze cell configuration
                if (cell.WallRight)
                {
                    tmp = Instantiate(Wall, new Vector3(x + CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 90, 0)) as GameObject; // right
                    tmp.transform.parent = transform;
                }
                if (cell.WallFront)
                {
                    tmp = Instantiate(Wall, new Vector3(x, 0, z + CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject; // front
                    tmp.transform.parent = transform;
                }
                if (cell.WallLeft)
                {
                    tmp = Instantiate(Wall, new Vector3(x - CellWidth / 2, 0, z) + Wall.transform.position, Quaternion.Euler(0, 270, 0)) as GameObject; // left
                    tmp.transform.parent = transform;
                }
                if (cell.WallBack)
                {
                    tmp = Instantiate(Wall, new Vector3(x, 0, z - CellHeight / 2) + Wall.transform.position, Quaternion.Euler(0, 180, 0)) as GameObject; // back
                    tmp.transform.parent = transform;
                }

                // Instantiate goal if the current cell is a goal
                if (cell.IsGoal && GoalPrefab != null)
                {
                    tmp = Instantiate(GoalPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 0)) as GameObject;
                    tmp.transform.parent = transform;
                }
            }
        }

        // Instantiate pillars
        if (Pillar != null)
        {
            for (int row = 0; row < Rows + 1; row++)
            {
                for (int column = 0; column < Columns + 1; column++)
                {
                    float x = column * (CellWidth + (AddGaps ? 0.2f : 0));
                    float z = row * (CellHeight + (AddGaps ? 0.2f : 0));
                    GameObject tmp = Instantiate(Pillar, new Vector3(x - CellWidth / 2, 0, z - CellHeight / 2), Quaternion.identity) as GameObject;
                    tmp.transform.parent = transform;
                }
            }
        }

        // Instantiate the finish portal at a random position far from the player
        InstantiateFinishPortal();
    }

    // Instantiate finish portal at a random position within the maze, far from the player
    void InstantiateFinishPortal()
    {
        if (FinishPortalPrefab != null && playerTransform != null)
        {
            Vector3 playerPosition = playerTransform.position;

            // Attempt to find a position far from the player
            Vector3 portalPosition;
            do
            {
                int randomRow = Random.Range(0, Rows);
                int randomColumn = Random.Range(0, Columns);

                float x = randomColumn * (CellWidth + (AddGaps ? 0.2f : 0));
                float z = randomRow * (CellHeight + (AddGaps ? 0.2f : 0));

                portalPosition = new Vector3(x, 1, z);
            } while (Vector3.Distance(playerPosition, portalPosition) < MinDistanceFromPlayer);

            // Instantiate the finish portal at the chosen position
            GameObject finishPortal = Instantiate(FinishPortalPrefab, portalPosition, Quaternion.Euler(0, 0, 0)) as GameObject;
            finishPortal.transform.parent = transform;
        }
    }
}
