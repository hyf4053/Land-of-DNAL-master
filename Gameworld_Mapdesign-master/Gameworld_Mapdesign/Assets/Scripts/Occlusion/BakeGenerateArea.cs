using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BakeGenerateArea : MonoBehaviour {

    public OcclusionArea OA;
    //StaticOcclusionCulling SOC;

    private void Awake()
    {
        OA = OA.GetComponent<OcclusionArea>();
        BakeArea();
    }

    public void BakeArea()
    {
        StaticOcclusionCulling.Compute();
    }

    private void Update()
    {
        Debug.Log(StaticOcclusionCulling.isRunning);
    }

}
