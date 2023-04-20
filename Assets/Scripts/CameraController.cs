using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {

        // El objeto al que va a seguir la cámara
        [SerializeField]
        private Transform target;

        // Ángulo de la cámara
        [SerializeField]
        private float angle;

        // Distancia a la que se coloca la cámara con respecto a la arquera
        [SerializeField]
        private float distance;

        // Desplazamiento con respecto al pivote de la arquera 
        // (para que la cámara esté más orienta hacia la cabeza que a los pies)
        [SerializeField]
        private Vector3 offset;
        
        // Velocidad a la que se mueve la cámara con Vector3.MoveTowards()
        //[SerializeField]
        //private float travelSpeed;

        // Tiempo que tarda la cámara en moverse a la nueva ubicación con Vector3.Lerp()
        [SerializeField]
        private float travelTime;

        private void Update()
        {
            var referencedPosition = target.position + offset;
            float offsetY = Mathf.Cos(angle * Mathf.Deg2Rad) * distance;
            float offsetX = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;

            var newPosition = referencedPosition + target.rotation * new Vector3(0, offsetY, offsetX);

            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime / travelTime);


           // this.transform.position = new Vector3(distance + target.position.x, distance + target.position.y, distance + target.position.z);
           // this.transform.rotation = Quaternion.Euler(angle, target.eulerAngles.y, 0);
            transform.LookAt(target);
        }
    }
}
