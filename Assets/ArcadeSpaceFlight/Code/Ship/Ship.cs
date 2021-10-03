//
// Copyright (c) Brian Hernandez. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.
//
using System;
using UnityEngine;

namespace SpaceFighter
{
    /// <summary>
    /// Ties all the primary ship components together.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ShipPhysics))]
    [RequireComponent(typeof(ShipInput))]
    public class Ship : MonoBehaviour
    {
        public bool isPlayer = false;

        private ShipInput input;
        private ShipPhysics physics;

        // Keep a static reference for whether or not this is the player ship. It can be used
        // by various gameplay mechanics. Returns the player ship if possible, otherwise null.
        public static Ship PlayerShip { get { return playerShip; } }
        private static Ship playerShip;
        private int CurrentHealth;

        public int MaxHealth = 100;


        // Getters for external objects to reference things like input.
        public bool UsingMouseInput { get { return input.useMouseInput; } }
        public Vector3 Velocity { get { return physics.Rigidbody.velocity; } }
        public float Throttle { get { return input.throttle; } }

        private void Awake()
        {
            input = GetComponent<ShipInput>();
            physics = GetComponent<ShipPhysics>();
            CurrentHealth = MaxHealth;
        }

        private void Update()
        {
            // Pass the input to the physics to move the ship.
            physics.SetPhysicsInput(new Vector3(input.strafe, 0.0f, input.throttle), new Vector3(input.pitch, input.yaw, input.roll));
            //gunController.Update();
            // If this is the player ship, then set the static reference. If more than one ship
            // is set to player, then whatever happens to be the last ship to be updated will be
            // considered the player. Don't let this happen.
            if (isPlayer)
                playerShip = this;

            //Check player health
            if (CurrentHealth < 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision coll)
        {
            Debug.Log("Ship Collision");
            Debug.Log(coll.gameObject.name);
            Debug.Log(coll.relativeVelocity.magnitude);
            Debug.Log(coll.rigidbody.mass);
            int damage = (int)Math.Floor(coll.relativeVelocity.magnitude * coll.rigidbody.mass);
            Debug.Log(damage);
            CurrentHealth -= damage;
        }
    }
}
