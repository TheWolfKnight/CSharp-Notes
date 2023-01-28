
using System.Numerics;

namespace Operator_Overloading.Vector
{
    public class Vector<T>
      where T : INumber<T>
    {
        public T X, Y;

        public Vector(T x, T y)
        {
            X = x;
            Y = y;
        }

        public static Vector<float> NewUnitVector()
        {
            return new Vector<float>(1.0f, 1.0f);
        }

        public static Vector<float> UnitFromRad(float rads)
        {
            Vector<float> result = new Vector<float>((float)Math.Cos(rads), (float)Math.Sin(rads));
            return result;
        }

        #region Operation implementation

        public static Vector<T> operator +(Vector<T> a, T b)
        {
            Vector<T> result = new Vector<T>(a.X + b, a.Y + b);
            return result;
        }

        public static Vector<T> operator +(Vector<T> a, Vector<T> b)
        {
            Vector<T> result = new Vector<T>(a.X + b.X, a.Y + b.Y);
            return result;
        }

        public static Vector<T> operator -(Vector<T> a, T b)
        {
            Vector<T> result = new Vector<T>(a.X - b, a.Y - b);
            return result;
        }

        public static Vector<T> operator -(Vector<T> a, Vector<T> b)
        {
            Vector<T> result = new Vector<T>(a.X - b.X, a.Y - b.Y);
            return result;
        }


        public static Vector<T> operator *(Vector<T> a, T b)
        {
            Vector<T> result = new Vector<T>(a.X * b, a.Y * b);
            return result;
        }

        public static Vector<T> operator *(Vector<T> a, Vector<T> b)
        {
            Vector<T> result = new Vector<T>(a.X * b.X, a.Y * b.Y);
            return result;
        }

        public static Vector<T> operator /(Vector<T> a, T b)
        {
            Vector<T> result = new Vector<T>(a.X / b, a.Y / b);
            return result;
        }

        public static Vector<T> operator /(Vector<T> a, Vector<T> b)
        {
            Vector<T> result = new Vector<T>(a.X / b.X, a.Y / b.Y);
            return result;
        }

        public static Vector<T> operator %(Vector<T> a, T b)
        {
            Vector<T> result = new Vector<T>(a.X % b, a.Y % b);
            return result;
        }

        public static Vector<T> operator %(Vector<T> a, Vector<T> b)
        {
            Vector<T> result = new Vector<T>(a.X % b.X, a.Y % b.Y);
            return result;
        }

        public static Vector<T> operator ++(Vector<T> a)
        {
            a.X++;
            a.Y++;
            return a;
        }

        public static Vector<T> operator --(Vector<T> a)
        {
            a.X--;
            a.Y--;
            return a;
        }

        // These two must be done together
        public static bool operator ==(Vector<T> left, Vector<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector<T> left, Vector<T> right)
        {
            return !left.Equals(right);
        }
        // These two

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;

            Vector<T> tmp = (Vector<T>)obj;

            return this.X == tmp.X && this.Y == tmp.Y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        public override string ToString()
        {
            return $"Vector(X={X}, Y={Y})";
        }
    }
}