using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffectC : MonoBehaviour
{
    public static BossEffectC Instance { get; private set; }

    RectTransform rectTransform;

    [SerializeField] Animator animator;

    public BossAnimatinEvent BossAnimatinEvent { get; private set; }
    public event System.Action AnimatinEnd;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponentInChildren<Animator>();
        BossAnimatinEvent = GetComponentInChildren<BossAnimatinEvent>();
    }

    public void Play(string n, Vector2 position)
    {
        rectTransform.anchoredPosition = position;

        if (!animator.enabled) animator.enabled = true;

        animator.Play("none");
        animator.Play(n);
    }
}
