using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Aspose.Cells.API.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Generates model descriptions for given types.
    /// </summary>
    public class ModelDescriptionGenerator
    {
        // Modify this to support more data annotation attributes.
        private readonly IDictionary<Type, Func<object, string>> AnnotationTextGenerator = new Dictionary<Type, Func<object, string>>
        {
            {typeof(RequiredAttribute), a => "Required"},
            {
                typeof(RangeAttribute), a =>
                {
                    var range = (RangeAttribute) a;
                    return string.Format(CultureInfo.CurrentCulture, "Range: inclusive between {0} and {1}", range.Minimum, range.Maximum);
                }
            },
            {
                typeof(MaxLengthAttribute), a =>
                {
                    var maxLength = (MaxLengthAttribute) a;
                    return string.Format(CultureInfo.CurrentCulture, "Max length: {0}", maxLength.Length);
                }
            },
            {
                typeof(MinLengthAttribute), a =>
                {
                    var minLength = (MinLengthAttribute) a;
                    return string.Format(CultureInfo.CurrentCulture, "Min length: {0}", minLength.Length);
                }
            },
            {
                typeof(StringLengthAttribute), a =>
                {
                    var strLength = (StringLengthAttribute) a;
                    return string.Format(CultureInfo.CurrentCulture, "String length: inclusive between {0} and {1}", strLength.MinimumLength, strLength.MaximumLength);
                }
            },
            {
                typeof(DataTypeAttribute), a =>
                {
                    var dataType = (DataTypeAttribute) a;
                    return string.Format(CultureInfo.CurrentCulture, "Data type: {0}", dataType.CustomDataType ?? dataType.DataType.ToString());
                }
            },
            {
                typeof(RegularExpressionAttribute), a =>
                {
                    var regularExpression = (RegularExpressionAttribute) a;
                    return string.Format(CultureInfo.CurrentCulture, "Matching regular expression pattern: {0}", regularExpression.Pattern);
                }
            },
        };

        // Modify this to add more default documentations.
        private readonly IDictionary<Type, string> DefaultTypeDocumentation = new Dictionary<Type, string>
        {
            {typeof(short), "integer"},
            {typeof(int), "integer"},
            {typeof(long), "integer"},
            {typeof(ushort), "unsigned integer"},
            {typeof(uint), "unsigned integer"},
            {typeof(ulong), "unsigned integer"},
            {typeof(byte), "byte"},
            {typeof(char), "character"},
            {typeof(sbyte), "signed byte"},
            {typeof(Uri), "URI"},
            {typeof(float), "decimal number"},
            {typeof(double), "decimal number"},
            {typeof(decimal), "decimal number"},
            {typeof(string), "string"},
            {typeof(Guid), "globally unique identifier"},
            {typeof(TimeSpan), "time interval"},
            {typeof(DateTime), "date"},
            {typeof(DateTimeOffset), "date"},
            {typeof(bool), "boolean"},
        };

        private Lazy<IModelDocumentationProvider> _documentationProvider;

        public ModelDescriptionGenerator(HttpConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            _documentationProvider = new Lazy<IModelDocumentationProvider>(() => config.Services.GetDocumentationProvider() as IModelDocumentationProvider);
            GeneratedModels = new Dictionary<string, ModelDescription>(StringComparer.OrdinalIgnoreCase);
        }

        public Dictionary<string, ModelDescription> GeneratedModels { get; private set; }

        private IModelDocumentationProvider DocumentationProvider => _documentationProvider.Value;

        public ModelDescription GetOrCreateModelDescription(Type modelType)
        {
            if (modelType == null)
            {
                throw new ArgumentNullException("modelType");
            }

            var underlyingType = Nullable.GetUnderlyingType(modelType);
            if (underlyingType != null)
            {
                modelType = underlyingType;
            }

            var modelName = ModelNameHelper.GetModelName(modelType);
            if (GeneratedModels.TryGetValue(modelName, out var modelDescription))
            {
                if (modelType != modelDescription.ModelType)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            "A model description could not be created. Duplicate model name '{0}' was found for types '{1}' and '{2}'. " +
                            "Use the [ModelName] attribute to change the model name for at least one of the types so that it has a unique name.",
                            modelName,
                            modelDescription.ModelType.FullName,
                            modelType.FullName));
                }

                return modelDescription;
            }

            if (DefaultTypeDocumentation.ContainsKey(modelType))
            {
                return GenerateSimpleTypeModelDescription(modelType);
            }

            if (modelType.IsEnum)
            {
                return GenerateEnumTypeModelDescription(modelType);
            }

            if (modelType.IsGenericType)
            {
                var genericArguments = modelType.GetGenericArguments();

                switch (genericArguments.Length)
                {
                    case 1:
                    {
                        var enumerableType = typeof(IEnumerable<>).MakeGenericType(genericArguments);
                        if (enumerableType.IsAssignableFrom(modelType))
                        {
                            return GenerateCollectionModelDescription(modelType, genericArguments[0]);
                        }

                        break;
                    }
                    case 2:
                    {
                        var dictionaryType = typeof(IDictionary<,>).MakeGenericType(genericArguments);
                        if (dictionaryType.IsAssignableFrom(modelType))
                        {
                            return GenerateDictionaryModelDescription(modelType, genericArguments[0], genericArguments[1]);
                        }

                        var keyValuePairType = typeof(KeyValuePair<,>).MakeGenericType(genericArguments);
                        if (keyValuePairType.IsAssignableFrom(modelType))
                        {
                            return GenerateKeyValuePairModelDescription(modelType, genericArguments[0], genericArguments[1]);
                        }

                        break;
                    }
                }
            }

            if (modelType.IsArray)
            {
                var elementType = modelType.GetElementType();
                return GenerateCollectionModelDescription(modelType, elementType);
            }

            if (modelType == typeof(NameValueCollection))
            {
                return GenerateDictionaryModelDescription(modelType, typeof(string), typeof(string));
            }

            if (typeof(IDictionary).IsAssignableFrom(modelType))
            {
                return GenerateDictionaryModelDescription(modelType, typeof(object), typeof(object));
            }

            return typeof(IEnumerable).IsAssignableFrom(modelType) ? GenerateCollectionModelDescription(modelType, typeof(object)) : GenerateComplexTypeModelDescription(modelType);
        }

        // Change this to provide different name for the member.
        private static string GetMemberName(MemberInfo member, bool hasDataContractAttribute)
        {
            var jsonProperty = member.GetCustomAttribute<JsonPropertyAttribute>();
            if (jsonProperty != null && !string.IsNullOrEmpty(jsonProperty.PropertyName))
            {
                return jsonProperty.PropertyName;
            }

            if (!hasDataContractAttribute) return member.Name;
            var dataMember = member.GetCustomAttribute<DataMemberAttribute>();
            if (dataMember != null && !string.IsNullOrEmpty(dataMember.Name))
            {
                return dataMember.Name;
            }

            return member.Name;
        }

        private static bool ShouldDisplayMember(MemberInfo member, bool hasDataContractAttribute)
        {
            var jsonIgnore = member.GetCustomAttribute<JsonIgnoreAttribute>();
            var xmlIgnore = member.GetCustomAttribute<XmlIgnoreAttribute>();
            var ignoreDataMember = member.GetCustomAttribute<IgnoreDataMemberAttribute>();
            var nonSerialized = member.GetCustomAttribute<NonSerializedAttribute>();
            var apiExplorerSetting = member.GetCustomAttribute<ApiExplorerSettingsAttribute>();

            var hasMemberAttribute = member.DeclaringType.IsEnum ? member.GetCustomAttribute<EnumMemberAttribute>() != null : member.GetCustomAttribute<DataMemberAttribute>() != null;

            // Display member only if all the followings are true:
            // no JsonIgnoreAttribute
            // no XmlIgnoreAttribute
            // no IgnoreDataMemberAttribute
            // no NonSerializedAttribute
            // no ApiExplorerSettingsAttribute with IgnoreApi set to true
            // no DataContractAttribute without DataMemberAttribute or EnumMemberAttribute
            return jsonIgnore == null &&
                   xmlIgnore == null &&
                   ignoreDataMember == null &&
                   nonSerialized == null &&
                   (apiExplorerSetting == null || !apiExplorerSetting.IgnoreApi) &&
                   (!hasDataContractAttribute || hasMemberAttribute);
        }

        private string CreateDefaultDocumentation(Type type)
        {
            if (DefaultTypeDocumentation.TryGetValue(type, out var documentation))
            {
                return documentation;
            }

            if (DocumentationProvider != null)
            {
                documentation = DocumentationProvider.GetDocumentation(type);
            }

            return documentation;
        }

        private void GenerateAnnotations(MemberInfo property, ParameterDescription propertyModel)
        {
            var annotations = new List<ParameterAnnotation>();

            var attributes = property.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (AnnotationTextGenerator.TryGetValue(attribute.GetType(), out var textGenerator))
                {
                    annotations.Add(
                        new ParameterAnnotation
                        {
                            AnnotationAttribute = attribute,
                            Documentation = textGenerator(attribute)
                        });
                }
            }

            // Rearrange the annotations
            annotations.Sort((x, y) =>
            {
                // Special-case RequiredAttribute so that it shows up on top
                if (x.AnnotationAttribute is RequiredAttribute)
                {
                    return -1;
                }

                return y.AnnotationAttribute is RequiredAttribute ? 1 : string.Compare(x.Documentation, y.Documentation, StringComparison.OrdinalIgnoreCase);
            });

            foreach (var annotation in annotations)
            {
                propertyModel.Annotations.Add(annotation);
            }
        }

        private CollectionModelDescription GenerateCollectionModelDescription(Type modelType, Type elementType)
        {
            var collectionModelDescription = GetOrCreateModelDescription(elementType);
            if (collectionModelDescription != null)
            {
                return new CollectionModelDescription
                {
                    Name = ModelNameHelper.GetModelName(modelType),
                    ModelType = modelType,
                    ElementDescription = collectionModelDescription
                };
            }

            return null;
        }

        private ModelDescription GenerateComplexTypeModelDescription(Type modelType)
        {
            var complexModelDescription = new ComplexTypeModelDescription
            {
                Name = ModelNameHelper.GetModelName(modelType),
                ModelType = modelType,
                Documentation = CreateDefaultDocumentation(modelType)
            };

            GeneratedModels.Add(complexModelDescription.Name, complexModelDescription);
            var hasDataContractAttribute = modelType.GetCustomAttribute<DataContractAttribute>() != null;
            var properties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (!ShouldDisplayMember(property, hasDataContractAttribute)) continue;
                var propertyModel = new ParameterDescription
                {
                    Name = GetMemberName(property, hasDataContractAttribute)
                };

                if (DocumentationProvider != null)
                {
                    propertyModel.Documentation = DocumentationProvider.GetDocumentation(property);
                }

                GenerateAnnotations(property, propertyModel);
                complexModelDescription.Properties.Add(propertyModel);
                propertyModel.TypeDescription = GetOrCreateModelDescription(property.PropertyType);
            }

            var fields = modelType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                if (!ShouldDisplayMember(field, hasDataContractAttribute)) continue;
                var propertyModel = new ParameterDescription
                {
                    Name = GetMemberName(field, hasDataContractAttribute)
                };

                if (DocumentationProvider != null)
                {
                    propertyModel.Documentation = DocumentationProvider.GetDocumentation(field);
                }

                complexModelDescription.Properties.Add(propertyModel);
                propertyModel.TypeDescription = GetOrCreateModelDescription(field.FieldType);
            }

            return complexModelDescription;
        }

        private DictionaryModelDescription GenerateDictionaryModelDescription(Type modelType, Type keyType, Type valueType)
        {
            var keyModelDescription = GetOrCreateModelDescription(keyType);
            var valueModelDescription = GetOrCreateModelDescription(valueType);

            return new DictionaryModelDescription
            {
                Name = ModelNameHelper.GetModelName(modelType),
                ModelType = modelType,
                KeyModelDescription = keyModelDescription,
                ValueModelDescription = valueModelDescription
            };
        }

        private EnumTypeModelDescription GenerateEnumTypeModelDescription(Type modelType)
        {
            var enumDescription = new EnumTypeModelDescription
            {
                Name = ModelNameHelper.GetModelName(modelType),
                ModelType = modelType,
                Documentation = CreateDefaultDocumentation(modelType)
            };
            var hasDataContractAttribute = modelType.GetCustomAttribute<DataContractAttribute>() != null;
            foreach (var field in modelType.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (!ShouldDisplayMember(field, hasDataContractAttribute)) continue;
                var enumValue = new EnumValueDescription
                {
                    Name = field.Name,
                    Value = field.GetRawConstantValue().ToString()
                };
                if (DocumentationProvider != null)
                {
                    enumValue.Documentation = DocumentationProvider.GetDocumentation(field);
                }

                enumDescription.Values.Add(enumValue);
            }

            GeneratedModels.Add(enumDescription.Name, enumDescription);

            return enumDescription;
        }

        private KeyValuePairModelDescription GenerateKeyValuePairModelDescription(Type modelType, Type keyType, Type valueType)
        {
            var keyModelDescription = GetOrCreateModelDescription(keyType);
            var valueModelDescription = GetOrCreateModelDescription(valueType);

            return new KeyValuePairModelDescription
            {
                Name = ModelNameHelper.GetModelName(modelType),
                ModelType = modelType,
                KeyModelDescription = keyModelDescription,
                ValueModelDescription = valueModelDescription
            };
        }

        private ModelDescription GenerateSimpleTypeModelDescription(Type modelType)
        {
            var simpleModelDescription = new SimpleTypeModelDescription
            {
                Name = ModelNameHelper.GetModelName(modelType),
                ModelType = modelType,
                Documentation = CreateDefaultDocumentation(modelType)
            };
            GeneratedModels.Add(simpleModelDescription.Name, simpleModelDescription);

            return simpleModelDescription;
        }
    }
}