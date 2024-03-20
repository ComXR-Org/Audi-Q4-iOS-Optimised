using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCombinationManagerV2 : MonoBehaviour
{
   [SerializeField] int curCombi = 0;
    public materialChangeSystem[] mcsCombis;
    public void NextCombi()
    {
        foreach (materialChangeSystem mcs in mcsCombis)
        {
            mcs.nextMat = true;
        }
    }
    public void NextCombinationNumber()
    {
        curCombi++;
        if (curCombi < mcsCombis[0].materials.Length)
            SetCombination(curCombi);
        else
            curCombi = 0;
    }
public void SetCombination(int i)
    {
        curCombi = i;
        foreach (materialChangeSystem mcs in mcsCombis)
        {
            mcs.SetMaterial(i);
        }
    }
}
