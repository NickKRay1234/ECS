using Ecs;
using SampleProject;
using UnityEngine;

namespace Systems
{
    public sealed class MovementSystem : IFixedUpdateSystem
    {
        private ComponentPool<MoveStateComponent> statePool;
        private ComponentPool<MoveSpeedComponent> speedPool;
        private ComponentPool<TransformComponent> transformPool;

        void IFixedUpdateSystem.OnFixedUpdate(int entity) //Index на мою сущность!
        {
            if (!this.statePool.HasComponent(entity))
            {
                return;
            }
            
            ref MoveStateComponent stateComponent = ref this.statePool.GetComponent(entity);
            if (!stateComponent.moveRequired)
            {
                return;
            }
            
            //Логика перемещения:
            ref TransformComponent transformComponent = ref this.transformPool.GetComponent(entity);
            ref MoveSpeedComponent moveSpeedComponent = ref this.speedPool.GetComponent(entity);

            var direction = stateComponent.direction;
            var offset = direction * moveSpeedComponent.value * Time.fixedDeltaTime;
            transformComponent.value.position += offset;
            transformComponent.value.rotation = Quaternion.LookRotation(direction, Vector3.up);

            stateComponent.moveRequired = false;
        }
    }
}