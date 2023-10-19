using System;
using Ecs;
using UnityEngine;

namespace SampleProject
{
    public sealed class MoveController : MonoBehaviour
    {
        private Entity[] entities;

        private void Awake()
        {
            this.entities = FindObjectsOfType<Entity>();
        }

        [ContextMenu("Move Forward")]
        public void MoveForward()
        {
            foreach (var entity in this.entities)
            {
                entity.SetData(new MoveToPositionCommand
                {
                    destination = entity.transform.position + Vector3.forward * 10
                });
            }
        }

        // private void Update()
        // {
        //     ref MoveStateComponent moveStateComponent = ref this.entity.GetData<MoveStateComponent>();
        //
        //     if (Input.GetKey(KeyCode.LeftArrow))
        //     {
        //         moveStateComponent.moveRequired = true;
        //         moveStateComponent.direction = Vector3.left;
        //     }
        //     else if (Input.GetKey(KeyCode.RightArrow))
        //     {
        //         moveStateComponent.moveRequired = true;
        //         moveStateComponent.direction = Vector3.right;
        //     }
        // }
    }
}