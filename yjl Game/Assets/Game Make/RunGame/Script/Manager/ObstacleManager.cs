using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] Transform[] createPositions;
    [SerializeField] GameObject [] vehiclePrefabs;
    [SerializeField] List<GameObject> vehicles;
    [SerializeField] int randSeed;

    WaitForSeconds waitForSeconds = new WaitForSeconds(5f);

    void Start()
    {
        vehicles.Capacity = 10;

        CreateVehicle();

        StartCoroutine(ActiveVehicle());
    }

    public void CreateVehicle()
    {
        for (int i = 0; i < vehiclePrefabs.Length; i++)
        {
            GameObject vehicle = Instantiate(vehiclePrefabs[i]);

            vehicle.SetActive(false);

            vehicles.Add(vehicle);
        }
    }

    IEnumerator ActiveVehicle()
    {
        yield return new WaitForSeconds(0.01f);

        while (true)
        {
            randSeed = Random.Range(0, vehicles.Count);

            while (vehicles[randSeed].activeSelf == true)
            {
                randSeed = (randSeed + 1) % vehicles.Count;
            }
            vehicles[randSeed].transform.position = createPositions[Random.Range(0, createPositions.Length)].position;
            vehicles[randSeed].SetActive(true);

            yield return waitForSeconds;
        }
    }
}
