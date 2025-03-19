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
            PrefixRegexShim = PrefixRegex();
            LanguageTagRegexShim = LanguageTagRegex();
            EndingWithLanguageTagRegexShim = EndingWithLanguageTagRegex();
            StartingWithDoubleQuotationMarkShim = StartingWithDoubleQuotationMarkRegex();
            EndingWithDoubleQuotationMarkShim = EndingWithDoubleQuotationMarkRegex();
            TurtleLongLiteralCharsRegexShim = TurtleLongLiteralCharsRegex();
            EightByteUnicodeRegexShim = EightByteUnicodeRegex();
            FourByteUnicodeRegexShim = FourByteUnicodeRegex();
            HexBinaryRegexShim = HexBinaryRegex();
            OwlRationalRegexShim = OwlRationalRegex();
            NTriplesBPBRegexShim = NTriplesBPBRegex();
            NTriplesBPORegexShim = NTriplesBPORegex();
            NTriplesBPLRegexShim = NTriplesBPLRegex();
            NTriplesBPLLRegexShim = NTriplesBPLLRegex();
            NTriplesBPLTRegexShim = NTriplesBPLTRegex();
            NTriplesSPBRegexShim = NTriplesSPBRegex();
            NTriplesSPORegexShim = NTriplesSPORegex();
            NTriplesSPLRegexShim = NTriplesSPLRegex();
            NTriplesSPLLRegexShim = NTriplesSPLLRegex();
            NTriplesSPLTRegexShim = NTriplesSPLTRegex();
#else
            PrefixRegexShim = new Regex(PrefixRegexMask, RegexOptions.Compiled);
            LanguageTagRegexShim = new Regex("^" + LanguageTagRegexMask + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            EndingWithLanguageTagRegexShim = new Regex("@" + LanguageTagRegexMask + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            StartingWithDoubleQuotationMarkShim = new Regex(StartingWithDoubleQuotationMarkRegexMask, RegexOptions.Compiled);
            EndingWithDoubleQuotationMarkShim = new Regex(EndingWithDoubleQuotationMarkRegexMask, RegexOptions.Compiled);
            TurtleLongLiteralCharsRegexShim = new Regex(TurtleLongLiteralCharsRegexMask, RegexOptions.Compiled);
            EightByteUnicodeRegexShim = new Regex(EightByteUnicodeRegexMask, RegexOptions.Compiled);
            FourByteUnicodeRegexShim = new Regex(FourByteUnicodeRegexMask, RegexOptions.Compiled);
            HexBinaryRegexShim = new Regex(HexBinaryRegexMask, RegexOptions.Compiled);
            OwlRationalRegexShim = new Regex(OwlRationalRegexMask, RegexOptions.Compiled);
            NTriplesBPBRegexShim = new Regex(NTriplesBPBRegexMask, RegexOptions.Compiled);
            NTriplesBPORegexShim = new Regex(NTriplesBPORegexMask, RegexOptions.Compiled);
            NTriplesBPLRegexShim = new Regex(NTriplesBPLRegexMask, RegexOptions.Compiled);
            NTriplesBPLLRegexShim = new Regex(NTriplesBPLLRegexMask, RegexOptions.Compiled);
            NTriplesBPLTRegexShim = new Regex(NTriplesBPLTRegexMask, RegexOptions.Compiled);
            NTriplesSPBRegexShim = new Regex(NTriplesSPBRegexMask, RegexOptions.Compiled);
            NTriplesSPORegexShim = new Regex(NTriplesSPORegexMask, RegexOptions.Compiled);
            NTriplesSPLRegexShim = new Regex(NTriplesSPLRegexMask, RegexOptions.Compiled);
            NTriplesSPLLRegexShim = new Regex(NTriplesSPLLRegexMask, RegexOptions.Compiled);
            NTriplesSPLTRegexShim = new Regex(NTriplesSPLTRegexMask, RegexOptions.Compiled);
#endif
        }
        #endregion

        #region Properties
        internal static Regex PrefixRegexShim { get; }
        internal static Regex LanguageTagRegexShim { get; }
        internal static Regex EndingWithLanguageTagRegexShim { get; }
        internal static Regex StartingWithDoubleQuotationMarkShim { get; }
        internal static Regex EndingWithDoubleQuotationMarkShim { get; }
        internal static Regex TurtleLongLiteralCharsRegexShim { get; }
        internal static Regex EightByteUnicodeRegexShim { get; }
        internal static Regex FourByteUnicodeRegexShim { get; }
        internal static Regex HexBinaryRegexShim { get; }
        internal static Regex OwlRationalRegexShim { get; }
        internal static Regex NTriplesBPBRegexShim { get; }
        internal static Regex NTriplesBPORegexShim { get; }
        internal static Regex NTriplesBPLRegexShim { get; }
        internal static Regex NTriplesBPLLRegexShim { get; }
        internal static Regex NTriplesBPLTRegexShim { get; }
        internal static Regex NTriplesSPBRegexShim { get; }
        internal static Regex NTriplesSPORegexShim { get; }
        internal static Regex NTriplesSPLRegexShim { get; }
        internal static Regex NTriplesSPLLRegexShim { get; }
        internal static Regex NTriplesSPLTRegexShim { get; }
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