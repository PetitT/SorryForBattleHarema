using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class FallJobSystem : JobComponentSystem
{
    [BurstCompile]
    private struct FallJob : IJobForEach<Translation, FallComponent>
    {
        public float DeltaTime;

        public void Execute(ref Translation translation, ref FallComponent fallComponent)
        {
            translation.Value.y -= fallComponent.fallSpeed;

            if (translation.Value.y <= 0)
                translation.Value.y = fallComponent.ceilingHeight;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        FallJob fallJob = new FallJob()
        {
            DeltaTime = Time.deltaTime
        };
        return fallJob.Schedule(this, inputDeps);
    }

}
