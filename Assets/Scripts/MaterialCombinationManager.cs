using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCombinationManager : MonoBehaviour
{
    public materialChangeSystem[] mcsCombis;
public void SetCombination(int i)
    {
        foreach (materialChangeSystem mcs in mcsCombis)
        {
            mcs.SetMaterial(i);
        }
    }
}
