﻿using System;
using System.Runtime.InteropServices;

namespace MathModule
{
	/// <summary>
	/// Vector3 is an utility class for manipulating 3 dimensional
	/// vectors with float components
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector3 : IEquatable<Vector3>
	{
		/// <summary>X (horizontal) component of the vector</summary>
		public float X { get; set; }

		/// <summary>Y (vertical) component of the vector</summary>
		public float Y { get; set; }

		/// <summary>Z (depth) component of the vector</summary>
		public float Z { get; set; }

		/// <summary>
		/// Construct the vector from it's coordinates
		/// </summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		/// <param name="z">Z coordinate</param>
		public Vector3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Construct the vector from it's coordinates
		/// </summary>
		/// <param name="values">The values to assign to the X, Y, and Z components of the vector. This must be an array with three elements</param>
		/// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is <c>null</c></exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="values"/> contains more or less than three elements</exception>
		public Vector3(float[] values)
		{
			if (values == null)
				throw new ArgumentNullException("values");

			if (values.Length != 3)
				throw new ArgumentOutOfRangeException("values", "There must be three and only three input values for Vector3.");

			X = values[0];
			Y = values[1];
			Z = values[2];
		}

		/// <summary>
		/// Shorthand for writing Vector3(0, 0, 1)
		/// </summary>
		/// <returns>Vector forward</returns>
		public static readonly Vector3 Forward = new Vector3(0f, 0f, 1f);

		/// <summary>
		/// Shorthand for writing Vector3(0, 0, -1)
		/// </summary>
		/// <returns>Vector back</returns>
		public static readonly Vector3 Back = new Vector3(0f, 0f, -1f);

		/// <summary>
		/// Shorthand for writing Vector3(0, 1, 0)
		/// </summary>
		/// <returns>Vector up</returns>
		public static readonly Vector3 Up = new Vector3(0f, 1f, 0f);

		/// <summary>
		/// Shorthand for writing Vector3(0, -1, 0)
		/// </summary>
		/// <returns>Vector down</returns>
		public static readonly Vector3 Down = new Vector3(0f, -1f, 0f);

		/// <summary>
		/// Shorthand for writing Vector3(-1, 0, 0)
		/// </summary>
		/// <returns>Vector left</returns>
		public static readonly Vector3 Left = new Vector3(-1f, 0f, 0f);

		/// <summary>
		/// Shorthand for writing Vector3(1, 0, 0)
		/// </summary>
		/// <returns>Vector right</returns>
		public static readonly Vector3 Right = new Vector3(1f, 0f, 0f);

		/// <summary>
		/// Shorthand for writing Vector3(1, 1, 1)
		/// </summary>
		/// <returns>Vector one</returns>
		public static readonly Vector3 One = new Vector3(1f, 1f, 1f);

		/// <summary>
		/// Shorthand for writing Vector3(0, 0, 0)
		/// </summary>
		/// <returns>Vector zero</returns>
		public static readonly Vector3 Zero = new Vector3(0f, 0f, 0f);

		/// <summary>
		/// Operator + overload ; add two vectors
		/// </summary>
		/// <param name="value1">First vector</param>
		/// <param name="value2">Second vector</param>
		/// <returns>v1 + v2</returns>
		public static Vector3 operator +(Vector3 value1, Vector3 value2) => new Vector3(value1.X + value2.X, value1.Y + value2.Y, value1.Z + value2.Z);

		/// <summary>
		/// Operator - overload ; subtracts two vectors
		/// </summary>
		/// <param name="value1">First vector</param>
		/// <param name="value2">Second vector</param>
		/// <returns>v1 - v2</returns>
		public static Vector3 operator -(Vector3 value1, Vector3 value2) => new Vector3(value1.X - value2.X, value1.Y - value2.Y, value1.Z - value2.Z);

		/// <summary>
		/// Operator - overload ; returns the opposite of a vector
		/// </summary>
		/// <param name="value">Vector to negate</param>
		/// <returns>-v</returns>
		public static Vector3 operator -(Vector3 value) => new Vector3(-value.X, -value.Y, -value.Z);

		/// <summary>
		/// Scales a vector by the given value
		/// </summary>
		/// <param name="value1">The vector to scale</param>
		/// <param name="value2">The amount by which to scale the vector</param>
		/// <returns>The scaled vector</returns>
		public static Vector3 operator *(Vector3 value1, Vector3 value2) => new Vector3(value1.X * value2.X, value1.Y * value2.Y, value1.Z * value2.Z);

		/// <summary>
		/// Operator * overload ; multiply a vector by a scalar value
		/// </summary>
		/// <param name="value">Vector</param>
		/// <param name="scalar">Scalar value</param>
		/// <returns>v * s</returns>
		public static Vector3 operator *(Vector3 value, float scalar) => new Vector3(value.X * scalar, value.Y * scalar, value.Z * scalar);

		/// <summary>
		/// Operator * overload ; multiply a scalar value by a vector
		/// </summary>
		/// <param name="scalar">Scalar value</param>
		/// <param name="value">Vector</param>
		/// <returns>s * v</returns>
		public static Vector3 operator *(float scalar, Vector3 value) => new Vector3(value.X * scalar, value.Y * scalar, value.Z * scalar);

		/// <summary>
		/// Scales a vector by the given value
		/// </summary>
		/// <param name="value1">The vector to scale</param>
		/// <param name="value2">The amount by which to scale the vector</param>
		/// <returns>The scaled vector</returns>
		public static Vector3 operator /(Vector3 value1, Vector3 value2) => new Vector3(value1.X / value2.X, value1.Y / value2.Y, value1.Z / value2.Z);

		/// <summary>
		/// Operator / overload ; divide a vector by a scalar value
		/// </summary>
		/// <param name="value">Vector</param>
		/// <param name="scalar">Scalar value</param>
		/// <returns>v / s</returns>
		public static Vector3 operator /(Vector3 value, float scalar) => new Vector3(value.X / scalar, value.Y / scalar, value.Z / scalar);

		/// <summary>
		/// Performs an explicit conversion from Vector3 to Vector4D
		/// </summary>
		/// <param name="value">The value</param>
		/// <returns>The result of the conversion./returns>
		public static explicit operator Vector4(Vector3 value) => new Vector4(value, 0f);

		/// <summary>
		/// Operator == overload ; check vector equality
		/// </summary>
		/// <param name="value1">First vector</param>
		/// <param name="value2">Second vector</param>
		/// <returns>v1 == v2</returns>
		public static bool operator ==(Vector3 value1, Vector3 value2) => value1.Equals(value2);

		/// <summary>
		/// Operator != overload ; check vector inequality
		/// </summary>
		/// <param name="value1">First vector</param>
		/// <param name="value2">Second vector</param>
		/// <returns>v1 != v2</returns>
		public static bool operator !=(Vector3 value1, Vector3 value2) => !value1.Equals(value2);

		/// <summary>
		/// Compare vector and object and checks if they are equal
		/// </summary>
		/// <param name="obj">Object to check</param>
		/// <returns>Object and vector are equal</returns>
		public override bool Equals(object obj) => (obj is Vector3) && Equals((Vector3)obj);

		/// <summary>
		/// Compare two vectors and checks if they are equal
		/// </summary>
		/// <param name="other">Vector to check</param>
		/// <returns>Vectors are equal</returns>
		public bool Equals(Vector3 other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

		/// <summary>
		/// Calculates the length of the vector
		/// </summary>
		/// <returns>The length of the vector</returns>
		public static float Magnitude(Vector3 value) => Mathematics.Sqrt(Mathematics.Pow(value.X, 2) + Mathematics.Pow(value.Y, 2) + Mathematics.Pow(value.Z, 2));

		/// <summary>
        /// Calculates the squared length of the vector
        /// </summary>
		/// <returns>The length of the vector</returns>
        // public static float MagnitudeSquared = (X * X) + (Y * Y) + (Z * Z);

		/// <summary>
		/// Converts the vector into a unit vector
		/// </summary>
		/// <param name="value">Vector</param>
		/// <returns>Normalized vector</returns>
		public static Vector3 Normalize(Vector3 value) => value / Magnitude(value);

		/// <summary>
		/// Converts the vector into a unit vector
		/// </summary>
		/// <returns>Normalized vector</returns>
		// public static Vector3 Normalize() => Normalize(this);

		/// <summary>
		/// Calculates the dot product of two vectors
		/// </summary>
		/// <param name="value1">Vector</param>
		/// <returns>Dot Product of two vectors</returns>
		public static float DotProduct(Vector3 value1, Vector3 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;

		/// <summary>
		/// Calculates the cross product of two vectors
		/// </summary>
		/// <param name="value2">Vector</param>
		/// <returns>Cross Product of two vectors</returns>
		public static Vector3 CrossProduct(Vector3 value1, Vector3 value2) => new Vector3(value1.Y * value2.Z - value1.Z * value2.Y, value1.Z * value2.X - value1.X * value2.Z, value1.X * value2.Y - value1.Y * value2.X);

		/// <summary>
		/// Returns a <see cref="Vector3"/> containing the 3D Cartesian coordinates of a point specified in Barycentric coordinates relative to a 3D triangle
		/// </summary>
		/// <param name="value1">A <see cref="Vector3"/> containing the 3D Cartesian coordinates of vertex 1 of the triangle</param>
		/// <param name="value2">A <see cref="Vector3"/> containing the 3D Cartesian coordinates of vertex 2 of the triangle</param>
		/// <param name="value3">A <see cref="Vector3"/> containing the 3D Cartesian coordinates of vertex 3 of the triangle</param>
		/// <param name="amount1">Barycentric coordinate b2, which expresses the weighting factor toward vertex 2 (specified in <paramref name="value2"/>)</param>
		/// <param name="amount2">Barycentric coordinate b3, which expresses the weighting factor toward vertex 3 (specified in <paramref name="value3"/>)</param>
		/// <returns>A new <see cref="Vector3"/> containing the 3D Cartesian coordinates of the specified point</returns>
		public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
		{
			return new Vector3((value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X)),
				(value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y)),
				(value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z)));
		}

		/// <summary>
		/// Restricts a value to be within a specified range
		/// </summary>
		/// <param name="value">The value to clamp</param>
		/// <param name="min">The minimum value</param>
		/// <param name="max">The maximum value</param>
		/// <returns>The clamped value</returns>
		public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
		{
			float x = value.X;
			x = (x > max.X) ? max.X : x;
			x = (x < min.X) ? min.X : x;

			float y = value.Y;
			y = (y > max.Y) ? max.Y : y;
			y = (y < min.Y) ? min.Y : y;

			float z = value.Z;
			z = (z > max.Z) ? max.Z : z;
			z = (z < min.Z) ? min.Z : z;

			return new Vector3(x, y, z);
		}

		/// <summary>
		/// Calculates the distance between two vectors
		/// </summary>
		/// <param name="value1">The first vector</param>
		/// <param name="value2">The second vector</param>
		/// <returns>The distance between the two vectors</returns>
		public static float Distance(Vector3 value1, Vector3 value2)
		{
			float x = value1.X - value2.X;
			float y = value1.Y - value2.Y;
			float z = value1.Z - value2.Z;

			return Mathematics.Sqrt((x * x) + (y * y) + (z * z));
		}

		/// <summary>
		/// Performs a linear interpolation between two vectors
		/// </summary>
		/// <param name="start">Start vector</param>
		/// <param name="end">End vector</param>
		/// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/></param>
		/// <returns>The linear interpolation of the two vectors</returns>
		public static Vector3 Lerp(Vector3 start, Vector3 end, float amount)
		{
			return new Vector3(
				start.X + ((end.X - start.X) * amount),
				start.Y + ((end.Y - start.Y) * amount),
				start.Z + ((end.Z - start.Z) * amount)
			);
		}

		/// <summary>
		/// Performs a cubic interpolation between two vectors
		/// </summary>
		/// <param name="start">Start vector</param>
		/// <param name="end">End vector</param>
		/// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/></param>
		/// <returns>The cubic interpolation of the two vectors</returns>
		public static Vector3 SmoothStep(Vector3 start, Vector3 end, float amount)
		{
			float newAmount = (amount > 1f) ? 1f : ((amount < 0f) ? 0f : amount);

			return new Vector3(
				start.X + ((end.X - start.X) * (newAmount * newAmount) * (3f - (2f * newAmount))),
				start.Y + ((end.Y - start.Y) * (newAmount * newAmount) * (3f - (2f * newAmount))),
				start.Z + ((end.Z - start.Z) * (newAmount * newAmount) * (3f - (2f * newAmount)))
			);
		}

		/// <summary>
		/// Performs a Hermite spline interpolation
		/// </summary>
		/// <param name="value1">First source position vector</param>
		/// <param name="tangent1">First source tangent vector</param>
		/// <param name="value2">Second source position vector</param>
		/// <param name="tangent2">Second source tangent vector</param>
		/// <param name="amount">Weighting factor</param>
		/// <returns>The result of the Hermite spline interpolation</returns>
		public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
		{
			float squared = amount * amount;
			float cubed = amount * squared;
			float part1 = ((2f * cubed) - (3f * squared)) + 1f;
			float part2 = (-2f * cubed) + (3f * squared);
			float part3 = (cubed - (2f * squared)) + amount;
			float part4 = cubed - squared;

			return new Vector3(
				(((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4),
				(((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4),
				(((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4)
			);
		}

		/// <summary>
		/// Performs a Catmull-Rom interpolation using the specified positions
		/// </summary>
		/// <param name="value1">The first position in the interpolation</param>
		/// <param name="value2">The second position in the interpolation</param>
		/// <param name="value3">The third position in the interpolation</param>
		/// <param name="value4">The fourth position in the interpolation</param>
		/// <param name="amount">Weighting factor</param>
		/// <returns>A vector that is the result of the Catmull-Rom interpolation</returns>
		public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
		{
			float squared = amount * amount;
			float cubed = amount * squared;

			return new Vector3(
				0.5f * ((((2f * value2.X) + ((-value1.X + value3.X) * amount)) +
						(((((2f * value1.X) - (5f * value2.X)) + (4f * value3.X)) - value4.X) * squared)) +
					((((-value1.X + (3f * value2.X)) - (3f * value3.X)) + value4.X) * cubed)),
				0.5f * ((((2f * value2.Y) + ((-value1.Y + value3.Y) * amount)) +
						(((((2f * value1.Y) - (5f * value2.Y)) + (4f * value3.Y)) - value4.Y) * squared)) +
					((((-value1.Y + (3f * value2.Y)) - (3f * value3.Y)) + value4.Y) * cubed)),
				0.5f * ((((2f * value2.Z) + ((-value1.Z + value3.Z) * amount)) +
						(((((2f * value1.Z) - (5f * value2.Z)) + (4f * value3.Z)) - value4.Z) * squared)) +
					((((-value1.Z + (3f * value2.Z)) - (3f * value3.Z)) + value4.Z) * cubed))
			);
		}

		/// <summary>
		/// Returns a vector containing the largest components of the specified vectors
		/// </summary>
		/// <param name="value1">The first source vector</param>
		/// <param name="value2">The second source vector</param>
		/// <returns>A vector containing the largest components of the source vectors</returns>
		public static Vector3 Max(Vector3 value1, Vector3 value2)
		{
			return new Vector3(
				(value1.X > value2.X) ? value1.X : value2.X,
				(value1.Y > value2.Y) ? value1.Y : value2.Y,
				(value1.Z > value2.Z) ? value1.Z : value2.Z
			);
		}

		/// <summary>
		/// Returns a vector containing the smallest components of the specified vectors
		/// </summary>
		/// <param name="value1">The first source vector</param>
		/// <param name="value2">The second source vector</param>
		/// <returns>A vector containing the smallest components of the source vectors</returns>
		public static Vector3 Min(Vector3 value1, Vector3 value2)
		{
			return new Vector3(
				(value1.X < value2.X) ? value1.X : value2.X,
				(value1.Y < value2.Y) ? value1.Y : value2.Y,
				(value1.Z < value2.Z) ? value1.Z : value2.Z
			);
		}

		/// <summary>
		/// Returns the reflection of a vector off a surface that has the specified normal
		/// </summary>
		/// <param name="vector">The source vector</param>
		/// <param name="normal">Normal of the surface</param>
		/// <returns>The reflected vector</returns>
		public static Vector3 Reflect(Vector3 vector, Vector3 normal)
		{
			float dot = DotProduct(vector, normal);

			return new Vector3(
				vector.X - ((2f * dot) * normal.X),
				vector.Y - ((2f * dot) * normal.Y),
				vector.Z - ((2f * dot) * normal.Z)
			);
		}

		/// <summary>
		/// Returns the fraction of a vector off a surface that has the specified normal and index
		/// </summary>
		/// <param name="vector">The source vector</param>
		/// <param name="normal">Normal of the surface</param>
		/// <param name="index">Index of refraction</param>
		/// <returns>The refracted vector</returns>
		public static Vector3 Refract(Vector3 vector, Vector3 normal, float index)
		{
			float cos1;

			cos1 = DotProduct(vector, normal);

			float radicand = 1f - (index * index) * (1f - (cos1 * cos1));

			if (radicand < 0f)
				return Zero;
			else
			{
				float cos2 = Mathematics.Sqrt(radicand);
				return (index * vector) + ((cos2 - index * cos1) * normal);
			}
		}

		/// <summary>
		/// Transforms a 3D vector by the given <see cref="Quaternion"/> rotation
		/// </summary>
		/// <param name="vector">The vector to rotate</param>
		/// <param name="rotation">The <see cref="Quaternion"/> rotation to apply</param>
		/// <returns>The transformed <see cref="Vector4"/></returns>
		public static Vector3 Transform(Vector3 vector, Quaternion rotation)
		{
			float x = rotation.X + rotation.X;
			float y = rotation.Y + rotation.Y;
			float z = rotation.Z + rotation.Z;
			float wx = rotation.W * x;
			float wy = rotation.W * y;
			float wz = rotation.W * z;
			float xx = rotation.X * x;
			float xy = rotation.X * y;
			float xz = rotation.X * z;
			float yy = rotation.Y * y;
			float yz = rotation.Y * z;
			float zz = rotation.Z * z;

			float num1 = ((1f - yy) - zz);
			float num2 = (xy - wz);
			float num3 = (xz + wy);
			float num4 = (xy + wz);
			float num5 = ((1f - xx) - zz);
			float num6 = (yz - wx);
			float num7 = (xz - wy);
			float num8 = (yz + wx);
			float num9 = ((1f - xx) - yy);

			return new Vector3(
				((vector.X * num1) + (vector.Y * num2)) + (vector.Z * num3),
				((vector.X * num4) + (vector.Y * num5)) + (vector.Z * num6),
				((vector.X * num7) + (vector.Y * num8)) + (vector.Z * num9));
		}

		/// <summary>
		/// Used to allow Vector3s to be used as keys in hash tables
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
		/// hash table.</returns>
		public override int GetHashCode() => X.GetHashCode() ^ (Y.GetHashCode() << 2) ^ (Z.GetHashCode() >> 2);

		/// <summary>
		/// Provide a string describing the object
		/// </summary>
		/// <returns>String description of the object</returns>
		public override string ToString() => $"[Vector3] X({ X }) Y({ Y }) Z({ Z })";
	}
}