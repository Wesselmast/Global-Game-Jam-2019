using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{

    public Transform[] positions;
    public bool[] occupied;
    public Elderly[] elders;

    public Need zoneActivity;

    private void Start()
    {
        positions = GetComponentsInChildren<Transform>();

        Transform[] temp = new Transform[positions.Length - 1];

        for (int i = 1; i < positions.Length; i++)
        {
            temp[i - 1] = positions[i];
        }

        positions = temp;


        occupied = new bool[positions.Length];
        elders = new Elderly[positions.Length];
    }

    private void Update()
    {

    }

    public Transform RequestWaypoint(Elderly elder)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (elders[i] == null)
            {
                elders[i] = elder;
                return positions[i];
            }
        }

        return null;
    }

    public void Leave(Elderly elder)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (elders[i] == elder)
            {
                elders[i] = null;
            }
        }
    }

}
