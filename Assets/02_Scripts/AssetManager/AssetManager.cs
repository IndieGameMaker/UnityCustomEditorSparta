using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetManager : MonoBehaviour
{
    public string assetName;

    private GameObject warriorInstance;
    // 비동기 로드 사용할 핸들
    private AsyncOperationHandle<GameObject> loadHandle;
    
    // 비동기 로드 메소드
    public void LoadAssetAsync()
    {
        // 로드 메서도
        Addressables.LoadAssetAsync<GameObject>(assetName).Completed += (handle) =>
        {
            loadHandle = handle;
            // 로드 완료된 후 로직 작성
            OnEnemyLoaded(loadHandle);
        };
    }

    private void OnEnemyLoaded(AsyncOperationHandle<GameObject> handle)     
    {
        
    }
}
