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

        public static event System.Action<ColorblindTypes> OnChangingType;

        void SearchVolumes() => volumes = GameObject.FindObjectsOfType<Volume>();

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
#if UNITY_EDITOR
            OnChangingType += (type) =>
            {
                Debug.Log($"Color changed to <b>{type} {(int)type}</b>/{maxType}");
            };
#endif
        }

        public static Colorblindness Instance { get; private set; }

#if !RENDERPIPELINE && UNITY_EDITOR
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded() => Debug.LogError("There is no type of <b>SRP</b> included in this project.");
#endif

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

        private void Start()
        {
            if (PlayerPrefs.HasKey("Accessibility.ColorblindType"))
                currentType = PlayerPrefs.GetInt("Accessibility.ColorblindType");
            else
                PlayerPrefs.SetInt("Accessibility.ColorblindType", 0);

            DoLoad();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode _)
        {
            SearchVolumes();

            if (volumes == null || volumes.Length <= 0) return;

            DoLoad();
        }

        void Update()
        {
            if (Input.GetKeyDown(changeKey)) InitChange();
        }

        public void Change(int filterIndex = -1)
        {
            filterIndex = filterIndex <= -1 ? PlayerPrefs.GetInt("Accessibility.ColorblindType") : filterIndex;
            currentType = Mathf.Clamp(filterIndex, 0, maxType);
            DoLoad();
        }

        public void Change(ColorblindTypes type)
        {
            currentType = (int) type;
            DoLoad();
        }

        void InitChange()
        {
            if (volumes == null) return;

            OnChangingType?.Invoke((ColorblindTypes) currentType);

            // apply filter
            DoLoad();

            PlayerPrefs.SetInt("Accessibility.ColorblindType", currentType++);
        }

        void DoLoad()
        {
            ResourceRequest loadRequest = Resources.LoadAsync<VolumeProfile>($"Colorblind/{(ColorblindTypes)currentType}");
            loadRequest.completed += (_) =>
            {
                var filter = loadRequest.asset as VolumeProfile;

                if (filter == null)
                {
                    Debug.LogError("An error has occured! Please, report");
                    return;
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
            };

        }
    }
}