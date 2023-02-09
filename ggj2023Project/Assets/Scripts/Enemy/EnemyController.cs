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
        
        AudioManager.Instance.PlaySound(AudioTypes.Fantasma,transform);
    }

    private IEnumerator StartCountDownFollowCo()
    {
        yield return new WaitForSeconds(_enemyEncounterConfig.ApproximationTime);
        EndHuntLeavePlayer(_enemyEncounterConfig.LeavingEncounterDuration);
    }
    
    private IEnumerator FollowPlayerCo()
    {
        while (_following)
        {
            Vector3 direction = (GameManager.Instance.Character.HeadTransform.position - transform.position).normalized;
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

        return Vector3.Distance(GameManager.Instance.Character.HeadTransform.position, transform.position) < _enemyEncounterConfig.DetectDistance*0.5f;
    }

    private void StartShaking()
    {
        StopCoroutine(_countDownCoroutine);
        _following = false;

        GameManager.Instance.BeginShaker(_enemyEncounterConfig);
        StartCoroutine(OnFinishShake());

        StartCoroutine(ScreamingRandomCo());
    }

    private IEnumerator ScreamingRandomCo()
    {
        while (GameManager.Instance.IsShaking)
        {
            var audioScream = GetAudioScream();
            AudioManager.Instance.PlaySound(audioScream,transform);
            float duration = AudioManager.Instance.GetDuration(audioScream);
            yield return new WaitForSeconds(duration+_enemyEncounterConfig.ScreamingSoundDelay);
        }
    }

    private AudioTypes GetAudioScream()
    {
        var value = UnityEngine.Random.value;
        if (value < 0.33f)
        {
            return AudioTypes.Grito01;
        }
        else
        if (value < 0.66f)
        {
            return AudioTypes.Grito02;
        }
        else
        {
            return AudioTypes.Grito03;
        }
    }

    private IEnumerator OnFinishShake()
    {
        yield return new WaitForSeconds(_enemyEncounterConfig.EncounterDuration);
        GameManager.Instance.FinishShaker();
        LeavePlayer();
        
        AudioManager.Instance.FinishAudio(AudioTypes.Grito01);
        AudioManager.Instance.FinishAudio(AudioTypes.Grito02);
        AudioManager.Instance.FinishAudio(AudioTypes.Grito03);
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

        AudioManager.Instance.FinishAudio(AudioTypes.Fantasma);
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
