using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

enum RobotFace {
    left,
    right
}

public delegate void Function();

public class RobotController : MonoBehaviour {


    public event Function jumpOverEvent;
    public event Function jumpFailedEvent;

    public Vector3 offset;
    public float height;

    private Transform _prev;
    public Transform prev {
        get => _prev;
        set => _prev = value;
    }
    private Transform _next;
    public Transform next {
        get => _next;
        set => _next = value;
    }
    private Transform _current;
    public Transform current {
        get => _current;
        set => _current = value;
    }
    private bool _isJumping;
    public bool isJumping {
        get => _isJumping;
    }

    private RobotFace robotFace;


    private void Awake() {
        _isJumping = false;
    }
    void Start() {

    }

    void Update() {

    }

    public void SetPosition() {
        if (current) {
            transform.position = current.position + offset;
        }

    }
    public void TurnLeft() {
        robotFace = RobotFace.left;
        Vector3 scale = transform.localScale;
        scale.x = -1;
        transform.localScale = scale;
    }

    public void TurnRight() {
        robotFace = RobotFace.right;
        Vector3 scale = transform.localScale;
        scale.x = 1;
        transform.localScale = scale;
    }

    public void Jump() {
        if (_next == null) {
            return;
        }
        _isJumping = true;

        Vector3 currentPosition = transform.position;
        Vector3 nextPosition = next.transform.position + offset;

        if (IsCanJump(currentPosition, nextPosition)) {
            JumpNext(nextPosition);
        }
        else {
            JumpFail(currentPosition);
        }

    }

    public void JumpNext(Vector3 nextPosition) {
        PlayJumpClip();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOJump(nextPosition, height, 1, 0.25f));
        sequence.AppendCallback(JumpOver);
    }

    public void JumpOver() {
        _isJumping = false;
        pathMove();

        if (jumpOverEvent != null) {
            jumpOverEvent.Invoke();
        }
    }

    private void pathMove() {
        _prev = _current;
        _current = _next;
        _next = current.GetComponent<PathController>().next.transform;

        if (_prev) {
            var pathControl = _prev.GetComponent<PathController>();
            pathControl.Down(-Screen.width);
        }
    }

    private void JumpFail(Vector3 currentPosition) {
        Vector3 targetPosition = currentPosition;
        targetPosition.y += 65;
        if (_next.position.x > currentPosition.x) {
            targetPosition.x -= 130;
        }
        else {
            targetPosition.x += 130;
        }
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOJump(targetPosition, 40, 1, 0.25f))
        .AppendCallback(PlayJumpFailed)
        .Append(transform.DOMoveY(-Screen.width, 1))
        .AppendCallback(() =>
        {
            if (jumpFailedEvent != null) {
                jumpFailedEvent.Invoke();
            }
        });
    }

    // 是否能跳上去
    bool IsCanJump(Vector3 current, Vector3 next) {
        return
            ((robotFace == RobotFace.left && next.x < current.x) ||
            (robotFace == RobotFace.right && next.x > current.x));
    }

    private float GetBottomY() {
        return -Screen.width;
    }

    void PlayJumpClip() {
        AudioManager.Instance.AudioPlay("jump");
    }

    void PlayJumpFailed() {
        AudioManager.Instance.AudioPlay("failed");
    }
}
