using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButterCat.Player.Butterfly
{


	public class ButterflyAnimationController : MonoBehaviour
    {

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

        public void UpdateAnimation(bool isFlying)
        {
            if (animationsDict == null)
            {
                animationsDict = new Dictionary<AnimationType, AnimationClip>();
            }
            if (animationComponent == null)
            {
                Debug.Log("number of animation components = " + GetComponentsInChildren<Animation>().Length);
                animationComponent = GetComponentInChildren<Animation>();
                //animationComponent = GetComponent<Animation>();
            }


            if (animationComponent != null)
            {
                if (animationsDict.Count == 0)
                {
                    for (int i = 0; i < animationsList.Count; i++)
                    {
                        animationComponent.AddClip(animationsList[i].clip, animationsList[i].clip.name);
                        animationsDict[animationsList[i].type] = animationsList[i].clip;
                    }
                }

                if (isFlying)
                {
                    animationComponent.Play(animationsDict[AnimationType.FLY].name);
                }
                else
                {
                    animationComponent.Play(animationsDict[AnimationType.IDLE].name);
                }
            }
        } // UpdateAnimation() ///





    } // end of class //

} // end of namespace //