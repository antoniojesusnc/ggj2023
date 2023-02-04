using System.Collections;
using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer _image;
    
    private EnemyEncounterConfiguration _enemyEncounterConfig;

    private bool _following;

    private Coroutine _countDownCoroutine;
    
    private void Awake()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
    }

    public void SetEncounter(EnemyEncounterConfiguration enemyEncounterConfig)
    {
        _enemyEncounterConfig = enemyEncounterConfig;
        _image.sprite = enemyEncounterConfig.Image;
        StartFade();
        StartFollow();
    }

    private void StartFade()
    {
        _image.DOFade(1, _enemyEncounterConfig.EncounterDuration);
    }
    
    private void StartFollow()
    {
        _following = true;
        StartCoroutine(FollowPlayerCo());
        _countDownCoroutine = StartCoroutine(StartCountDownFollowCo());
    }

    private IEnumerator StartCountDownFollowCo()
    {
        yield return new WaitForSeconds(_enemyEncounterConfig.ApproximationTime);
        EndHuntLeavePlayer(_enemyEncounterConfig.LeavingEncounterDuration);
    }
    
    private IEnumerator FollowPlayerCo()
    {
        var character = GameManager.Instance.Character;

        while (_following)
        {
            Vector3 direction = (character.transform.position - transform.position).normalized;
            transform.position += direction * (_enemyEncounterConfig.Speed * Time.deltaTime);

            if (CheckIfIsPlayerCaptured())
            {
                StartShaking();
            }

            yield return 0;
        }
    }

    private bool CheckIfIsPlayerCaptured()
    {
        var character = GameManager.Instance.Character;

        Debug.Log($"Distance: {Vector3.Distance(character.transform.position, transform.position)}, detectDistacne: {_enemyEncounterConfig.DetectDistance*0.5f}");
        return Vector3.Distance(character.transform.position, transform.position) < _enemyEncounterConfig.DetectDistance*0.5f;
    }

    private void StartShaking()
    {
        StopCoroutine(_countDownCoroutine);
        _following = false;

        GameManager.Instance.BeginShaker(_enemyEncounterConfig);
        StartCoroutine(OnFinishShake());
    }

    private IEnumerator OnFinishShake()
    {
        yield return new WaitForSeconds(_enemyEncounterConfig.EncounterDuration);
        GameManager.Instance.FinishShaker();
        LeavePlayer();
    }

    private void LeavePlayer()
    {
        if (GameManager.Instance.IsGameOver)
        {
            Destroy(gameObject);
            return;
        }
        var direction = Random.insideUnitCircle;
        transform.DOMove(new Vector3(direction.x, transform.position.y, direction.y),
                         _enemyEncounterConfig.LeavingTime);
        EndHuntLeavePlayer(_enemyEncounterConfig.LeavingTime);
    }
    
    private void EndHuntLeavePlayer(float leaveTime)
    {
        _image.DOFade( 0, leaveTime).onComplete += () => Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if (_enemyEncounterConfig != null)
        {
            Gizmos.DrawSphere(transform.position, _enemyEncounterConfig.DetectDistance-0.5f);
        }
    }
}
