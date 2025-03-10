// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The area Unit of measurement. </summary>
    public readonly partial struct AreaUnit : IEquatable<AreaUnit>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AreaUnit"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AreaUnit(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UnspecifiedValue = "Unspecified";
        private const string SquareKilometerValue = "SquareKilometer";
        private const string SquareHectometerValue = "SquareHectometer";
        private const string SquareDecameterValue = "SquareDecameter";
        private const string SquareDecimeterValue = "SquareDecimeter";
        private const string SquareMeterValue = "SquareMeter";
        private const string SquareCentimeterValue = "SquareCentimeter";
        private const string SquareMillimeterValue = "SquareMillimeter";
        private const string SquareInchValue = "SquareInch";
        private const string SquareFootValue = "SquareFoot";
        private const string SquareMileValue = "SquareMile";
        private const string SquareYardValue = "SquareYard";
        private const string AcreValue = "Acre";

        /// <summary> Unspecified. </summary>
        public static AreaUnit Unspecified { get; } = new AreaUnit(UnspecifiedValue);
        /// <summary> SquareKilometer. </summary>
        public static AreaUnit SquareKilometer { get; } = new AreaUnit(SquareKilometerValue);
        /// <summary> SquareHectometer. </summary>
        public static AreaUnit SquareHectometer { get; } = new AreaUnit(SquareHectometerValue);
        /// <summary> SquareDecameter. </summary>
        public static AreaUnit SquareDecameter { get; } = new AreaUnit(SquareDecameterValue);
        /// <summary> SquareDecimeter. </summary>
        public static AreaUnit SquareDecimeter { get; } = new AreaUnit(SquareDecimeterValue);
        /// <summary> SquareMeter. </summary>
        public static AreaUnit SquareMeter { get; } = new AreaUnit(SquareMeterValue);
        /// <summary> SquareCentimeter. </summary>
        public static AreaUnit SquareCentimeter { get; } = new AreaUnit(SquareCentimeterValue);
        /// <summary> SquareMillimeter. </summary>
        public static AreaUnit SquareMillimeter { get; } = new AreaUnit(SquareMillimeterValue);
        /// <summary> SquareInch. </summary>
        public static AreaUnit SquareInch { get; } = new AreaUnit(SquareInchValue);
        /// <summary> SquareFoot. </summary>
        public static AreaUnit SquareFoot { get; } = new AreaUnit(SquareFootValue);
        /// <summary> SquareMile. </summary>
        public static AreaUnit SquareMile { get; } = new AreaUnit(SquareMileValue);
        /// <summary> SquareYard. </summary>
        public static AreaUnit SquareYard { get; } = new AreaUnit(SquareYardValue);
        /// <summary> Acre. </summary>
        public static AreaUnit Acre { get; } = new AreaUnit(AcreValue);
        /// <summary> Determines if two <see cref="AreaUnit"/> values are the same. </summary>
        public static bool operator ==(AreaUnit left, AreaUnit right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AreaUnit"/> values are not the same. </summary>
        public static bool operator !=(AreaUnit left, AreaUnit right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AreaUnit"/>. </summary>
        public static implicit operator AreaUnit(string value) => new AreaUnit(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AreaUnit other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AreaUnit other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
