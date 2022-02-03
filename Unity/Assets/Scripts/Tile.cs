using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsFree;
    public GameObject tree = null;

    private void Start()
    {
        IsFree = true;
    }
}