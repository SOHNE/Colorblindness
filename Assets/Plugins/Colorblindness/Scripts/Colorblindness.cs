using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace SOHNE.Accessibility.Colorblindness
{
    public enum ColorblindTypes
    {
        Normal = 0,
        Protanopia,
        Protanomaly,
        Deuteranopia,
        Deuteranomaly,
        Tritanopia,
        Tritanomaly,
        Achromatopsia,
        Achromatomaly,
    }

    public class Colorblindness : MonoBehaviour
    {
        public KeyCode changeKey = KeyCode.F1;

        // TODO: Clear saved settings

        Volume[] volumes;
        VolumeComponent lastFilter;

        int maxType;
        int _currentType = 0;
        int currentType
        {
            get => _currentType;

            set
            {
                if (_currentType >= maxType) _currentType = 0;
                else _currentType = value;
            }
        }

        void SearchVolumes() => volumes = GameObject.FindObjectsOfType<Volume>();

        #region Enable/Disable
        private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
        #endregion

        public static Colorblindness Instance { get; private set; }

        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded()
        {
#if !RENDERPIPELINE
            Debug.LogError("There is no type of <b>SRP</b> included in this project.");
#endif
        }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            maxType = (int) System.Enum.GetValues(typeof(ColorblindTypes)).Cast<ColorblindTypes>().Last();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SearchVolumes();

            if (volumes == null || volumes.Length <= 0) return;

            Change(-1);
        }

        void Start()
        {
            if (PlayerPrefs.HasKey("Accessibility.ColorblindType"))
                currentType = PlayerPrefs.GetInt("Accessibility.ColorblindType");
            else
                PlayerPrefs.SetInt("Accessibility.ColorblindType", 0);

            SearchVolumes();
            StartCoroutine(ApplyFilter());
        }

        void Update()
        {
            if (Input.GetKeyDown(changeKey)) InitChange();
        }

        public void Change(int filterIndex = -1)
        {
            filterIndex = filterIndex <= -1 ? PlayerPrefs.GetInt("Accessibility.ColorblindType") : filterIndex;
            currentType = Mathf.Clamp(filterIndex, 0, maxType);
            StartCoroutine(ApplyFilter());
        }

        void InitChange()
        {
            if (volumes == null) return;
#if UNITY_EDITOR
            // TODO: Use a public event system to announce the change of the activated filter
            Debug.Log($"Color changed to <b>{(ColorblindTypes)currentType} {currentType}</b>/{maxType}");
#endif

            StartCoroutine(ApplyFilter());

            PlayerPrefs.SetInt("Accessibility.ColorblindType", currentType);
            currentType++;
        }

        IEnumerator ApplyFilter()
        {
            ResourceRequest loadRequest = Resources.LoadAsync<VolumeProfile>($"Colorblind/{(ColorblindTypes)currentType}");

            do yield return null; while (!loadRequest.isDone);

            var filter = loadRequest.asset as VolumeProfile;

            if (filter == null)
            {
                Debug.LogError("An error has occured! Please, report");
                yield break;
            }

            if (lastFilter != null)
            {
                foreach (var volume in volumes)
                {
                    volume.profile.components.Remove(lastFilter);

                    foreach (var component in filter.components)
                        volume.profile.components.Add(component);
                }
            }

            lastFilter = filter.components[0];
        }
    }
}