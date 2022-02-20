using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPieces : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }
}
