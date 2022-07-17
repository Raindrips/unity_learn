using System.Collections;
using UnityEngine;

namespace Assets.Scripts.core {
    public class CoinControll : MonoBehaviour {

        float moveSpeed = 8;
        void Start() {

        }

        void Update() {
            Vector3 targetPosition = GoldSpawner.Instance.transform.position;
            Vector3 direction = (targetPosition-transform.position ).normalized;
            transform.Translate(moveSpeed * Time.deltaTime * direction);

            float distance=
                targetPosition.magnitude - transform.position.magnitude;
            if (distance<0.1) {
                Destroy(gameObject);
            }
        }
    }
}