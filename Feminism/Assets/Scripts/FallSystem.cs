using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

//public class FallSystem : ComponentSystem
//{
//    protected override void OnUpdate()
//    {
//        Entities.ForEach((ref FallComponent fallComponent, ref Translation translation) =>
//        {
//            translation.Value.y -= fallComponent.fallSpeed * Time.deltaTime;

//            if (translation.Value.y <= 0)
//                translation.Value.y = fallComponent.ceilingHeight;
//        });
//    }
//}
