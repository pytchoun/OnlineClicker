using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private List<Tile> _tileList = new List<Tile>();

    public List<Tile> GetTileList()
    {
        return _tileList;
    }

    private void Start()
    {
        foreach (Tile child in GetComponentsInChildren<Tile>())
        {
            if (child.name == "tile")
            {
                _tileList.Add(child);
            }
        }

        GetTitlesState();
    }

    public Tile GetTile(GameObject tree)
    {
        int value = 0;
        for (int i = 0; i < 100; i++)
        {
            value = Random.Range(0, _tileList.Count);
            Tile tile = _tileList[value];
            if (tile.IsFree)
            {
                tile.IsFree = false;
                tile.tree = tree;
                return _tileList[value];
            }
        }
        Debug.Log("Not tile found");
        return null;
    }

    public void GetTitlesState()
    {
        List<string> list = new List<string>();

        int index = 0;
        foreach (var tile in _tileList)
        {
            Tile t = tile;
            /*Debug.Log(t.IsFree);
            Debug.Log(t.tree);
            Debug.Log(index);*/
            list.Add(index.ToString());
            list.Add(t.IsFree.ToString());
            list.Add(t.tree.ToString());
            index++;
        }
        Debug.Log(list.Count);
        Debug.Log(list[0]);
        Debug.Log(list[1]);
        Debug.Log(list[2]);
        foreach (var l in list)
        {
            //Debug.Log(l);
        }
    }
}