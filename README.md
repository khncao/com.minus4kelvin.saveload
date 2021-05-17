# Simple Save Load System

### Dependencies
- https://github.com/khncao/com.minus4kelvin.core 
  - Feedback and SceneHandler
- TextMeshPro
- Tested on Unity 2020.3.6f1+

### Todo
- Example, prefabs, tests
- Simple registry based implementation for arbitrary save-loaded monobehaviours

### SaveLoadManager
- Singleton
- Call Init with SaveLoadData<T> before use
- Holds ISaveLoadable ref for manually calling Save, Load, etc.

### SaveLoadData<T>
- T where T : GameDataBase or derivatives
- Instantiate with GameDataBase or derivative
- Pass instance to SaveLoadManager with Init method

### GameDataBase
- Base serialization class
- Overridable Serialize and Deserialize methods

### SaveDataSlot, SaveDataSlotHandler
- Simple UI for shared save/load slots, uses TMPro