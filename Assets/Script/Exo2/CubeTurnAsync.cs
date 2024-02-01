using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CubeTurnAsync : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    private CancellationTokenSource _cancellationTokenSource;
    private bool _isRunning = false;

    private void Update()
    {
        if (_isRunning)
        {
            _cube.transform.Rotate(0, 45 * Time.deltaTime, 0);
        }
    }

    public void TurnCubeOnClick()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        TurnCubeAsync();
    }

    public void StopCubeOnClick()
    {
        _cancellationTokenSource.Cancel();
        _isRunning = false;
    }

    private async void TurnCubeAsync()
    {
        _isRunning = true;
        await UniTask.Delay(5000, cancellationToken: _cancellationTokenSource.Token).SuppressCancellationThrow();
        _isRunning = false;
    }
}
