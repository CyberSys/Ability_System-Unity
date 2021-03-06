﻿using System;
using System.Collections;
using System.Collections.Generic;
using AbilitySystem.MetaData;
using UnityEngine;

namespace AbilitySystem.TrajectorySystem.ImpactEffects
{
    [CreateAssetMenu(menuName = "Abilities/Trajectory System/Impact Effects/AOEImpact")]
    public class AOEImpact : Projectiles.ImpactEffect
    {

        [Header("AOEImpact settings")]

        public float lifeTime = 0;
        public bool oneTime = true;

        public float radius = 1;

        public Vector3 offset;

        public Projectiles.AOEEffect[] effectsToPlay;

        MonoHelper.AOEImpactable AOEHelper;


        public override void OnCollision(Collision collision, PlayerMetaData sender)
        {
            Vector3 position = AverageCollisionPosition(collision) + offset;

            GameObject aoeColliderObject = new GameObject("--AOE Collider--");

            AOEHelper = 
                aoeColliderObject.AddComponent<MonoHelper.AOEImpactable>()
                as MonoHelper.AOEImpactable;

            AOEHelper.SetSettings(this, sender);

            aoeColliderObject.transform.position = position;

            //Instantiate(aoeColliderObject, position , Quaternion.identity);
        }

        public override void OnCollision(Collider other, PlayerMetaData sender)
        {
            //throw new NotImplementedException();
        }

    }
}