// Assets/Jaehyeon/Scripts/Presentation/VR/Gestures/HandPoseLibrary.cs
using UnityEngine;

namespace Jaehyeon.Scripts.Presentation.VR.Gestures
{
    /// <summary>
    /// 좌/우/양손 구분용 열거형
    /// </summary>
    public enum Handedness
    {
        Left,
        Right,
        Both
    }

    /// <summary>
    /// 한 손 포즈 데이터: 이름, 좌/우/양손, 손가락 굽힘 강도[Thumb,Index,Middle,Ring,Pinky]
    /// </summary>
    [System.Serializable]
    public class HandPose
    {
        public string name;
        public Handedness hand;
        public float[] fingerCurls = new float[5];
    }

    /// <summary>
    /// 에셋 메뉴(Assets ▶ Create ▶ Gestures ▶ HandPoseLibrary)에서 생성 가능한
    /// 손 포즈 라이브러리(ScriptableObject)
    /// </summary>
    [CreateAssetMenu(menuName = "Gestures/HandPoseLibrary")]
    public class HandPoseLibrary : ScriptableObject
    {
        [Tooltip("등록된 모든 포즈")]
        public HandPose[] poses;
    }
}
