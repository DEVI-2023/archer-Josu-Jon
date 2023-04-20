using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            hitPoints--;
            Debug.Log("Me queda " + hitPoints + " de vida");
            if (hitPoints <= 0)
            {
                Die();
            }
            else
            {
                animator.SetTrigger("Hit");
            }
        }

        private void Die()
        {
            animator.SetTrigger("Die");
            //yield return new WaitForSeconds(1.19f);
            Destroy(gameObject);
        }
    }

}