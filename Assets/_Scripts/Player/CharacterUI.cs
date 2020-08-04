using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    public Transform heartParent;
    public GameObject heartPrefab;
    public void SetHearts( int heartAmount)
    {
        for (int i = 0; i < heartAmount; i++)
        {
            Instantiate(heartPrefab).transform.SetParent(heartParent);
        }
    }
}
