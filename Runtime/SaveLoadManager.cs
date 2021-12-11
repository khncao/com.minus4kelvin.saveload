using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// Singleton access to common save/load functions and saveLoadable. Save data slots and metadata are stored in PlayerPrefs.
/// </summary>
namespace m4k.SaveLoad {
public class SaveLoadManager : Singleton<SaveLoadManager> {
    // Static survive reload of persistent scene and flag index of scene to load
    public static int loadIndex = -1;
    public Action onSaveDone, onLoadDone, onQuickSave, onQuickLoad;
    public ISaveLoadable saveLoadable;

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
}