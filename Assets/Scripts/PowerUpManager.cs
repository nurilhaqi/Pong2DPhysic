using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public int spawnInterval;


    public List<GameObject> powerUpTemplateList;

    private List<GameObject> powerUpList;

    public PowerUpManager manager;

    private float timer;
    public int liveTime;
    private float liveTimeInterval;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
        liveTimeInterval = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        liveTimeInterval += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }

        if (liveTimeInterval > liveTime && powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
            liveTimeInterval -= liveTime;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x || position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int random = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[random], new Vector3(position.x, position.y, powerUpTemplateList[random].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
