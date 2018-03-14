using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetHexInfo : MonoBehaviour
{

    // HexMesh hexMesh;
    // HexCell cell;
    //HexDirection NE = HexDirection.NE;

    public Text cellInfoDisplay;
    public HexGrid hexGrid;
    public HexMapEditor hexMapEditor;
    public HexCoordinates currentHexCoordinates;

    public HexCell[] preSelectCell;

    public HexCell currentHexCell;
    public string terrain;
    public string elevation;
    public int urbanLevel;
    public bool IsUnderwater, HasRiver, HasRiverBeginOrEnd, HasRoads, IsSpecial, Walled, IsVisible, IsExplored, Explorable;
    //public Terrain terrain;



    LeveloneMap firstMap = new LeveloneMap(8,2,5,13,3,4,2,2);

    private void Awake()
    {
        hexGrid = hexGrid.GetComponent<HexGrid>();
        hexMapEditor = hexMapEditor.GetComponent<HexMapEditor>();
        preSelectCell = new HexCell[2];
        preSelectCell.SetValue(null, 0);
        preSelectCell.SetValue(null, 1);
    }

    private void Update()
    {
        //hexMapEditor = hexMapEditor.GetComponent<HexMapEditor>();
        if (
        Input.GetMouseButtonUp(0) &&
        !EventSystem.current.IsPointerOverGameObject()
    )
        {
            currentHexCoordinates = hexMapEditor.HandleInput(1);
            Debug.Log(currentHexCoordinates.ToString());
            GetHexGridInfo();
            SetCitys(firstMap.MAXCITY);
            SetPortal(firstMap.MAXPORTAL);
            SetVillage(firstMap.MAXVILLAGE);
            //GetHexCellList();
        }
    }

    public void GetHexGridInfo()
    {
        
        currentHexCell = hexGrid.GetCell(currentHexCoordinates);
        terrain = currentHexCell.TerrainTypeIndex.ToString();
        elevation = currentHexCell.Elevation.ToString();
        IsUnderwater = currentHexCell.IsUnderwater;
        HasRiver = currentHexCell.HasRiver;
        HasRiverBeginOrEnd = currentHexCell.HasRiverBeginOrEnd;
        HasRoads = currentHexCell.HasRoads;
        IsSpecial = currentHexCell.IsSpecial;
        Walled = currentHexCell.Walled;
        IsVisible = currentHexCell.IsVisible;
        IsExplored = currentHexCell.IsExplored;
        Explorable = currentHexCell.Explorable;

        urbanLevel = currentHexCell.UrbanLevel;

        currentHexCell.EnableHighlight(Color.yellow);
        //currentHexCell.PortalIndex = 1;
        //currentHexCell.Walled = true;
       // currentHexCell.SpaceCrackIndex = 1;
        //currentHexCell.SpecialIndex = 1;
       // Debug.Log(currentHexCell.SpaceCrackIndex);
        //currentHexCell.SpaceCrackIndex
        //currentHexCell.UrbanLevel = 1;
        if (preSelectCell.GetValue(0) != null && (HexCell)preSelectCell.GetValue(0) != currentHexCell)
        {
            preSelectCell.SetValue(currentHexCell, 1);
            HexCell cell=(HexCell)preSelectCell.GetValue(0);
            cell.DisableHighlight();
            preSelectCell.SetValue(null, 0);
        }else if(preSelectCell.GetValue(1) != null && (HexCell)preSelectCell.GetValue(1) != currentHexCell)
        {
            preSelectCell.SetValue(currentHexCell, 0);
            HexCell cell = (HexCell)preSelectCell.GetValue(1);
            cell.DisableHighlight();
            preSelectCell.SetValue(null, 1);
        }
        else if (preSelectCell.GetValue(0) == null && preSelectCell.GetValue(1)==null) 
        {
            preSelectCell.SetValue(currentHexCell, 0);
        }
        cellInfoDisplay.text = "Cell Position："+currentHexCoordinates.ToString() +"\n" + "Terrain：" + terrain + "\n" + "Elevation：" + elevation + "\n" + "Is Underwater：" + IsUnderwater +
            "\n" + "Has River：" + HasRiver + "\n" + "Has River B OR E：" + HasRiverBeginOrEnd + "\n" + "Has Roads：" + HasRoads +
            "\n" + "Is Special：" + IsSpecial + "\n" + "Is Visible：" + IsVisible + "\n" + "Is Explored：" + IsExplored + "\n" + "Explorable：" + Explorable;
    }


    public int GetHexCellListLength()
    {
        int cellLength;
        cellLength = hexGrid.cells.Length;
        return cellLength;
    }

    public int TotalRandomTimes()
    {
        int maxRandomTimes;
        maxRandomTimes = firstMap.CountAllFeatures();
        return maxRandomTimes;
    }

    public int GetRandomNum()
    {
        int random = Random.Range(0,GetHexCellListLength()-1);
        return random;
    }

    public void SetCitys(int cityNum)
    {
        for (int i = 0;i<cityNum; i++)
        {
            int random = GetRandomNum();
            Debug.Log(random);
            if (i==0&&!hexGrid.cells[random].IsUnderwater&&hexGrid.cells[random].TerrainTypeIndex!=4)
            {
                hexGrid.cells[random].UrbanLevel = 3;
                hexGrid.cells[random].Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.NE).UrbanLevel = 2;
                hexGrid.cells[random].GetNeighbor(HexDirection.NE).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.E).UrbanLevel = 3;
                hexGrid.cells[random].GetNeighbor(HexDirection.E).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.NW).UrbanLevel = 2;
                hexGrid.cells[random].GetNeighbor(HexDirection.NW).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.SE).UrbanLevel = 2;
                hexGrid.cells[random].GetNeighbor(HexDirection.SE).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.SW).UrbanLevel = 1;
              //  hexGrid.cells[random].GetNeighbor(HexDirection.SW).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.W).UrbanLevel = 1;
                hexGrid.cells[random].GetNeighbor(HexDirection.W).Walled = true;
            }
            else if (i!=0&&!hexGrid.cells[random].IsUnderwater)
            {
                hexGrid.cells[random].UrbanLevel = 3;
                hexGrid.cells[random].Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.NE).UrbanLevel = 2;
                hexGrid.cells[random].GetNeighbor(HexDirection.NE).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.E).UrbanLevel = 3;
                hexGrid.cells[random].GetNeighbor(HexDirection.E).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.NW).UrbanLevel = 2;
                hexGrid.cells[random].GetNeighbor(HexDirection.NW).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.SE).UrbanLevel = 2;
                hexGrid.cells[random].GetNeighbor(HexDirection.SE).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.SW).UrbanLevel = 1;
                hexGrid.cells[random].GetNeighbor(HexDirection.SW).Walled = true;
                hexGrid.cells[random].GetNeighbor(HexDirection.W).UrbanLevel = 1;
              //  hexGrid.cells[random].GetNeighbor(HexDirection.W).Walled = true;
            }
            else
            {
                i--;
            }
        }
    }

    public void SetPortal(int portalNum)
    {
        for (int i = 0; i < portalNum; i++)
        {
            int random = GetRandomNum();
            if (!hexGrid.cells[random].IsUnderwater && hexGrid.cells[random].UrbanLevel == 0&&hexGrid.cells[random].PortalIndex == 0)
            {
                hexGrid.cells[random].PortalIndex = 1;
            }
            else
            {
                i--;
            }
        }
    }

    public void SetVillage(int villageNum)
    {
        for (int i = 0; i < villageNum; i++)
        {
            int random = GetRandomNum();
            if (!hexGrid.cells[random].IsUnderwater && hexGrid.cells[random].UrbanLevel == 0 && hexGrid.cells[random].PortalIndex == 0)
            {

                hexGrid.cells[random].VillageIndex = 1;
            }
            else{
                i--;
            }
        }
    }

    public void SetRareOre(int oreNum)
    {
        for (int i = 0; i < oreNum; i++)
        {
            int random = GetRandomNum();
            if (!hexGrid.cells[random].IsUnderwater && hexGrid.cells[random].UrbanLevel == 0 && hexGrid.cells[random].PortalIndex == 0)
            {

            }
        }
    }

    public void SetHiddenPlaces(int hiddenPlaceNum)
    {
        for (int i = 0; i < hiddenPlaceNum; i++)
        {
            int random = GetRandomNum();
            if (!hexGrid.cells[random].IsUnderwater && hexGrid.cells[random].UrbanLevel == 0 && hexGrid.cells[random].PortalIndex == 0)
            {

            }
        }
    }

    public void SetEnemyZone(int enemyZoneNum)
    {
        for (int i = 0; i < enemyZoneNum; i++)
        {
            int random = GetRandomNum();
            if (!hexGrid.cells[random].IsUnderwater && hexGrid.cells[random].UrbanLevel == 0 && hexGrid.cells[random].PortalIndex == 0)
            {

            }
        }
    }

    public void SetDock(int dockNum)
    {
        for (int i = 0; i < dockNum; i++)
        {
            int random = GetRandomNum();
            if (hexGrid.cells[random].IsUnderwater && hexGrid.cells[random].UrbanLevel == 0 && hexGrid.cells[random].PortalIndex == 0)
            {

            }
        }
    }

    public void SetChurch(int churchNum)
    {
        for (int i = 0; i < churchNum; i++)
        {
            int random = GetRandomNum();
            if (!hexGrid.cells[random].IsUnderwater && hexGrid.cells[random].UrbanLevel == 0 && hexGrid.cells[random].PortalIndex == 0)
            {

            }
        }
    }

}