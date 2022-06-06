using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public GameObject[] tiles;

    public void displayTileCoordinates()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            print(tiles[i].transform.position);
        }
    }

    public void displaySpecificCoordinate(string coord){
        int let = coord[0]-65;
        let *= 8;
        int num = coord[1]-48;

        int total = let +num;

        print(tiles[total].transform.position);
    }
}
