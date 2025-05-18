using UnityEngine;
using Jaehyeon.Scripts.Presentation.VR.Interaction;

namespace Jaehyeon.Scripts.Presentation.VR.Interaction
{
    /// <summary>
    /// Mari(강아지) 상호작용을 처리하는 컴포넌트
    /// 씬에 하나만 존재해야 하는 싱글톤으로 구현됨
    /// </summary>
    public class MariInteractor : MonoBehaviour, IPetInteractor
    {
        // 씬에 하나만 있게 싱글턴으로 사용
        public static MariInteractor Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            else Instance = this;
        }

        // IPetInteractor 구현
        public void OnComeCommand()
        {
            // TODO: 강아지 이리 오게 애니메이션/네비게이션 호출
            Debug.Log("Come 명령 감지됨! MaRi가 이리 옵니다.");
            // 예) GetComponent<NavMeshAgent>().SetDestination(player.position);
        }
    }
}
