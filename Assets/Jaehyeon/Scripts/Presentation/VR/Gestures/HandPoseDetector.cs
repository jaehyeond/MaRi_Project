// Assets/Jaehyeon/Scripts/Presentation/VR/Gestures/HandPoseDetector.cs
using UnityEngine;
using Oculus.Interaction;                              // OVRHand
using Jaehyeon.Scripts.Presentation.VR.Gestures;      // HandPoseLibrary, Handedness
using Jaehyeon.Scripts.Presentation.VR.Interaction;   // MariInteractor

namespace Jaehyeon.Scripts.Presentation.VR.Gestures
{
    /// <summary>
    /// 매 프레임 손의 핑거 핀치(굽힘) 값을 읽어서
    /// HandPoseLibrary에 등록된 포즈와 매칭되면
    /// MariInteractor.OnComeCommand() 같은 콜백을 호출합니다.
    /// </summary>
    public class HandPoseDetector : MonoBehaviour
    {
        [Header("Oculus Hand References")]
        [Tooltip("LeftHandAnchor 안에 붙어 있는 OVRHand 컴포넌트")]
        public OVRHand leftOvrHand;

        [Tooltip("RightHandAnchor 안에 붙어 있는 OVRHand 컴포넌트")]
        public OVRHand rightOvrHand;

        [Header("Hand Pose Library")]
        [Tooltip("Assets ▶ … ▶ HandPoseLibrary 에셋")]
        public HandPoseLibrary library;

        [Header("Detection Settings")]
        [Tooltip("포즈 비교 시 손가락 굽힘 차 허용 값")]
        [Range(0f, 1f)]
        public float threshold = 0.1f;

        void Update()
        {
            if (leftOvrHand != null && leftOvrHand.IsTracked)
                CheckHand(leftOvrHand, Handedness.Left);

            if (rightOvrHand != null && rightOvrHand.IsTracked)
                CheckHand(rightOvrHand, Handedness.Right);
        }

        /// <summary>
        /// 한 손에 대해 5개 손가락 핀치 값을 읽고
        /// 라이브러리의 모든 포즈와 비교한다.
        /// 매칭되면 MariInteractor.Instance.OnComeCommand() 호출
        /// </summary>
        void CheckHand(OVRHand ovrHand, Handedness handedness)
        {
            // 0:Thumb, 1:Index, 2:Middle, 3:Ring, 4:Pinky
            float[] curls = new float[5];
            curls[0] = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb);
            curls[1] = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
            curls[2] = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);
            curls[3] = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
            curls[4] = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky);

            // 라이브러리 등록 포즈 전부 순회
            foreach (var pose in library.poses)
            {
                // 좌/우 손 맞는 포즈만 검사
                if (pose.hand != handedness) continue;

                if (IsPoseMatch(pose, curls))
                {
                    // 예시: "Come" 포즈 감지 시 호출
                    MariInteractor.Instance.OnComeCommand();
                    break;
                }
            }
        }

        /// <summary>
        /// 현재 읽은 curls 와 등록된 pose.fingerCurls 의 절대 차이가
        /// threshold 이하이면 true
        /// </summary>
        bool IsPoseMatch(HandPose pose, float[] currentCurls)
        {
            if (pose.fingerCurls == null || currentCurls == null) return false;
            for (int i = 0; i < 5; i++)
            {
                if (Mathf.Abs(currentCurls[i] - pose.fingerCurls[i]) > threshold)
                    return false;
            }
            return true;
        }
    }
}
