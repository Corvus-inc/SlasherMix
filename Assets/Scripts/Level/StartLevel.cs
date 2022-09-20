using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private PlayerComposition playerComposition;
    private void Awake()
    {
        playerComposition.Construct();
    }
}
