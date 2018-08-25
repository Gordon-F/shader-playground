﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShaderPlayground.Core
{
    public sealed class ShaderCompilerParameter
    {
        public string Name { get; }
        public string DisplayName { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ShaderCompilerParameterType ParameterType { get; }

        public string[] Options { get; }
        public string DefaultValue { get; }

        public string Description { get; }

        public string OnlyForInputLanguage { get; }

        internal ShaderCompilerParameter(
            string name, 
            string displayName, 
            ShaderCompilerParameterType parameterType, 
            string[] options = null, 
            string defaultValue = null, 
            string description = null,
            string onlyForInputLanguage = null)
        {
            Name = name;
            DisplayName = displayName;
            ParameterType = parameterType;
            Options = options ?? Array.Empty<string>();
            DefaultValue = defaultValue;
            Description = description;
            OnlyForInputLanguage = onlyForInputLanguage;
        }

        public ShaderCompilerParameter WithOnlyForInputLanguage(string language)
        {
            return new ShaderCompilerParameter(
                Name,
                DisplayName,
                ParameterType,
                Options,
                DefaultValue,
                Description,
                language);
        }
    }
}
