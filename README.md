# Simple Save Load System

### SaveLoadManager
- Singleton, holds UI refs
- Call Init with SaveLoadData<T> before use
- Holds ISaveLoadable ref for manually calling Save, Load, etc.

### SaveLoadData<T>
- T where T : GameDataBase or derivatives
- Instantiate with GameDataBase or derivative
- Pass instance to SaveLoadManager with Init method

### GameDataBase
- Base serialization class
- Overridable Serialize and Deserialize methods