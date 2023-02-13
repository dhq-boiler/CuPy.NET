namespace Cupy
{
    public static partial class cp
    {
        /// <summary>
        ///     IEEE 754 floating point representation of (positive) infinity.
        /// </summary>
        public static float inf => self.GetAttr("inf").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of (positive) infinity.
        ///     Use cp.inf because Inf, Infinity, PINF and infty are aliases for inf.For more details, see inf.
        /// </summary>
        public static float Inf => self.GetAttr("inf").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of (positive) infinity.
        ///     Use cp.inf because Inf, Infinity, PINF and infty are aliases for inf.For more details, see inf.
        /// </summary>
        public static float Infinity => self.GetAttr("inf").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of (positive) infinity.
        ///     Use cp.inf because Inf, Infinity, PINF and infty are aliases for inf.For more details, see inf.
        /// </summary>
        public static float PINF => self.GetAttr("inf").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of (positive) infinity.
        ///     Use cp.inf because Inf, Infinity, PINF and infty are aliases for inf.For more details, see inf.
        /// </summary>
        public static float infty => self.GetAttr("inf").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of (positive) infinity.
        /// </summary>
        public static float NINF => self.GetAttr("NINF").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of Not a Number(NaN).
        /// </summary>
        public static float nan => self.GetAttr("nan").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of Not a Number(NaN).
        ///     NaN and NAN are equivalent definitions of nan.Please use nan instead of NAN.
        /// </summary>
        public static float NaN => self.GetAttr("nan").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of Not a Number(NaN).
        ///     NaN and NAN are equivalent definitions of nan.Please use nan instead of NAN.
        /// </summary>
        public static float NAN => self.GetAttr("nan").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of negative zero.
        /// </summary>
        public static float NZERO => self.GetAttr("NZERO").As<float>();

        /// <summary>
        ///     IEEE 754 floating point representation of positive zero.
        /// </summary>
        public static float PZERO => self.GetAttr("PZERO").As<float>();

        /// <summary>
        ///     Euler’s constant, base of natural logarithms, Napier’s constant.
        /// </summary>
        public static float e => self.GetAttr("e").As<float>();

        /// <summary>
        ///     γ = 0.5772156649015328606065120900824024310421...
        ///     https://en.wikipedia.org/wiki/Euler-Mascheroni_constant
        /// </summary>
        public static float euler_gamma => self.GetAttr("e").As<float>();

        /// <summary>
        ///     A convenient alias for None, useful for indexing arrays.
        /// </summary>
        public static object newaxis => self.GetAttr("newaxis");

        /// <summary>
        ///     pi = 3.1415926535897932384626433...
        /// </summary>
        public static float pi => self.GetAttr("pi").As<float>();
    }
}