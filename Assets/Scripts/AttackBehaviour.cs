﻿using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class AttackBehaviour
    {
        public float Speed;
        public float Power;
        public float Range;

        private float LastAttack = 0;
        private float mementoLastAttack;

        bool IsReady()
        {
            return (LastAttack + Speed) > Time.time;
        }

        public void Perform(Enemy target)
        {
            if (target != null && IsReady())
                target.Damage(Power);

        }

        public void Pause()
        {
            mementoLastAttack = LastAttack;
            LastAttack = float.PositiveInfinity;
        }

        internal void UnPause()
        {
            LastAttack = mementoLastAttack;
        }
    }
}