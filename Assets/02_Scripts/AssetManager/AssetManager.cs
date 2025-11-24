using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetManager : MonoBehaviour
{
    // 어드레서블 이름
    public string assetName = "EnemyRed";
    
    // 생성된 전사 인스턴스
    private GameObject warriorInstance;
    
    // 비동기 핸들
    private AsyncOperationHandle<GameObject> loadHandle;
    
    // 비동기 로드
    public void LoadAssetAsync(string assetName)
    {
        Addressables.LoadAssetAsync<GameObject>(assetName).Completed += (handle =>
        {
            loadHandle = handle;
            // 로드 완료시 호출
            OnEnemyLoaded(loadHandle);
        });
    }
    
    private void OnEnemyLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            // 새 인스턴스 생성
            warriorInstance = Instantiate(handle.Result, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("에셋 로드 실패 :" + assetName);
        }
    }

    public void UnloadAssetAsync()
    {
        // 어드레서블 해제
        Addressables.Release(loadHandle);
        // 인스턴스 제거
        DestroyImmediate(warriorInstance);
    }
}
