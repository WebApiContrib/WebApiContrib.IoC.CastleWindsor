namespace WebApiContrib.IoC.CastleWindsor
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DependencyAttribute : Attribute
    {
    }
}