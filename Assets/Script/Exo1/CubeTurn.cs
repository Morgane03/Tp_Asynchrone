﻿using System.Collections;
using UnityEngine;

public class CubeTurn : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    private Coroutine _coroutine;

    private IEnumerator TurnCube()
    {
        float elapsedTime = 0f;
        while (elapsedTime <= 5f)
        {
            _cube.transform.Rotate(0, 45 * Time.deltaTime, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void TurnCubeOnClick()
    {
        _coroutine = StartCoroutine(TurnCube());
    }

    public void StopCubeOnClick()
    {
        StopCoroutine(_coroutine);
    }
}
