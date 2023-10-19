using Ecs;
using Systems;
using UnityEngine;

namespace SampleProject
{
    public sealed class EcsManager : MonoBehaviour
    {
        private readonly EcsWorld ecsWorld = new();

        private void Awake()
        {
            this.ecsWorld.BindComponent<MoveStateComponent>();
            this.ecsWorld.BindComponent<MoveSpeedComponent>();
            this.ecsWorld.BindComponent<TransformComponent>();
            this.ecsWorld.BindComponent<AnimatorComponent>();
            this.ecsWorld.BindComponent<MoveToPositionCommand>();
            
            this.ecsWorld.BindSystem<MovementSystem>();
            this.ecsWorld.BindSystem<MoveAnimationSystem>();
            this.ecsWorld.BindSystem<MoveToPositionSystem>();
            
            this.ecsWorld.Install();

            foreach (var entity in FindObjectsOfType<Entity>())
            {
                entity.Init(this.ecsWorld);
            }
        }

        private void Update()
        {
            this.ecsWorld.Update();
        }

        private void FixedUpdate()
        {
            this.ecsWorld.FixedUpdate();
        }

        private void LateUpdate()
        {
            this.ecsWorld.LateUpdate();
        }
    }
}