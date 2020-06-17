using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Main Settings")]
    public bool noLoosing = false;

    [Header("Wall Options")]
    public Transform wallSpawnLocation;
    public GameObject[] wallVariants;
    public float wallSpeed = 5f;
    public float waitAfterWallSpawn = 5f;
    public float startWait = 2f;

    private bool playing = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWalls());
    }

    private IEnumerator SpawnWalls()
    {
        yield return new WaitForSeconds(startWait);
        while (playing)
        {
            spawnWall(wallVariants[Random.Range(0, wallVariants.Length - 1)]);
            yield return new WaitForSeconds(waitAfterWallSpawn);
        }
    }

    private void spawnWall(GameObject wall)
    {
        GameObject newWall = Instantiate(wall, wallSpawnLocation);
        newWall.GetComponent<MeshRenderer>().enabled = true;// Af einhverri ástæðu er slökkt á þessu þegar veggnum er instantiatað svo að þetta þarf til þess að objectinn sjáist
    }

    public void GameOver()
    {
        if (!noLoosing)
        {
            playing = false;
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }
}
