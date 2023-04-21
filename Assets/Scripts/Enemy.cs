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
            this.GetComponent<Transform>().position = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
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
            new WaitForSeconds(4f);
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Si el objeto contra el que chocamos (collision.gameObject) está en las capas que consideramos suelo (layerMask)...
            if (collision.gameObject.tag == "Escenario")
            {
                this.GetComponent<Transform>().position = new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
            }
        }
    }

}