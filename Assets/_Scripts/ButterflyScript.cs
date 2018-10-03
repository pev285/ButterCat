using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyScript : MonoBehaviour {

    private Transform slotToDockTo;

    public enum AnimationType
    {
        FLY,
        IDLE,
    }

    [Serializable]
    public struct AnimationPair
    {
        public AnimationType type;
        public AnimationClip clip;
    }

    [SerializeField]
    List<AnimationPair> animationsList;
    Dictionary<AnimationType, AnimationClip> animationsDict;

    Animation animationComponent;

    [SerializeField]
    private bool isFlying = false;
    public bool IsFlying
    {
        get
        {
            return isFlying;
        }
        set
        {
            if (isFlying == value)
            {
                return;
            }

            isFlying = value;
            UpdateAnimation();
        }
    }


    void UpdateAnimation()
    {
        if (isFlying)
        {
            animationComponent.Play(animationsDict[AnimationType.FLY].name);
        }
        else
        {
            animationComponent.Play(animationsDict[AnimationType.IDLE].name);
        }
    } // UpdateAnimation() ///


    private void Start()
    {
        animationsDict = new Dictionary<AnimationType, AnimationClip>();
        animationComponent = GetComponent<Animation>();

        for (int i = 0; i < animationsList.Count; i++)
        {
            animationComponent.AddClip(animationsList[i].clip, animationsList[i].clip.name);
            animationsDict[animationsList[i].type] = animationsList[i].clip;
        }

        UpdateAnimation();
    }


    public void SetSlotToDockTo(Transform tr)
    {
        slotToDockTo = tr;
    }

    private void Update()
    {
        if (slotToDockTo != null)
        {
            transform.position = slotToDockTo.position;
            transform.rotation = slotToDockTo.rotation;
        }
    } // Update() ///

}
