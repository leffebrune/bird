using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class WindowMaterials : Singleton<WindowMaterials>
{
    Material[] materials;

    void Awake()
    {
        materials = new Material[6];

        var refMaterial = Resources.Load("Materials/WindowLight_yellow") as Material;
        
        for (var i = 0; i < 6; i++)
            materials[i] = new Material(refMaterial);

        materials[0].color = new Color(0.593f, 0.727f, 0.551f);
        materials[1].color = new Color(0.625f, 0.427f, 0.179f);
        materials[2].color = new Color(0.333f, 0.522f, 0.501f);
        materials[3].color = new Color(0.459f, 0.558f, 0.427f);
        materials[4].color = new Color(0.279f, 0.135f, 0.0f);
        materials[5].color = new Color(0.090f, 0.177f, 0.181f);
    }    

    public static Material Get(int idx)
    {        
        return Instance.materials[idx];
    }
}
