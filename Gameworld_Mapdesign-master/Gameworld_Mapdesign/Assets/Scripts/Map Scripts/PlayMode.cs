using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMode : MonoBehaviour {

    HexCoordinates randomCoordinate;
    //public HexGrid randomGrid;
    //HexGridChunk randomGridChunk;
    public HexMapEditor gamePlayEditor;
    public HexMapCamera hexMapCamera;

    HexCoordinates RandomCoordinate()
    {
       // randomGrid.GetComponent<HexGridChunk>();
        int x = Random.Range(-29, 79);
        int z = Random.Range(0,59);
        randomCoordinate = HexCoordinates.FromOffsetCoordinates(x,z);
        Debug.Log(randomCoordinate);
        return randomCoordinate;
    }

    public void RespawnPlayInRandomCell()
    {
        gamePlayEditor.GetComponent<HexMapEditor>();
        while (!gamePlayEditor.CreateUnit(RandomCoordinate()))
        {
            Debug.Log("Random player set up!");
            hexMapCamera = hexMapCamera.GetComponent<HexMapCamera>();
           // hexMapCamera.MovingCameraToUnit();
        }
    }
}
