using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class RotationSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref RotationSpeedComponent rotationSpeed, ref Rotation rotation) =>
        {
            rotation.Value = math.mul(rotation.Value,
                quaternion.RotateY(math.radians(
                    rotationSpeed.rotationSpeed * Time.deltaTime)));
        });
    }
}
