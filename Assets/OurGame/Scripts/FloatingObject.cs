using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject: MonoBehaviour
{
    // Adapted from a float script from:
    // http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/

    // The item it's attached to
    [SerializeField] private GameObject actualItem;

    // User Inputs
    public float amplitude = 0.2f;
    public float frequency = 1f;
    public float startingY = .5f;

    // Position Storage Variables
    Vector3 tempPos = new Vector3();

    void Start()
    {
        tempPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Float up/down with sin() function
        tempPos = new Vector3(actualItem.transform.position.x, startingY, actualItem.transform.position.z);
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
