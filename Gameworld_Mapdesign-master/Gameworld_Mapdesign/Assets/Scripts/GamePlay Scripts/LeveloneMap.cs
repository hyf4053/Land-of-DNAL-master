using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveloneMap : MonoBehaviour {

    public int MAXCITY, MAXPORTAL, MAXVILLAGE, MAXRAREORE, MAXHIDDENPLACES, MAXENEMYZONE, MAXDOCK, MAXCHURCH;

    public LeveloneMap(int MAXCITY, int MAXPORTAL, int MAXVILLAGE, int MAXRAREORE, int MAXHIDDENPLACES
        ,int MAXENEMYZONE, int MAXDOCK,int MAXCHURCH)
    {
        this.MAXCITY = MAXCITY;
        this.MAXPORTAL = MAXPORTAL;
        this.MAXVILLAGE = MAXVILLAGE;
        this.MAXRAREORE = MAXRAREORE;
        this.MAXHIDDENPLACES = MAXHIDDENPLACES;
        this.MAXENEMYZONE = MAXENEMYZONE;
        this.MAXDOCK = MAXDOCK;
        this.MAXCHURCH = MAXCHURCH;
    }

    public int CountAllFeatures()
    {
        int total = MAXCITY + MAXPORTAL + MAXVILLAGE + MAXRAREORE + MAXHIDDENPLACES + MAXENEMYZONE +
            MAXDOCK + MAXCHURCH;
        return total;
    }

}
