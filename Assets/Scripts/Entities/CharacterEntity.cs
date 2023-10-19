using System;
using Ecs;
using SampleProject;
using UnityEngine;

namespace Entities
{
    public sealed class CharacterEntity : Entity
    {
        [SerializeField]
        private float speed = 5.0f;
        
        protected override void OnInit()
        {
            this.SetData(new MoveSpeedComponent
            {
                value = this.speed
            });
            this.SetData(new TransformComponent
            {
                value = this.transform
            });
            this.SetData(new MoveStateComponent());
            this.SetData(new AnimatorComponent
            {
                value = this.GetComponent<Animator>()
            });
        }
    }
}