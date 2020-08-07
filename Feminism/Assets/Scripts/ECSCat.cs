using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;
using System;

public class ECSCat : MonoBehaviour
{
    [SerializeField] private Mesh catMesh;
    [SerializeField] private Material catMaterial;
    public Transform frontRight, backLeft;
    public int numberOfCats;
    public float sizeOfCats;
    public Vector2 fallSpeed;
    public Vector2 rotationSpeed;

    private void Start()
    {
        EntityManager entityManager = World.Active.EntityManager;

        EntityArchetype entityArchetype = CreateEntityArchetype(entityManager);
        CreateEntities(entityManager, entityArchetype);
    }

    private void CreateEntities(EntityManager entityManager, EntityArchetype entityArchetype)
    {
        NativeArray<Entity> entityArray = new NativeArray<Entity>(numberOfCats, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];

            entityManager.SetComponentData(entity, new Rotation { Value = new quaternion(0, 0, 0, 1) });
            entityManager.SetComponentData(entity, new RotationSpeedComponent { rotationSpeed = GetRandomRotationSpeed() });
            entityManager.SetComponentData(entity, new LocalToWorld { });
            entityManager.SetComponentData(entity, new Translation { Value = GetRandomPosition() });
            entityManager.SetComponentData(entity, new Scale { Value = sizeOfCats });
            entityManager.SetComponentData(entity, new FallComponent { ceilingHeight = frontRight.transform.position.y, fallSpeed = GetFallSpeed() });
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = catMesh,
                material = catMaterial
            });
        }

        entityArray.Dispose();
    }

    private static EntityArchetype CreateEntityArchetype(EntityManager entityManager)
    {
        return entityManager.CreateArchetype(
            typeof(RenderMesh),
            typeof(Translation),
            typeof(LocalToWorld),
            typeof(Scale),
            typeof(Rotation),
            typeof(FallComponent),
            typeof(RotationSpeedComponent)
            );
    }

    private float GetRandomRotationSpeed()
    {
        float speed = UnityEngine.Random.Range(rotationSpeed.x, rotationSpeed.y);
        return speed;
    }

    private float GetFallSpeed()
    {
        float speed = UnityEngine.Random.Range(fallSpeed.x, fallSpeed.y);
        return speed;
    }

    private Vector3 GetRandomPosition()
    {
        float XPos = UnityEngine.Random.Range(backLeft.position.x, frontRight.position.x);
        float ZPos = UnityEngine.Random.Range(backLeft.position.z, frontRight.position.z);
        float YPos = backLeft.position.y;
        Vector3 position = new Vector3(XPos, YPos, ZPos);
        return position;
    }
}
