using System;

namespace ReferenceManager.Helpers
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class SuppressDisplayAttribute : Attribute
    {
    }
}
