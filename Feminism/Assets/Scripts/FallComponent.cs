using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct FallComponent : IComponentData
{
    public float fallSpeed;
    public float ceilingHeight;
}
