﻿// © Anamnesis.
// Licensed under the MIT license.

namespace Anamnesis.Converters;

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Anamnesis.Memory;

public class NpcFaceGposeConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values.Length != 3)
			throw new ArgumentException();

		if (values[0] is ActorTypes type && values[1] is byte head && values[2] is ActorCustomizeMemory.Ages age)
		{
			if (type != ActorTypes.Player)
				return Visibility.Collapsed;

			if (age != ActorCustomizeMemory.Ages.Normal)
				return Visibility.Visible;

			if (head < 100)
				return Visibility.Collapsed;

			return Visibility.Visible;
		}
		else
		{
			return Visibility.Collapsed;
		}
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException("BooleanAndConverter is a OneWay converter.");
	}
}