// Reid Reininger
// 11512839
namespace Cpts321
{
    using NUnit.Framework;
    using System.Reflection;

    /// <summary>
    /// Functions used across testing suites.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Get PropertyInfo.
        /// </summary>
        /// <typeparam name="T">Class containing property.</typeparam>
        /// <param name="property">Property identifier.</param>
        /// <returns>Property info.</returns>
        public static PropertyInfo GetProperty<T>(string property)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                Assert.Fail("Property cannot be null or whitespace");
            }

            var propertyInfo = typeof(T).GetProperty(property, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                Assert.Fail($"Could not find property {property}");
            }

            return propertyInfo;
        }

        /// <summary>
        /// Get MethodInfo.
        /// </summary>
        /// <typeparam name="T">Class containing method.</typeparam>
        /// <param name="method">Method identifier.</param>
        /// <returns>Method info.</returns>
        public static MethodInfo GetMethod<T>(string method)
        {
            if (string.IsNullOrWhiteSpace(method))
            {
                Assert.Fail("Method cannot be null or whitespace");
            }

            var methodInfo = typeof(T).GetMethod(method, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (methodInfo == null)
            {
                Assert.Fail($"Could not find method {method}");
            }

            return methodInfo;
        }

        /// <summary>
        /// Get FieldInfo.
        /// </summary>
        /// <typeparam name="T">Class containing field.</typeparam>
        /// <param name="field">Field identifier.</param>
        /// <returns>Field info.</returns>
        public static FieldInfo GetField<T>(string field)
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                Assert.Fail("Field cannot be null or whitespace");
            }

            var fieldInfo = typeof(T).GetField(field, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            if (fieldInfo == null)
            {
                Assert.Fail($"Could not find field {field}");
            }

            return fieldInfo;
        }
    }
}
