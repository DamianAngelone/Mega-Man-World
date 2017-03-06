using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour {

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
