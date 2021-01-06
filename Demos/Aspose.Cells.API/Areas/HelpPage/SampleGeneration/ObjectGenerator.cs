using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Aspose.Cells.API.Areas.HelpPage.SampleGeneration
{
    /// <summary>
    /// This class will create an object of a given type and populate it with sample data.
    /// </summary>
    public class ObjectGenerator
    {
        internal const int DefaultCollectionSize = 2;
        private readonly SimpleTypeObjectGenerator SimpleObjectGenerator = new SimpleTypeObjectGenerator();

        /// <summary>
        /// Generates an object for a given type. The type needs to be public, have a public default constructor and settable public properties/fields. Currently it supports the following types:
        /// Simple types: <see cref="int"/>, <see cref="string"/>, <see cref="Enum"/>, <see cref="DateTime"/>, <see cref="Uri"/>, etc.
        /// Complex types: POCO types.
        /// Nullables: <see cref="Nullable{T}"/>.
        /// Arrays: arrays of simple types or complex types.
        /// Key value pairs: <see cref="KeyValuePair{TKey,TValue}"/>
        /// Tuples: <see cref="Tuple{T1}"/>, <see cref="Tuple{T1,T2}"/>, etc
        /// Dictionaries: <see cref="IDictionary{TKey,TValue}"/> or anything deriving from <see cref="IDictionary{TKey,TValue}"/>.
        /// Collections: <see cref="IList{T}"/>, <see cref="IEnumerable{T}"/>, <see cref="ICollection{T}"/>, <see cref="IList"/>, <see cref="IEnumerable"/>, <see cref="ICollection"/> or anything deriving from <see cref="ICollection{T}"/> or <see cref="IList"/>.
        /// Queryables: <see cref="IQueryable"/>, <see cref="IQueryable{T}"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>An object of the given type.</returns>
        public object GenerateObject(Type type)
        {
            return GenerateObject(type, new Dictionary<Type, object>());
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Here we just want to return null if anything goes wrong.")]
        private object GenerateObject(Type type, Dictionary<Type, object> createdObjectReferences)
        {
            try
            {
                if (SimpleTypeObjectGenerator.CanGenerateObject(type))
                {
                    return SimpleObjectGenerator.GenerateObject(type);
                }

                if (type.IsArray)
                {
                    return GenerateArray(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type.IsGenericType)
                {
                    return GenerateGenericType(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type == typeof(IDictionary))
                {
                    return GenerateDictionary(typeof(Hashtable), DefaultCollectionSize, createdObjectReferences);
                }

                if (typeof(IDictionary).IsAssignableFrom(type))
                {
                    return GenerateDictionary(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type == typeof(IList) ||
                    type == typeof(IEnumerable) ||
                    type == typeof(ICollection))
                {
                    return GenerateCollection(typeof(ArrayList), DefaultCollectionSize, createdObjectReferences);
                }

                if (typeof(IList).IsAssignableFrom(type))
                {
                    return GenerateCollection(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type == typeof(IQueryable))
                {
                    return GenerateQueryable(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type.IsEnum)
                {
                    return GenerateEnum(type);
                }

                if (type.IsPublic || type.IsNestedPublic)
                {
                    return GenerateComplexObject(type, createdObjectReferences);
                }
            }
            catch
            {
                // Returns null if anything fails
                return null;
            }

            return null;
        }

        private static object GenerateGenericType(Type type, int collectionSize, Dictionary<Type, object> createdObjectReferences)
        {
            var genericTypeDefinition = type.GetGenericTypeDefinition();
            if (genericTypeDefinition == typeof(Nullable<>))
            {
                return GenerateNullable(type, createdObjectReferences);
            }

            if (genericTypeDefinition == typeof(KeyValuePair<,>))
            {
                return GenerateKeyValuePair(type, createdObjectReferences);
            }

            if (IsTuple(genericTypeDefinition))
            {
                return GenerateTuple(type, createdObjectReferences);
            }

            var genericArguments = type.GetGenericArguments();
            switch (genericArguments.Length)
            {
                case 1 when genericTypeDefinition == typeof(IList<>) ||
                            genericTypeDefinition == typeof(IEnumerable<>) ||
                            genericTypeDefinition == typeof(ICollection<>):
                {
                    var collectionType = typeof(List<>).MakeGenericType(genericArguments);
                    return GenerateCollection(collectionType, collectionSize, createdObjectReferences);
                }
                case 1 when genericTypeDefinition == typeof(IQueryable<>):
                    return GenerateQueryable(type, collectionSize, createdObjectReferences);
                case 1:
                {
                    var closedCollectionType = typeof(ICollection<>).MakeGenericType(genericArguments[0]);
                    if (closedCollectionType.IsAssignableFrom(type))
                    {
                        return GenerateCollection(type, collectionSize, createdObjectReferences);
                    }

                    break;
                }
                case 2 when genericTypeDefinition == typeof(IDictionary<,>):
                {
                    var dictionaryType = typeof(Dictionary<,>).MakeGenericType(genericArguments);
                    return GenerateDictionary(dictionaryType, collectionSize, createdObjectReferences);
                }
                case 2:
                {
                    var closedDictionaryType = typeof(IDictionary<,>).MakeGenericType(genericArguments[0], genericArguments[1]);
                    if (closedDictionaryType.IsAssignableFrom(type))
                    {
                        return GenerateDictionary(type, collectionSize, createdObjectReferences);
                    }

                    break;
                }
            }

            if (type.IsPublic || type.IsNestedPublic)
            {
                return GenerateComplexObject(type, createdObjectReferences);
            }

            return null;
        }

        private static object GenerateTuple(Type type, Dictionary<Type, object> createdObjectReferences)
        {
            var genericArgs = type.GetGenericArguments();
            var parameterValues = new object[genericArgs.Length];
            var failedToCreateTuple = true;
            var objectGenerator = new ObjectGenerator();
            for (var i = 0; i < genericArgs.Length; i++)
            {
                parameterValues[i] = objectGenerator.GenerateObject(genericArgs[i], createdObjectReferences);
                failedToCreateTuple &= parameterValues[i] == null;
            }

            if (failedToCreateTuple)
            {
                return null;
            }

            var result = Activator.CreateInstance(type, parameterValues);
            return result;
        }

        private static bool IsTuple(Type genericTypeDefinition)
        {
            return genericTypeDefinition == typeof(Tuple<>) ||
                   genericTypeDefinition == typeof(Tuple<,>) ||
                   genericTypeDefinition == typeof(Tuple<,,>) ||
                   genericTypeDefinition == typeof(Tuple<,,,>) ||
                   genericTypeDefinition == typeof(Tuple<,,,,>) ||
                   genericTypeDefinition == typeof(Tuple<,,,,,>) ||
                   genericTypeDefinition == typeof(Tuple<,,,,,,>) ||
                   genericTypeDefinition == typeof(Tuple<,,,,,,,>);
        }

        private static object GenerateKeyValuePair(Type keyValuePairType, Dictionary<Type, object> createdObjectReferences)
        {
            var genericArgs = keyValuePairType.GetGenericArguments();
            var typeK = genericArgs[0];
            var typeV = genericArgs[1];
            var objectGenerator = new ObjectGenerator();
            var keyObject = objectGenerator.GenerateObject(typeK, createdObjectReferences);
            var valueObject = objectGenerator.GenerateObject(typeV, createdObjectReferences);
            if (keyObject == null && valueObject == null)
            {
                // Failed to create key and values
                return null;
            }

            var result = Activator.CreateInstance(keyValuePairType, keyObject, valueObject);
            return result;
        }

        private static object GenerateArray(Type arrayType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var type = arrayType.GetElementType();
            var result = Array.CreateInstance(type, size);
            var areAllElementsNull = true;
            var objectGenerator = new ObjectGenerator();
            for (var i = 0; i < size; i++)
            {
                var element = objectGenerator.GenerateObject(type, createdObjectReferences);
                result.SetValue(element, i);
                areAllElementsNull &= element == null;
            }

            return areAllElementsNull ? null : result;
        }

        private static object GenerateDictionary(Type dictionaryType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var typeK = typeof(object);
            var typeV = typeof(object);
            if (dictionaryType.IsGenericType)
            {
                var genericArgs = dictionaryType.GetGenericArguments();
                typeK = genericArgs[0];
                typeV = genericArgs[1];
            }

            var result = Activator.CreateInstance(dictionaryType);
            var addMethod = dictionaryType.GetMethod("Add") ?? dictionaryType.GetMethod("TryAdd");
            var containsMethod = dictionaryType.GetMethod("Contains") ?? dictionaryType.GetMethod("ContainsKey");
            var objectGenerator = new ObjectGenerator();
            for (var i = 0; i < size; i++)
            {
                var newKey = objectGenerator.GenerateObject(typeK, createdObjectReferences);
                if (newKey == null)
                {
                    // Cannot generate a valid key
                    return null;
                }

                var containsKey = (bool) containsMethod.Invoke(result, new object[] {newKey});
                if (containsKey) continue;
                var newValue = objectGenerator.GenerateObject(typeV, createdObjectReferences);
                addMethod.Invoke(result, new object[] {newKey, newValue});
            }

            return result;
        }

        private static object GenerateEnum(Type enumType)
        {
            var possibleValues = Enum.GetValues(enumType);
            return possibleValues.Length > 0 ? possibleValues.GetValue(0) : null;
        }

        private static object GenerateQueryable(Type queryableType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var isGeneric = queryableType.IsGenericType;
            object list;
            if (isGeneric)
            {
                var listType = typeof(List<>).MakeGenericType(queryableType.GetGenericArguments());
                list = GenerateCollection(listType, size, createdObjectReferences);
            }
            else
            {
                list = GenerateArray(typeof(object[]), size, createdObjectReferences);
            }

            if (list == null)
            {
                return null;
            }

            if (!isGeneric) return ((IEnumerable) list).AsQueryable();
            var argumentType = typeof(IEnumerable<>).MakeGenericType(queryableType.GetGenericArguments());
            var asQueryableMethod = typeof(Queryable).GetMethod("AsQueryable", new[] {argumentType});
            return asQueryableMethod.Invoke(null, new[] {list});

        }

        private static object GenerateCollection(Type collectionType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var type = collectionType.IsGenericType ? collectionType.GetGenericArguments()[0] : typeof(object);
            var result = Activator.CreateInstance(collectionType);
            var addMethod = collectionType.GetMethod("Add");
            var areAllElementsNull = true;
            var objectGenerator = new ObjectGenerator();
            for (var i = 0; i < size; i++)
            {
                var element = objectGenerator.GenerateObject(type, createdObjectReferences);
                addMethod.Invoke(result, new object[] {element});
                areAllElementsNull &= element == null;
            }

            return areAllElementsNull ? null : result;
        }

        private static object GenerateNullable(Type nullableType, Dictionary<Type, object> createdObjectReferences)
        {
            var type = nullableType.GetGenericArguments()[0];
            var objectGenerator = new ObjectGenerator();
            return objectGenerator.GenerateObject(type, createdObjectReferences);
        }

        private static object GenerateComplexObject(Type type, Dictionary<Type, object> createdObjectReferences)
        {
            if (createdObjectReferences.TryGetValue(type, out var result))
            {
                // The object has been created already, just return it. This will handle the circular reference case.
                return result;
            }

            if (type.IsValueType)
            {
                result = Activator.CreateInstance(type);
            }
            else
            {
                var defaultCtor = type.GetConstructor(Type.EmptyTypes);
                if (defaultCtor == null)
                {
                    // Cannot instantiate the type because it doesn't have a default constructor
                    return null;
                }

                result = defaultCtor.Invoke(new object[0]);
            }

            createdObjectReferences.Add(type, result);
            SetPublicProperties(type, result, createdObjectReferences);
            SetPublicFields(type, result, createdObjectReferences);
            return result;
        }

        private static void SetPublicProperties(Type type, object obj, Dictionary<Type, object> createdObjectReferences)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var objectGenerator = new ObjectGenerator();
            foreach (var property in properties)
            {
                if (!property.CanWrite) continue;
                var propertyValue = objectGenerator.GenerateObject(property.PropertyType, createdObjectReferences);
                property.SetValue(obj, propertyValue, null);
            }
        }

        private static void SetPublicFields(Type type, object obj, Dictionary<Type, object> createdObjectReferences)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var objectGenerator = new ObjectGenerator();
            foreach (var field in fields)
            {
                var fieldValue = objectGenerator.GenerateObject(field.FieldType, createdObjectReferences);
                field.SetValue(obj, fieldValue);
            }
        }

        private class SimpleTypeObjectGenerator
        {
            private long _index = 0;
            private static readonly Dictionary<Type, Func<long, object>> DefaultGenerators = InitializeGenerators();

            [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "These are simple type factories and cannot be split up.")]
            private static Dictionary<Type, Func<long, object>> InitializeGenerators()
            {
                return new Dictionary<Type, Func<long, object>>
                {
                    {typeof(bool), index => true},
                    {typeof(byte), index => (byte) 64},
                    {typeof(char), index => (char) 65},
                    {typeof(DateTime), index => DateTime.Now},
                    {typeof(DateTimeOffset), index => new DateTimeOffset(DateTime.Now)},
                    {typeof(DBNull), index => DBNull.Value},
                    {typeof(decimal), index => (decimal) index},
                    {typeof(double), index => (double) (index + 0.1)},
                    {typeof(Guid), index => Guid.NewGuid()},
                    {typeof(short), index => (short) (index % short.MaxValue)},
                    {typeof(int), index => (int) (index % int.MaxValue)},
                    {typeof(long), index => (long) index},
                    {typeof(object), index => new object()},
                    {typeof(sbyte), index => (sbyte) 64},
                    {typeof(float), index => (float) (index + 0.1)},
                    {
                        typeof(string), index => string.Format(CultureInfo.CurrentCulture, "sample string {0}", index)
                    },
                    {
                        typeof(TimeSpan), index => TimeSpan.FromTicks(1234567)
                    },
                    {typeof(ushort), index => (ushort) (index % ushort.MaxValue)},
                    {typeof(uint), index => (uint) (index % uint.MaxValue)},
                    {typeof(ulong), index => (ulong) index},
                    {
                        typeof(Uri), index => new Uri(string.Format(CultureInfo.CurrentCulture, "http://webapihelppage{0}.com", index))
                    },
                };
            }

            public static bool CanGenerateObject(Type type)
            {
                return DefaultGenerators.ContainsKey(type);
            }

            public object GenerateObject(Type type)
            {
                return DefaultGenerators[type](++_index);
            }
        }
    }
}