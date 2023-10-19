using System;
using UnityEngine;

namespace SampleProject
{
    [Serializable]
    public struct MoveStateComponent
    {
        public bool moveRequired; //False
        public Vector3 direction;
    }
}