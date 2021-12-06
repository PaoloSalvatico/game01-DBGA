using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.Interfaces;

namespace TheDayAfter.Enemy
    { }

public class PhantomEnemy : MonoBehaviour, ITaggable
{
    bool _inPhantomMode;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetPhantomMode", 5);
    }

    // Update is called once per frame
    void SetPhantomMode()
    {
        var percent = Random.Range(0, 2);
        _inPhantomMode = (percent < 1);

        Invoke("SetPhantomMode", 5);
    }

    public bool HasTag(string TagName)
    {
        if (_inPhantomMode) return false;

        return gameObject.CompareTag(TagName);
    }

    public bool HasTags(string[] TagNames)
    {
        throw new System.NotImplementedException();
    }
}
