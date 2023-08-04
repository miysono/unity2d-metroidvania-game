﻿using Metroidvania.InputSystem;
using Metroidvania.SceneManagement;
using Metroidvania.UI;
using Metroidvania.UI.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Metroidvania.Serialization.Menus {
    public class SaveSlotsMenu : CanvasMenuBase, IMenuScreen {
        [SerializeField] private CanvasGroup m_canvasGroup;

        [SerializeField] private AssetReferenceSceneChannel m_sceneLevel0;

        public event System.Action OnMenuDisable;
        private SaveSlot[] _saveSlots;

        private void Start() {
            _saveSlots = GetComponentsInChildren<SaveSlot>();

            foreach (SaveSlot saveSlot in _saveSlots) {
                GameData saveUserData = DataManager.instance.dataHandler.Deserialize(saveSlot.GetUserId());
                saveSlot.SetData(saveUserData);
                saveSlot.button.onClick.AddListener(() => OnSaveSlotClick(saveSlot));
            }
        }

        public void OnSaveSlotClick(SaveSlot saveSlot) {
            DataManager.instance.ChangeSelectedUser(saveSlot.GetUserId());
            GameData slotData = saveSlot.GetData();
            if (slotData != null)
                ContinueGame(slotData);
            else
                NewGame(saveSlot.GetUserId());
        }

        private void NewGame(int userId) {
            // new game operations
            if (GameDebugger.instance.debugSerialization)
                GameDebugger.Log($"Started a new game at user {userId}");
            SceneManager.LoadScene(2);
            //SceneLoader.instance.LoadScene(m_sceneLevel0, SceneLoader.SceneTransitionData.UseGameData);
            InputReader.instance.EnableGameplayInput();
        }

        private void ContinueGame(GameData data) {
            // load game operations
            if (GameDebugger.instance.debugSerialization)
                GameDebugger.Log($"Continued a game {data.userId}");

            data.LoadCurrentScene();
        }

        public void ActiveMenu() {
            menuEnabled = true;
            m_canvasGroup.FadeGroup(true, UIUtility.TransitionTime, SetFirstSelected);
        }

        public void DesactiveMenu() {
            menuEnabled = false;
            m_canvasGroup.FadeGroup(false, UIUtility.TransitionTime, () => OnMenuDisable?.Invoke());
        }
    }
}