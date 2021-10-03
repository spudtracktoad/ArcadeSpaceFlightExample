using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFighter
{
    public class DamageHandler : MonoBehaviour
    {
        public int MaxHealth = 100;
        public int CurrentHealth;

        // Start is called before the first frame update
        void Start()
        {
            CurrentHealth = MaxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if(CurrentHealth <= 0)
                Destroy(gameObject);
        }

        // non returning method for applying damage
        public void ApplyDamage(int adj)
        {
            CurrentHealth -= adj;
            if (CurrentHealth <= 0)
                Destroy(gameObject);
        }
    }
}
