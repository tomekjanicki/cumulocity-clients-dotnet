///
/// OperationJsonConverter.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Converter;

public sealed class OperationJsonConverter<T> : BaseWithCustomFragmentsJsonConverter<T> where T : Operation
{
    public OperationJsonConverter() : base(() => (T)Activator.CreateInstance(typeof(T)), Operation.Serialization.AdditionalPropertyClasses)
    {
    }
}