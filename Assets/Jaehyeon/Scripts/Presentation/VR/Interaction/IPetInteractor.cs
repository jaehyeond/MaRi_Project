// Assets/Jaehyeon/Scripts/Presentation/VR/Interaction/IPetInteractor.cs
using UnityEngine;

namespace Jaehyeon.Scripts.Presentation.VR.Interaction
{
    /// <summary>
    /// MaRi(강아지)와의 상호작용을 위한 인터페이스
    /// 제스처 감지 시 이 인터페이스의 메서드들이 호출됩니다.
    /// </summary>
    public interface IPetInteractor
    {
        /// <summary>
        /// "Come" 제스처 감지 시 강아지를 사용자에게 오게 합니다.
        /// </summary>
        void OnComeCommand();

        // 추후 필요한 다른 상호작용 메서드들 추가 가능
        // void OnSitCommand();
        // void OnStayCommand();
        // void OnPlayCommand();
        // 등등...
    }
}
