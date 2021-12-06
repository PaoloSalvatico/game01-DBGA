using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDayAfter.Interfaces
{
    public interface ITaggable
    {
        bool HasTag(string TagName);

        bool HasTags(string[] TagNames);

    }
}