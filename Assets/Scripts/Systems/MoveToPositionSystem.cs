using Ecs;
using SampleProject;

namespace Systems
{
    public sealed class MoveToPositionSystem : IFixedUpdateSystem
    {
        private const float MIN_SQR_DISTANCE = 0.01f;

        private ComponentPool<MoveToPositionCommand> commandPool;
        private ComponentPool<MoveStateComponent> movePool;
        private ComponentPool<TransformComponent> transformPool;

        void IFixedUpdateSystem.OnFixedUpdate(int entity)
        {
            if (!this.commandPool.HasComponent(entity))
            {
                return;
            }

            ref MoveToPositionCommand command = ref this.commandPool.GetComponent(entity);
            ref MoveStateComponent moveComponent = ref this.movePool.GetComponent(entity);
            ref TransformComponent transformComponent = ref this.transformPool.GetComponent(entity);

            var endPosition = command.destination;
            var myPosition = transformComponent.value.position;

            var distanceVector = endPosition - myPosition;
            if (distanceVector.sqrMagnitude > MIN_SQR_DISTANCE)
            {
                moveComponent.moveRequired = true;
                moveComponent.direction = distanceVector.normalized;
            }
            else
            {
                this.commandPool.RemoveComponent(entity);
            }
        }
    }
}