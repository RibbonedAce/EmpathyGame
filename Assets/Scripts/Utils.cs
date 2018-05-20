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
    // Move an object to a point over a given time
    public static IEnumerator MoveObject(Transform tr, Vector3 position, float time)
    {
        Vector3 oldPos = tr.position;
        for (float t = 0f; t < time; t += Time.deltaTime)
        {
            tr.position = Vector3.Lerp(oldPos, position, t / time);
            yield return null;
            if (tr == null)
            {
                yield break;
            }
        }
        tr.position = position;
    }

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

    // Move an object by an amount over a given time
    public static IEnumerator MoveObjectBy(Transform tr, Vector3 movement, float time)
    {
        Vector3 oldPos = tr.position;
        Vector3 newPos = tr.position + movement;
        for (float t = 0f; t < time; t += Time.deltaTime)
        {
            tr.position = Vector3.Lerp(oldPos, newPos, t / time);
            yield return null;
        }
        tr.position = newPos;
    }

    // Move an object between points over given times
    public static IEnumerator MoveObjectBy(Transform tr, Vector3[] movements, float[] times)
    {
        for (int i = 0; i < movements.Length; ++i)
        {
            Vector3 oldPos = tr.position;
            Vector3 newPos = tr.position + movements[i];
            for (float t = 0f; t < times[i]; t += Time.deltaTime)
            {
                tr.position = Vector3.Lerp(oldPos, newPos, t / times[i]);
                yield return null;
            }
            tr.position = newPos;
        }
    }

    // Split up a number into some more randomly
    public static int[] SplitNumber(int num, int size)
    {
        int[] result = new int[size];
        List<int> splits = new List<int>(size - 1);
        for (int i = 0; i < size - 1; ++i)
        {
            splits.Add(Random.Range(0, num));
        }
        splits.Sort();
        result[0] = splits[0];
        for (int i = 1; i < size - 1; ++i)
        {
            result[i] = splits[i] - splits[i - 1];
        }
        result[size - 1] = num - splits[size - 2];
        return result;
    }
    #endregion
}
