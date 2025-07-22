<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f

public class SlingShotHandler : MonoBehaviour
{
    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;

<<<<<<< HEAD
    [Header("Tranform References")]
=======
    [Header("Transform References")]
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _rightStartPosition;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;
<<<<<<< HEAD
=======
    [SerializeField] private Transform _elasticTransform;
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f

    [Header("Slingshot Stats")]
    [SerializeField] private float _maxDistance = 3.5f;
    [SerializeField] private float _shotForce = 5f;
    [SerializeField] private float _timeBetweenBirdRespawns = 2f;
<<<<<<< HEAD

    [Header("Scripts")]
    [SerializeField] private SlingShotArea _slingShotArea;

    [Header("Bird")]
    [SerializeField] private YellowBird _yellowBirdPrefab;
    [SerializeField] private float _angieBirdPositionOffset = 2f;

=======
    [SerializeField] private float _elasticDivider = 1.2f;
    [SerializeField] private AnimationCurve _elasticCurve;
    [SerializeField] private float _maxAnimationTime = 1f;

    [Header("Scripts")]
    [SerializeField] private SlingShotArea _slingShotArea;
    [SerializeField] private CameraManager _cameraManager;

    [Header("Bird")]
    [SerializeField] private AngieBird _angryBirdPrefab;
    [SerializeField] private float _angryBirdPositionOffset = 2f;

    [Header("Sound")]
    [SerializeField] private AudioClip _elasticPulledClip;
    [SerializeField] private AudioClip[] _elasticReleasedClip;
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f

    private Vector2 _slingShotLinesPosition;
    private Vector2 _direction;
    private Vector2 _directionNormalized;

    private bool _clickedWithinArea;
    private bool _birdOnSlingshot;

<<<<<<< HEAD
    private YellowBird _spawnedYellowBird;

    private void Awake()
    {
=======
    private AngieBird _spawnAngieBird;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
        _leftLineRenderer.enabled = false;
        _rightLineRenderer.enabled = false;

        SpawnAngieBird();
    }

<<<<<<< HEAD


    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame && _slingShotArea.IsWithinSlingshotArea())
        {
            _clickedWithinArea = true;
        }

        if (Mouse.current.leftButton.isPressed && _clickedWithinArea && _birdOnSlingshot)
        {
            DrawSlingShot();
            PositionAndRotateAngieBird();

        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && _birdOnSlingshot)
=======
    private void Update()
    {
        if (InputManager.WasLeftMousebuttonPressed && _slingShotArea.IsWithinSlingshotArea())
        {
            _clickedWithinArea = true;

            if (_birdOnSlingshot)
            {
                SoundManager.instance.PlayClip(_elasticPulledClip, _audioSource);
                _cameraManager.SwitchToFollowCam(_spawnAngieBird.transform);
            }
        }

        if (InputManager.IsLeftMousePressed && _clickedWithinArea && _birdOnSlingshot)
        {
            DrawSlingShot();
            PositionAndRotationAngieBird();
        }

        if (InputManager.WasLeftMousebuttonReleased && _birdOnSlingshot && _clickedWithinArea)
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
        {
            if (GameManager.instance.HasEnoughShots())
            {
                _clickedWithinArea = false;
                _birdOnSlingshot = false;

<<<<<<< HEAD
                _spawnedYellowBird.LaunchBird(_direction, _shotForce);
                GameManager.instance.UseShot();
                SetLines(_centerPosition.position);

                if(GameManager.instance.HasEnoughShots())
                {
                    StartCoroutine(SpawnAngieBirdAfterTime());
                }
=======
                _spawnAngieBird.LaunchBird(_direction, _shotForce);

                SoundManager.instance.PlayRandomClip(_elasticReleasedClip, _audioSource);

                GameManager.instance.UseShot();
                AnimateSlingshot();
            

                if (GameManager.instance.HasEnoughShots())
                {
                    StartCoroutine(SpawnAngieBirdAfterTime());
                }
                else
                {
 
                    GameManager.instance.CheckForLastShot();
                }
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
            }
        }
    }

    #region SlingShot Methods
<<<<<<< HEAD

    private void DrawSlingShot()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
=======
    private void DrawSlingShot()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(InputManager.MousePosition);
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f

        _slingShotLinesPosition = _centerPosition.position + Vector3.ClampMagnitude(touchPosition - _centerPosition.position, _maxDistance);

        SetLines(_slingShotLinesPosition);

        _direction = (Vector2)_centerPosition.position - _slingShotLinesPosition;
        _directionNormalized = _direction.normalized;
    }

<<<<<<< HEAD

=======
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
    private void SetLines(Vector2 position)
    {
        if (!_leftLineRenderer.enabled && !_rightLineRenderer.enabled)
        {
            _leftLineRenderer.enabled = true;
            _rightLineRenderer.enabled = true;
        }

        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position);
<<<<<<< HEAD

    }

    #endregion

    #region Angie Bird Methods

    private void SpawnAngieBird()
    {
        SetLines(_idlePosition.position);

        Vector2 dir = (_centerPosition.position - _idlePosition.position).normalized;
        Vector2 spawnPosition = (Vector2)_idlePosition.position + dir *_angieBirdPositionOffset;

        _spawnedYellowBird = Instantiate(_yellowBirdPrefab, spawnPosition, Quaternion.identity);
        _spawnedYellowBird.transform.right = dir;
=======
    }
    #endregion

    #region Angie Bird Methods
    private void SpawnAngieBird()
    {
        _elasticTransform.DOComplete();
        SetLines(_idlePosition.position);

        Vector2 dir = (_centerPosition.position - _idlePosition.position).normalized;
        Vector2 spawnPosition = (Vector2)_idlePosition.position + dir * _angryBirdPositionOffset;

        _spawnAngieBird = (AngieBird)Instantiate(_angryBirdPrefab, spawnPosition, Quaternion.identity);
        _spawnAngieBird.transform.right = dir;
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f

        _birdOnSlingshot = true;
    }

<<<<<<< HEAD
    private void PositionAndRotateAngieBird()
    {
        _spawnedYellowBird.transform.position = _slingShotLinesPosition + _directionNormalized * _angieBirdPositionOffset;
        _spawnedYellowBird.transform.right = _directionNormalized;
    }
    private IEnumerator SpawnAngieBirdAfterTime()
    {
        yield return new WaitForSeconds(_timeBetweenBirdRespawns);
        SpawnAngieBird();
=======
    private void PositionAndRotationAngieBird()
    {
        _spawnAngieBird.transform.position = _slingShotLinesPosition + _directionNormalized * _angryBirdPositionOffset;
        _spawnAngieBird.transform.right = _directionNormalized;
    }

    private IEnumerator SpawnAngieBirdAfterTime()
    {
        yield return new WaitForSeconds(_timeBetweenBirdRespawns);

        SpawnAngieBird();

        _cameraManager.SwitchToIdleCam();
    }
    #endregion
    #region Animate Slingshot
    private void AnimateSlingshot()
    {
        _elasticTransform.position = _leftLineRenderer.GetPosition(0);

        float dist = Vector2.Distance(_elasticTransform.position, _centerPosition.position);

        float time = dist / _elasticDivider ;

        _elasticTransform.DOMove(_centerPosition.position, time).SetEase(_elasticCurve);
        StartCoroutine(AnimteSlingshotLines(_elasticTransform, time));
    }

    private IEnumerator AnimteSlingshotLines(Transform trans, float time)
    {
        float elapsedTime = 0f;
        while (elapsedTime < time && elapsedTime < _maxAnimationTime)
        {
            elapsedTime += Time.deltaTime;


            SetLines(trans.position);

            yield return null;
        }
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
    }

    #endregion
}
<<<<<<< HEAD
 
=======
>>>>>>> 62f327a9b07083f64a674de754fdea93df7a279f
