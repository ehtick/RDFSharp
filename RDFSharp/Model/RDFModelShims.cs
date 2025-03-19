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
        internal const string TurtleLongLiteralCharsRegexMask = "[\n\r\t\"]";
        internal const string EightByteUnicodeRegexMask = @"\\U([0-9A-Fa-f]{8})";
        internal const string FourByteUnicodeRegexMask = @"\\u([0-9A-Fa-f]{4})";
        internal const string HexBinaryRegexMask = "^([0-9a-fA-F]{2})*$";
        internal const string OwlRationalRegexMask = "^(0|(-)?([1-9])+([0-9])*)(/([1-9])+([0-9])*)?$";
        internal const string NTriplesBPBRegexMask = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*_:[^<>\s]+\s*\.$";
        internal const string NTriplesBPORegexMask = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*<[^<>\s]+>\s*\.$";
        internal const string NTriplesSPBRegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*_:[^<>\s]+\s*\.$";
        internal const string NTriplesSPORegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*<[^<>\s]+>\s*\.$";
        #endregion

        #region Ctors
        static RDFModelShims()
        {
#if NET8_0_OR_GREATER
            PrefixRegexShim = PrefixRegex();
            LanguageTagRegexShim = LanguageTagRegex();
            TurtleLongLiteralCharsRegexShim = TurtleLongLiteralCharsRegex();
            EightByteUnicodeRegexShim = EightByteUnicodeRegex();
            FourByteUnicodeRegexShim = FourByteUnicodeRegex();
            HexBinaryRegexShim = HexBinaryRegex();
            OwlRationalRegexShim = OwlRationalRegex();
            NTriplesBPBRegexShim = NTriplesBPBRegex();
            NTriplesBPORegexShim = NTriplesBPORegex();
            NTriplesSPBRegexShim = NTriplesSPBRegex();
            NTriplesSPORegexShim = NTriplesSPORegex();
#else
            PrefixRegexShim = new Regex(PrefixRegexMask, RegexOptions.Compiled);
            LanguageTagRegexShim = new Regex("^" + LanguageTagRegexMask + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            TurtleLongLiteralCharsRegexShim = new Regex(TurtleLongLiteralCharsRegexMask, RegexOptions.Compiled);
            EightByteUnicodeRegexShim = new Regex(EightByteUnicodeRegexMask, RegexOptions.Compiled);
            FourByteUnicodeRegexShim = new Regex(FourByteUnicodeRegexMask, RegexOptions.Compiled);
            HexBinaryRegexShim = new Regex(HexBinaryRegexMask, RegexOptions.Compiled);
            OwlRationalRegexShim = new Regex(OwlRationalRegexMask, RegexOptions.Compiled);
            NTriplesBPBRegexShim = new Regex(NTriplesBPBRegexMask, RegexOptions.Compiled);
            NTriplesBPORegexShim = new Regex(NTriplesBPORegexMask, RegexOptions.Compiled);
            NTriplesSPBRegexShim = new Regex(NTriplesSPBRegexMask, RegexOptions.Compiled);
            NTriplesSPORegexShim = new Regex(NTriplesSPORegexMask, RegexOptions.Compiled);
#endif
        }
        #endregion

        #region Properties
        internal static Regex PrefixRegexShim { get; }
        internal static Regex LanguageTagRegexShim { get; }
        internal static Regex TurtleLongLiteralCharsRegexShim { get; }
        internal static Regex EightByteUnicodeRegexShim { get; }
        internal static Regex FourByteUnicodeRegexShim { get; }
        internal static Regex HexBinaryRegexShim { get; }
        internal static Regex OwlRationalRegexShim { get; }
        internal static Regex NTriplesBPBRegexShim { get; }
        internal static Regex NTriplesBPORegexShim { get; }
        internal static Regex NTriplesSPBRegexShim { get; }
        internal static Regex NTriplesSPORegexShim { get; }
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
        [GeneratedRegex(NTriplesSPBRegexMask)]
        private static partial Regex NTriplesSPBRegex();
        [GeneratedRegex(NTriplesSPORegexMask)]
        private static partial Regex NTriplesSPORegex();
#endif
    }
}