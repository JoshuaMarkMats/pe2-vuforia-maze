using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private Transform _ARCamera;
    [SerializeField] private GameObject _playerBall;
    [SerializeField] private GameObject _winUI;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private MazeEndPoint _endPoint;

    private GameObject _currentBall;
    private Rigidbody _currentBallRigidbody;

    private void Start()
    {
        _winUI.SetActive(false);
        _endPoint.BallReachedEnd.AddListener(() => _winUI.SetActive(true));
    }

    private void FixedUpdate()
    {
        if (_currentBallRigidbody == null)
            return;

        Vector3 gravityVector = (_ARCamera.position - _currentBall.transform.position).normalized * -9.81f;
        _currentBallRigidbody.AddForce(gravityVector, ForceMode.Acceleration);
    }

    public void OnLevelStart()
    {
        _currentBall = Instantiate(_playerBall, _spawnPoint.position, Quaternion.identity, transform);
        _currentBallRigidbody = _currentBall.GetComponent<Rigidbody>();
    }

    public void OnLevelEnd()
    {
        _winUI.SetActive(false);
        if (_currentBall != null)
            Destroy(_currentBall);
    }
}
