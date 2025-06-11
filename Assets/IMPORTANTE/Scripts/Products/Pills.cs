using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pills : MonoBehaviour
{
    [HideInInspector] public GameObject player;
    [SerializeField] float effectDuration = 4;

    public void RegenerateSanity()
    {
        StartCoroutine(PillsEffect());
    }

    private IEnumerator PillsEffect()
    {
        player = GameObject.Find("Player");
        Sanity sanity = player.GetComponent<Sanity>();

        float initialRgenerationSpeed = sanity.regenerationSpeed;
        sanity.regenerationSpeed = 1.5f;

         yield return new WaitForSeconds(effectDuration);

        sanity.regenerationSpeed = initialRgenerationSpeed;
    }
}
