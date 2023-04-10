using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private string targetTag;
    [SerializeField] private float appliedForce;
    [SerializeField] private PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(targetTag))
        {
            float attackDir = playerMovement.isFacingRight ? 1 : -1;
            col.attachedRigidbody.AddForce(Vector3.right*attackDir*appliedForce,ForceMode2D.Impulse);
        }
    }
}
