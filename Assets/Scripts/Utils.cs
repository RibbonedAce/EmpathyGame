using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    #region Variables

    #endregion

    #region Methods

    #endregion

    #region Coroutines
    // Move an object between points over given times
    public static IEnumerator MoveObject(Transform tr, Vector3[] positions, float[] times)
    {
        for (int i = 0; i < positions.Length; ++i)
        {
            Vector3 oldPos = tr.position;
            for (float t = 0f; t < times[i]; t += Time.deltaTime)
            {
                tr.position = Vector3.Lerp(oldPos, positions[i], t / times[i]);
                yield return null;
            }
            tr.position = positions[i];
        }
    }
    #endregion
}
