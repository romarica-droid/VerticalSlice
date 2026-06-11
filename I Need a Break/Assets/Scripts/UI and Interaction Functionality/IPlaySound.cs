using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlaySound : MonoBehaviour
{
    public IEnumerator PlaySound(GameObject soundObject)
    {
        GameObject sound = Instantiate(soundObject);

        yield return new WaitForSeconds(3);

        Destroy(sound);
    }
}