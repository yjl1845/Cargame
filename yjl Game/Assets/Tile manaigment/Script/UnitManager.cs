using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] List<Bronzeunit> bronzeunit;

    List<Dictionary<string, object>> data;

    private void Awake()
    {
         CSVReader.Read("Bronze Unit");
    }

    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i <  bronzeunit.Count; i++)
        // {
        // 
        //     Debug.Log(data[i]["name"]);
        //     Debug.Log(data[i]["health"]);
        //     Debug.Log(data[i]["attack"]);
        // }
    }
}
