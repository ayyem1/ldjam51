using UnityEngine;

/// <summary>
/// Note that this will not prevent a non singleton constructor such as 'T myT = new T()'
/// To prevent that, add 'protected T() {}' to your singleton class that derives from this.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object singletonLock = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance {typeof(T)} already destroyed on application quit. Won't create again and will return null.");
                return null;
            }

            lock (singletonLock)
            {
                if (instance != null)
                {
                    return instance;
                }

                instance = null;
                var instances = FindObjectsOfType(typeof(T));
                if (instances.Length > 1)
                {
                    Debug.LogError("[Singleton] Something went really wrong. There should never be more than 1 singleton! Reopening the scene might fix it.");
                    return instance;
                }
                else if (instances.Length == 1)
                {
                    instance = (T)instances[0];
                }
                else
                {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<T>();
                    singleton.name = $"(singleton) {typeof(T).ToString()}";
                }

                return instance;
            }
        }
    }

    private static bool IsDontDestroyOnLoad()
    {
        if (instance == null)
        {
            return false;
        }

        if ((instance.gameObject.hideFlags & HideFlags.DontSave) == HideFlags.DontSave)
        {
            return true;
        }

        return false;
    }

    public void OnDestroy()
    {
        /**
         * When Unity quits, it destroys objects in a random order. 
         * In principle a Singleton is only destroyed when application quits.
         * If any script calls Instance after it has been destroyed, it will create a buggy ghost object.
         * This prevents that from happening.
         */
        if (!IsDontDestroyOnLoad())
        {
            applicationIsQuitting = true;
        }
    }
}
