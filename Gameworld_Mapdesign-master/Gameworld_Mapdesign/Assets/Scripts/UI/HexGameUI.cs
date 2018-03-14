using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexGameUI : MonoBehaviour {

	public HexGrid grid;

	HexCell currentCell,playerChooseCell;

	HexUnit selectedUnit;

    List<HexCell> playerPath;

    int mouseState;

    private void Awake()
    {
        mouseState = 0;
    }

    public void SetEditMode (bool toggle) {
		enabled = !toggle;
		grid.ShowUI(!toggle);
		grid.ClearPath();
		if (toggle) {
			Shader.EnableKeyword("HEX_MAP_EDIT_MODE");
		}
		else {
			Shader.DisableKeyword("HEX_MAP_EDIT_MODE");
		}
	}

	void Update () {
        //HexCell currentCell = new HexCell() ;
		if (!EventSystem.current.IsPointerOverGameObject()) {
			if (Input.GetMouseButtonUp(0)) {
				DoSelection();
			}
			else if (selectedUnit) {
				if (Input.GetMouseButtonUp(1)) {
					DoMove();
                    
                    
				}
				else if(Input.GetMouseButtonUp(2)){
                    DoPathfinding(selectedUnit.Location);
                  
                    DoPlayerSelection();
                 
                    Debug.Log("Mouse mid is pressed");
                }
			}
		}
	}

    HexCell GetCellUnderCursor()
    {
        return
             grid.GetCell(Camera.main.ScreenPointToRay(Input.mousePosition));
    }

    void HandleInput()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButton(0))
            {
                DoSelection();
            }
        }
    }

    void DoPlayerPath()
    {
       
        GetCellUnderCursor();
    }

	void DoSelection () {
		//grid.ClearPath();
		UpdateCurrentCell();
		if (currentCell) {
			selectedUnit = currentCell.Unit;
		}
	}

    void DoPlayerSelection()
    {
        UpdateCurrentCell();
        if (currentCell)
        {
            playerChooseCell = currentCell;
        }
    }

	void DoPathfinding (HexCell chooseCell) {
		if (UpdateCurrentCell()) {
            Debug.Log("current cell update accpet");

            if (currentCell && selectedUnit.IsValidDestination(currentCell)) {
				grid.FindPath(chooseCell/*selectedUnit.Location*/, currentCell, selectedUnit);
                Debug.Log("DoPathFinding");
			}
			else {
				grid.ClearPath();
                //Debug.Log("DoPathingFinding clearpath");
			}
		}
	}

	void DoMove () {
		if (grid.HasPath) {
			selectedUnit.Travel(grid.GetPath());
			grid.ClearPath();
		}
	}

	bool UpdateCurrentCell () {
		HexCell cell =
			grid.GetCell(Camera.main.ScreenPointToRay(Input.mousePosition));
		if (cell != currentCell) {
			currentCell = cell;
			return true;
		}
		return false;
	}
}