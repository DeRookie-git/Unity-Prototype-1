using System;
using UnityEngine;

public class Checkpoints : MonoBehaviour, IComparable<Checkpoints>
{
    public Transform vehicle;
    public Color activeColor = Color.green;
    public Color nextColor = Color.grey;
    public Color completedColor = Color.blue; //wip

    public float distanceToVehicle;
    public float disappearDistance = 5f;

    public bool isCollected = false;

    public void UpdateDistance()
    {
        distanceToVehicle = Vector3.Distance(transform.position, vehicle.position);
        if (distanceToVehicle < disappearDistance)
        {
            gameObject.SetActive(false);
        }
    }

    public int CompareTo(Checkpoints other)
    {
        return distanceToVehicle.CompareTo(other.distanceToVehicle);
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void Collect()
    {
        isCollected = true;
        gameObject.SetActive(false);
    }
}
