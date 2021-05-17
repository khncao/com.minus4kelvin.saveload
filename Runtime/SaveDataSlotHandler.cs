// using System.Collections;
// using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace m4k.SaveLoad {
public class SaveDataSlotHandler : MonoBehaviour
{
    public SaveDataSlot[] slots;
    public TMPro.TMP_Text slotsLabel;
    public GameObject confirmOverwritePanel;
    Action<int> onPressSlot;
    int overwriteSlotId;

    void Awake() {
        InitSlots();
        RefreshSlots();
    }

    void InitSlots() {
        for(int i = 0; i < slots.Length; i++) 
        {
            var button = slots[i].GetComponent<Button>();
            int id = i;
            button.onClick.AddListener( () => OnButton(id) );

            slots[i].slotId.text = i.ToString();
        }
    }

    public void RefreshSlots() 
    {
        for(int i = 0; i < slots.Length; i++) 
        {
            var fileName = string.Format("saveFile{0}", i);

            if(PlayerPrefs.HasKey(fileName)) 
            {
                slots[i].sceneName.text = PlayerPrefs.GetString(fileName + "_scene");
                // slots[i].money.text = PlayerPrefs.GetInWt(fileName + "_money").ToString();
                slots[i].playTime.text = FormatTime( PlayerPrefs.GetInt(fileName + "_time") );
            }
        }
    }

    public void OpenSaveSlots() {
        slotsLabel.text = "SAVE GAME";
        onPressSlot = SaveLoadManager.I.saveLoadable.Save;
        gameObject.SetActive(true);
    }

    public void OpenLoadSlots() {
        slotsLabel.text = "LOAD GAME";
        onPressSlot = SaveLoadManager.I.saveLoadable.Load;
        gameObject.SetActive(true);
    }

    public void ConfirmOverwrite() {
        onPressSlot(overwriteSlotId);
        confirmOverwritePanel.SetActive(false);
        // gameObject.SetActive(false);
        RefreshSlots();
    }
    bool isSaving;
    void OnButton(int id) {
        isSaving = slotsLabel.text == "SAVE GAME";
        if(isSaving) {
            if(slots[id].playTime.text != "") {
                confirmOverwritePanel.SetActive(true);
                overwriteSlotId = id;
                return;
            }
        }

        onPressSlot(id);
        // gameObject.SetActive(false);
        if(isSaving)
            RefreshSlots();
    }

    string FormatTime(int iTime)
    {			
        TimeSpan t = TimeSpan.FromSeconds( iTime );
        
        /// You can add more digits by adding more digits eg: {1:D2}:{2:D2}:{3:D2}:{4:D2} to also display milliseconds.
        return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
    }
}
}