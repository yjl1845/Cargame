using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bronzeunit : Unit
{
    public abstract void Initialize(string filename, int count)
    {
        data = CSVReader.Read("Bronze Unit");

        name = (string)data[count]["name"];
        health = System.Convert.ToIn32(data[count]["health"]);
        attack = System.Convert.ToIn32(data[count]["attack"]);
    }

    protected override void Movement()
    {
        Debug.Log("¿Ãµø");
    }
}
