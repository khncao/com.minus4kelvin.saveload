using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// SaveLoadManager is a generic game data serialization base class. Constructed with derivative of GameDataBase. System.Action callbacks on save and load.  Instantiate and call methods through a manager class reference. Save data slots and metadata are stored in PlayerPrefs.
/// </summary>
namespace m4k.SaveLoad {
public class SaveLoadManager : Singleton<SaveLoadManager> {
    public static int loadIndex = -1;
    public Action onSaveDone, onLoadDone, onQuickSave, onQuickLoad;
    public ISaveLoadable saveLoadable;

    // protected override void Awake() {
    //     base.Awake();
    //     if(m_ShuttingDown) return;
    // }
    public void Init(ISaveLoadable saveLoadable) {
        this.saveLoadable = saveLoadable;
        if(loadIndex >= 0) {
            StartCoroutine(DelayLoad(loadIndex));
            loadIndex = -1;
        }
    }
    IEnumerator DelayLoad(int index) {
        yield return new WaitForEndOfFrame();
        saveLoadable.Load(index);
    }
}
public interface ISaveLoadable {
    void Save(int index);
    void Load(int index);
    void QuickSave();
    void QuickLoad();
    void Continue();
}

// public interface IStateSerializable
// {
//     void Serialize(ref GameDataWriter writer);
//     void Deserialize(ref GameDataReader reader);
// }

}