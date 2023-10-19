using Ecs;
using SampleProject;
using UnityEngine;

namespace Systems
{
    public sealed class MoveAnimationSystem : ILateUpdateSystem
    {
        private static readonly int State = Animator.StringToHash("State");

        private ComponentPool<AnimatorComponent> animatorPool;
        private ComponentPool<MoveStateComponent> movePool;

        void ILateUpdateSystem.OnLateUpdate(int entity)
        {
            if (!this.animatorPool.HasComponent(entity) || !this.movePool.HasComponent(entity))
            {
                return;
            }

            ref AnimatorComponent animatorComponent = ref this.animatorPool.GetComponent(entity);
            ref MoveStateComponent moveStateComponent = ref this.movePool.GetComponent(entity);

            if (moveStateComponent.moveRequired)
            {
                animatorComponent.value.SetInteger(State, 1);
            }
            else
            {
                animatorComponent.value.SetInteger(State, 0);
            }
        }
    }
}