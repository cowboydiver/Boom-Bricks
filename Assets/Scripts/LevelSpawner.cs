using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField]
    Brick normalBrickPrefab;
    [SerializeField]
    Brick fuelBrickPrefab;

    [SerializeField]
    int fuelBrickSpawnCount = 3;

    [SerializeField]
    Vector2 PlayAreaDefualtDimensions = new Vector2();
    [SerializeField]
    Vector2 margins = new Vector2();

    public bool levelReady { get; private set; }

    public void SpawnLevel()
    {
        SpawnLevel(PlayAreaDefualtDimensions);
    }

    public void SpawnLevel(Vector2 PlayAreaDimension)
    {

        GameManager.Instance.SpawnBall(new Vector3(0f, -1.5f, 0f));

        levelReady = false;

        for (int y = 0; y < PlayAreaDimension.y; y++)
        {
            for (int x = 0; x < PlayAreaDimension.x; x++)
            {

                Brick newBrick = Instantiate(normalBrickPrefab, transform);

                Vector3 pos = new Vector3(x * (newBrick.gameObject.GetComponent<Renderer>().bounds.size.x + margins.x), y * (newBrick.gameObject.GetComponent<Renderer>().bounds.size.y + margins.y), 0f);

                newBrick.transform.localPosition = pos;
            }
        }

        levelReady = true;
    }
}
