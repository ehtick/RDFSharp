/*
   Copyright 2012-2025 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace RDFSharp.Model
{
    /// <summary>
    /// RDFModelShims represents a collector for all the shims used by the "RDFSharp.Model" namespace
    /// </summary>
    internal static partial class RDFModelShims
    {
        #region Constants
        internal const string PrefixRegexMask = @"^[a-zA-Z0-9_\-]+$";
        internal const string SubLanguageTagRegexMask = "(-[a-zA-Z0-9]{1,8})*(--ltr|--rtl)?";
        internal const string LanguageTagRegexMask = "[a-zA-Z]{1,8}" + SubLanguageTagRegexMask;
        internal const string StartingWithDoubleQuotationMarkRegexMask = @"^""";
        internal const string EndingWithDoubleQuotationMarkRegexMask = @"""$";
        internal const string TurtleLongLiteralCharsRegexMask = "[\n\r\t\"]";
        internal const string EightByteUnicodeRegexMask = @"\\U([0-9A-Fa-f]{8})";
        internal const string FourByteUnicodeRegexMask = @"\\u([0-9A-Fa-f]{4})";
        internal const string HexBinaryRegexMask = "^([0-9a-fA-F]{2})*$";
        internal const string OwlRationalRegexMask = "^(0|(-)?([1-9])+([0-9])*)(/([1-9])+([0-9])*)?$";
        internal const string NTriplesBPBRegexMask  = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*_:[^<>\s]+\s*\.$";
        internal const string NTriplesBPORegexMask  = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*<[^<>\s]+>\s*\.$";
        internal const string NTriplesBPLRegexMask  = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*\""(.)*\""\s*\.$";
        internal const string NTriplesBPLLRegexMask = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*\""(.)*\""@" + LanguageTagRegexMask + @"\s*\.$";
        internal const string NTriplesBPLTRegexMask = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*\""(.)*\""\^\^<[^<>\s]+>\s*\.$";
        internal const string NTriplesSPBRegexMask  = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*_:[^<>\s]+\s*\.$";
        internal const string NTriplesSPORegexMask  = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*<[^<>\s]+>\s*\.$";
        internal const string NTriplesSPLRegexMask  = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*\""(.)*\""\s*\.$";
        internal const string NTriplesSPLLRegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*\""(.)*\""@" + LanguageTagRegexMask + @"\s*\.$";
        internal const string NTriplesSPLTRegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*\""(.)*\""\^\^<[^<>\s]+>\s*\.$";
        #endregion

        #region Ctors
        static RDFModelShims()
        {
#if NET8_0_OR_GREATER
            PrefixRegexShim = new Lazy<Regex>(PrefixRegex);
            LanguageTagRegexShim = new Lazy<Regex>(LanguageTagRegex);
            EndingWithLanguageTagRegexShim = new Lazy<Regex>(EndingWithLanguageTagRegex);
            StartingWithDoubleQuotationMarkShim = new Lazy<Regex>(StartingWithDoubleQuotationMarkRegex);
            EndingWithDoubleQuotationMarkShim = new Lazy<Regex>(EndingWithDoubleQuotationMarkRegex);
            TurtleLongLiteralCharsRegexShim = new Lazy<Regex>(TurtleLongLiteralCharsRegex);
            EightByteUnicodeRegexShim = new Lazy<Regex>(EightByteUnicodeRegex);
            FourByteUnicodeRegexShim = new Lazy<Regex>(FourByteUnicodeRegex);
            HexBinaryRegexShim = new Lazy<Regex>(HexBinaryRegex);
            OwlRationalRegexShim = new Lazy<Regex>(OwlRationalRegex);
            NTriplesBPBRegexShim = new Lazy<Regex>(NTriplesBPBRegex);
            NTriplesBPORegexShim = new Lazy<Regex>(NTriplesBPORegex);
            NTriplesBPLRegexShim = new Lazy<Regex>(NTriplesBPLRegex);
            NTriplesBPLLRegexShim = new Lazy<Regex>(NTriplesBPLLRegex);
            NTriplesBPLTRegexShim = new Lazy<Regex>(NTriplesBPLTRegex);
            NTriplesSPBRegexShim = new Lazy<Regex>(NTriplesSPBRegex);
            NTriplesSPORegexShim = new Lazy<Regex>(NTriplesSPORegex);
            NTriplesSPLRegexShim = new Lazy<Regex>(NTriplesSPLRegex);
            NTriplesSPLLRegexShim = new Lazy<Regex>(NTriplesSPLLRegex);
            NTriplesSPLTRegexShim = new Lazy<Regex>(NTriplesSPLTRegex);
#else
            PrefixRegexShim = new Lazy<Regex>(() => new Regex(PrefixRegexMask, RegexOptions.Compiled));
            LanguageTagRegexShim = new Lazy<Regex>(() => new Regex("^" + LanguageTagRegexMask + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            EndingWithLanguageTagRegexShim = new Lazy<Regex>(() => new Regex("@" + LanguageTagRegexMask + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase));
            StartingWithDoubleQuotationMarkShim = new Lazy<Regex>(() => new Regex(StartingWithDoubleQuotationMarkRegexMask, RegexOptions.Compiled));
            EndingWithDoubleQuotationMarkShim = new Lazy<Regex>(() => new Regex(EndingWithDoubleQuotationMarkRegexMask, RegexOptions.Compiled));
            TurtleLongLiteralCharsRegexShim = new Lazy<Regex>(() => new Regex(TurtleLongLiteralCharsRegexMask, RegexOptions.Compiled));
            EightByteUnicodeRegexShim = new Lazy<Regex>(() => new Regex(EightByteUnicodeRegexMask, RegexOptions.Compiled));
            FourByteUnicodeRegexShim = new Lazy<Regex>(() => new Regex(FourByteUnicodeRegexMask, RegexOptions.Compiled));
            HexBinaryRegexShim = new Lazy<Regex>(() => new Regex(HexBinaryRegexMask, RegexOptions.Compiled));
            OwlRationalRegexShim = new Lazy<Regex>(() => new Regex(OwlRationalRegexMask, RegexOptions.Compiled));
            NTriplesBPBRegexShim = new Lazy<Regex>(() => new Regex(NTriplesBPBRegexMask, RegexOptions.Compiled));
            NTriplesBPORegexShim = new Lazy<Regex>(() => new Regex(NTriplesBPORegexMask, RegexOptions.Compiled));
            NTriplesBPLRegexShim = new Lazy<Regex>(() => new Regex(NTriplesBPLRegexMask, RegexOptions.Compiled));
            NTriplesBPLLRegexShim = new Lazy<Regex>(() => new Regex(NTriplesBPLLRegexMask, RegexOptions.Compiled));
            NTriplesBPLTRegexShim = new Lazy<Regex>(() => new Regex(NTriplesBPLTRegexMask, RegexOptions.Compiled));
            NTriplesSPBRegexShim = new Lazy<Regex>(() => new Regex(NTriplesSPBRegexMask, RegexOptions.Compiled));
            NTriplesSPORegexShim = new Lazy<Regex>(() => new Regex(NTriplesSPORegexMask, RegexOptions.Compiled));
            NTriplesSPLRegexShim = new Lazy<Regex>(() => new Regex(NTriplesSPLRegexMask, RegexOptions.Compiled));
            NTriplesSPLLRegexShim = new Lazy<Regex>(() => new Regex(NTriplesSPLLRegexMask, RegexOptions.Compiled));
            NTriplesSPLTRegexShim = new Lazy<Regex>(() => new Regex(NTriplesSPLTRegexMask, RegexOptions.Compiled));
#endif
        }
        #endregion

        #region Properties
        internal static Lazy<Regex> PrefixRegexShim { get; }
        internal static Lazy<Regex> LanguageTagRegexShim { get; }
        internal static Lazy<Regex> EndingWithLanguageTagRegexShim { get; }
        internal static Lazy<Regex> StartingWithDoubleQuotationMarkShim { get; }
        internal static Lazy<Regex> EndingWithDoubleQuotationMarkShim { get; }
        internal static Lazy<Regex> TurtleLongLiteralCharsRegexShim { get; }
        internal static Lazy<Regex> EightByteUnicodeRegexShim { get; }
        internal static Lazy<Regex> FourByteUnicodeRegexShim { get; }
        internal static Lazy<Regex> HexBinaryRegexShim { get; }
        internal static Lazy<Regex> OwlRationalRegexShim { get; }
        internal static Lazy<Regex> NTriplesBPBRegexShim { get; }
        internal static Lazy<Regex> NTriplesBPORegexShim { get; }
        internal static Lazy<Regex> NTriplesBPLRegexShim { get; }
        internal static Lazy<Regex> NTriplesBPLLRegexShim { get; }
        internal static Lazy<Regex> NTriplesBPLTRegexShim { get; }
        internal static Lazy<Regex> NTriplesSPBRegexShim { get; }
        internal static Lazy<Regex> NTriplesSPORegexShim { get; }
        internal static Lazy<Regex> NTriplesSPLRegexShim { get; }
        internal static Lazy<Regex> NTriplesSPLLRegexShim { get; }
        internal static Lazy<Regex> NTriplesSPLTRegexShim { get; }
        #endregion

        #region Methods
        internal static long MD5HashShim(string input)
        {
            byte[] inputBytes = RDFModelUtilities.UTF8_NoBOM.GetBytes(input);
#if NET8_0_OR_GREATER
            return BitConverter.ToInt64(MD5.HashData(inputBytes), 0);
#else
            using (MD5CryptoServiceProvider md5Encryptor = new MD5CryptoServiceProvider())
                return BitConverter.ToInt64(md5Encryptor.ComputeHash(inputBytes), 0);
#endif
        }
        #endregion

#if NET8_0_OR_GREATER
        [GeneratedRegex(PrefixRegexMask)]
        private static partial Regex PrefixRegex();

        [GeneratedRegex("^" + LanguageTagRegexMask + "$", RegexOptions.IgnoreCase)]
        private static partial Regex LanguageTagRegex();

        [GeneratedRegex("@" + LanguageTagRegexMask + "$", RegexOptions.IgnoreCase)]
        private static partial Regex EndingWithLanguageTagRegex();

        [GeneratedRegex(StartingWithDoubleQuotationMarkRegexMask)]
        private static partial Regex StartingWithDoubleQuotationMarkRegex();

        [GeneratedRegex(EndingWithDoubleQuotationMarkRegexMask)]
        private static partial Regex EndingWithDoubleQuotationMarkRegex();

        [GeneratedRegex(TurtleLongLiteralCharsRegexMask)]
        private static partial Regex TurtleLongLiteralCharsRegex();

        [GeneratedRegex(EightByteUnicodeRegexMask)]
        private static partial Regex EightByteUnicodeRegex();

        [GeneratedRegex(FourByteUnicodeRegexMask)]
        private static partial Regex FourByteUnicodeRegex();

        [GeneratedRegex(HexBinaryRegexMask)]
        private static partial Regex HexBinaryRegex();

        [GeneratedRegex(OwlRationalRegexMask)]
        private static partial Regex OwlRationalRegex();

        [GeneratedRegex(NTriplesBPBRegexMask)]
        private static partial Regex NTriplesBPBRegex();

        [GeneratedRegex(NTriplesBPORegexMask)]
        private static partial Regex NTriplesBPORegex();

        [GeneratedRegex(NTriplesBPLRegexMask)]
        private static partial Regex NTriplesBPLRegex();

        [GeneratedRegex(NTriplesBPLLRegexMask)]
        private static partial Regex NTriplesBPLLRegex();

        [GeneratedRegex(NTriplesBPLTRegexMask)]
        private static partial Regex NTriplesBPLTRegex();

        [GeneratedRegex(NTriplesSPBRegexMask)]
        private static partial Regex NTriplesSPBRegex();

        [GeneratedRegex(NTriplesSPORegexMask)]
        private static partial Regex NTriplesSPORegex();

        [GeneratedRegex(NTriplesSPLRegexMask)]
        private static partial Regex NTriplesSPLRegex();

        [GeneratedRegex(NTriplesSPLLRegexMask)]
        private static partial Regex NTriplesSPLLRegex();

        [GeneratedRegex(NTriplesSPLTRegexMask)]
        private static partial Regex NTriplesSPLTRegex();
#endif
    }
}