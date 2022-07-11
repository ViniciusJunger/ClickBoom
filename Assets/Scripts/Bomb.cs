using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Target
{
    
    private float minImp = 1f;
    private float maxImp = 3f;
    private float minZ = -2.5f;
    private float maxZ = -0.5f;

    public override float ReturnZ()
    {
        float Z = Random.Range(minZ, maxZ);
        return Z;
    }

    public override float ReturnImpulse()
    {
        float max = maxImp;
        float min = minImp;
        float Imp = Random.Range(min, max);
        return Imp;
    }

}