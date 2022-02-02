using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tileList = new List<GameObject>();

    private void Start()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == "tile")
            {
                _tileList.Add(child.gameObject);
            }
        }
    }

    public GameObject GetTile()
    {
        int value = 0;
        for (int i = 0; i < 100; i++)
        {
            value = Random.Range(0, _tileList.Count);
            Tile tile = _tileList[value].GetComponent<Tile>();
            if (tile.IsFree)
            {
                tile.IsFree = false;
                return _tileList[value];
            }
        }
        Debug.Log("Not tile found");
        return null;
    }
}