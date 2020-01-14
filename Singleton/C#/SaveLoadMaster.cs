using UnityEngine;

namespace MemoryGame.Common
{
    public class SaveLoadMaster
    {
        private const string LEVEL_PREFIX = "Level"; 
        private const string MISSION_PREFIX = "Mission";

        private static SaveLoadMaster _instance;

        public static SaveLoadMaster Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new SaveLoadMaster();
                return _instance;
            }
        }

        public void SaveFinishedMission(int missionIndex, int levelIndex)
        {
            PlayerPrefs.SetInt(MISSION_PREFIX + missionIndex + LEVEL_PREFIX + levelIndex, 1);
            PlayerPrefs.Save();
        }

        public bool WasGivenLevelOfMissionFinished(int missionIndex, int levelIndex)
        {
            return PlayerPrefs.HasKey(MISSION_PREFIX + missionIndex + LEVEL_PREFIX + levelIndex);
        }
    }
}