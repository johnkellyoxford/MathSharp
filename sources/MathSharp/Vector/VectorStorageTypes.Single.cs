﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace MathSharp.StorageTypes
{
    public readonly struct Vector2F : IEquatable<Vector2F>, IEquatable<Vector2FAligned>
    {
        public readonly float X, Y;

        public Vector2F(Vector2F xy) => this = xy;

        public unsafe Vector2F(Vector2FAligned xy) => this = *(Vector2F*)&xy;

        public Vector2F(float xy) : this(xy, xy) { }

        public Vector2F(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
            => obj is Vector2F other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(Vector2F other) => X.Equals(other.X) && Y.Equals(other.Y);
        public bool Equals(Vector2FAligned other) => Equals(new Vector2F(other));

        public override unsafe string? ToString()
        {
            fixed (Vector2F* p = &this)
            {
                return Vector.ToString(VectorExtensions.ToVector128(p), elemCount: 2);
            }
        }
    }
    public readonly struct Vector3F : IEquatable<Vector3F>, IEquatable<Vector3FAligned>
    {
        public readonly float X, Y, Z;

        public Vector3F(Vector3F xyz) => this = xyz;

        public unsafe Vector3F(Vector3FAligned xyz) => this = *(Vector3F*)&xyz;

        public Vector3F(float xyz) : this(xyz, xyz, xyz) { }

        public Vector3F(Vector2F xy, float z) : this(xy.X, xy.Y, z) { }

        public Vector3F(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object? obj)
            => obj is Vector2F other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(Vector3F other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public bool Equals(Vector3FAligned other) => Equals(new Vector3F(other));


        public override unsafe string? ToString()
        {
            fixed (Vector3F* p = &this)
            {
                return Vector.ToString(VectorExtensions.ToVector128(p), elemCount: 3);
            }
        }
    }


    public readonly struct Vector4F : IEquatable<Vector4F>, IEquatable<Vector4FAligned>
    {
        public readonly float X, Y, Z, W;

        public Vector4F(Vector4F xyzw) => this = xyzw;
        public unsafe Vector4F(Vector4FAligned xy) => this = *(Vector4F*)&xy;

        public Vector4F(float xyzw) : this(xyzw, xyzw, xyzw, xyzw) { }

        public Vector4F(Vector2F xy, Vector2F zw) : this(xy.X, xy.Y, zw.X, zw.Y) { }

        public Vector4F(Vector2F xy, float z, float w) : this(xy.X, xy.Y, z, w) { }

        public Vector4F(Vector3F xyz, float w) : this(xyz.X, xyz.Y, xyz.Z, w) { }

        public Vector4F(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public override bool Equals(object? obj)
            => obj is Vector4F other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(Vector4F other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public bool Equals(Vector4FAligned other) => Equals(new Vector4F(other));

        public override unsafe string? ToString()
        {
            fixed (Vector4F* p = &this)
            {
                return Vector.ToString(VectorExtensions.ToVector128(p), elemCount: 4);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public readonly struct Vector2FAligned : IEquatable<Vector2FAligned>, IEquatable<Vector2F>
    {
        public readonly float X, Y;

        public Vector2FAligned(Vector2FAligned xy) => this = xy;
        public Vector2FAligned(Vector2F xy) : this(xy.X, xy.Y) { }

        public Vector2FAligned(float xy) : this(xy, xy) { }

        public Vector2FAligned(float x, float y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object? obj)
            => obj is Vector2FAligned other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(Vector2FAligned other) => X.Equals(other.X) && Y.Equals(other.Y);
        public bool Equals(Vector2F other) => Equals(new Vector2FAligned(other));

        public override unsafe string? ToString()
        {
            fixed (Vector2FAligned* p = &this)
            {
                return Vector.ToString(VectorExtensions.ToVector128(p), elemCount: 2);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public readonly struct Vector3FAligned : IEquatable<Vector3FAligned>, IEquatable<Vector3F>
    {
        public readonly float X, Y, Z;

        public Vector3FAligned(Vector3FAligned xyz) => this = xyz;
        public Vector3FAligned(Vector3F xyz) : this(xyz.X, xyz.Y, xyz.Z) { }

        public Vector3FAligned(float xyz) : this(xyz, xyz, xyz) { }

        public Vector3FAligned(Vector2F xy, float z) : this(xy.X, xy.Y, z) { }

        public Vector3FAligned(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object? obj)
            => obj is Vector3FAligned other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(Vector3FAligned other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public bool Equals(Vector3F other) => Equals(new Vector3FAligned(other));

        public override unsafe string? ToString()
        {
            fixed (Vector3FAligned* p = &this)
            {
                return Vector.ToString(VectorExtensions.ToVector128(p), elemCount: 3);
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public readonly struct Vector4FAligned : IEquatable<Vector4FAligned>, IEquatable<Vector4F>
    {
        public readonly float X, Y, Z, W;

        public Vector4FAligned(Vector4FAligned xyzw) => this = xyzw;

        public unsafe Vector4FAligned(Vector4F xyzw) => this = *(Vector4FAligned*)&xyzw;

        public Vector4FAligned(float xyzw) : this(xyzw, xyzw, xyzw, xyzw) { }

        public Vector4FAligned(Vector2F xy, Vector2F zw) : this(xy.X, xy.Y, zw.X, zw.Y) { }

        public Vector4FAligned(Vector2F xy, float z, float w) : this(xy.X, xy.Y, z, w) { }

        public Vector4FAligned(Vector3F xyz, float w) : this(xyz.X, xyz.Y, xyz.Z, w) { }

        public Vector4FAligned(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public override bool Equals(object? obj)
            => obj is Vector4FAligned other && Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(Vector4FAligned other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public bool Equals(Vector4F other) => Equals(new Vector4FAligned(other));

        public override unsafe string? ToString()
        {
            fixed (Vector4FAligned* p = &this)
            {
                return Vector.ToString(VectorExtensions.ToVector128(p), elemCount: 4);
            }
        }
    }

    public static unsafe partial class VectorExtensions
    {
        public static Vector128<float> ToVector128(Vector2F* p) => Vector.FromVector2D((float*)p);
        public static Vector128<float> ToVector128(Vector3F* p) => Vector.FromVector3D((float*)p);
        public static Vector128<float> ToVector128(Vector4F* p) => Vector.FromVector4D((float*)p);

        public static Vector128<float> ToVector128(Vector2FAligned* vector) => Vector.FromVector2DAligned((float*)vector);
        public static Vector128<float> ToVector128(Vector3FAligned* vector) => Vector.FromVector3DAligned((float*)vector);
        public static Vector128<float> ToVector128(Vector4FAligned* vector) => Vector.FromVector4DAligned((float*)vector);

        public static void StoreToVector(this Vector128<float> vector, Vector2F* destination) => vector.ToVector2D((float*)destination);
        public static void StoreToVector(this Vector128<float> vector, out Vector2F destination)
        {
            fixed (Vector2F* p = &destination)
            {
                StoreToVector(vector, p);
            }
        }

        public static void StoreToVector(this Vector128<float> vector, Vector3F* destination) => vector.ToVector3D((float*)destination);
        public static void StoreToVector(this Vector128<float> vector, out Vector3F destination)
        {
            fixed (Vector3F* p = &destination)
            {
                StoreToVector(vector, p);
            }
        }

        public static void StoreToVector(this Vector128<float> vector, Vector4F* destination) => vector.ToVector4D((float*)destination);
        public static void StoreToVector(this Vector128<float> vector, out Vector4F destination)
        {
            fixed (Vector4F* p = &destination)
            {
                StoreToVector(vector, p);
            }
        }

        public static void StoreToVector(this Vector128<float> vector, Vector2FAligned* destination) => Vector.ToVector2DAligned(vector, (float*)destination);
        public static void StoreToVector(this Vector128<float> vector, out Vector2FAligned destination)
        {
            fixed (Vector2FAligned* p = &destination)
            {
                StoreToVector(vector, p);
            }
        }

        public static void StoreToVector(this Vector128<float> vector, Vector3FAligned* destination) => Vector.ToVector3DAligned(vector, (float*)destination);
        public static void StoreToVector(this Vector128<float> vector, out Vector3FAligned destination)
        {
            fixed (Vector3FAligned* p = &destination)
            {
                StoreToVector(vector, p);
            }
        }

        public static void StoreToVector(this Vector128<float> vector, Vector4FAligned* destination) => Vector.ToVector4DAligned(vector, (float*)destination);
        public static void StoreToVector(this Vector128<float> vector, out Vector4FAligned destination)
        {
            fixed (Vector4FAligned* p = &destination)
            {
                StoreToVector(vector, p);
            }
        }
    }
}
