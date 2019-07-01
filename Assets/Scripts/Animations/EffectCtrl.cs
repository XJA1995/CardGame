using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCtrl : MonoBehaviour
{

    public static EffectCtrl Instance { get; private set; }

    RectTransform rectTransform;

    [SerializeField] Animator animator;

    public AnimatinEvent AnimatinEvent { get; private set; }
    public event System.Action AnimatinEnd;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponentInChildren<Animator>();
        AnimatinEvent = GetComponentInChildren<AnimatinEvent>();
    }


    public void Play(string n, Vector2 position)//播放控制函数
    {
        rectTransform.anchoredPosition = position;

        if (!animator.enabled) animator.enabled = true;
        animator.Play(n);
    }


    /*IEnumerator Check(string n,System.Action call)
    {
        while (true)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

            if(info.IsName(n) && info.normalizedTime > 0.95f)
            {
                call?.Invoke();
                yield break;
            }
        }
    }


    void End()
    {
        AnimatinEvent.finish -= End;
        animator.enabled = false;
    }*/
}
