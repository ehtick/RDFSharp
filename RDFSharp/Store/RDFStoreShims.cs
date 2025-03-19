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
using System.Text.RegularExpressions;

namespace RDFSharp.Store
{
    /// <summary>
    /// RDFStoreShims represents a collector for all the shims used by the "RDFSharp.Store" namespace
    /// </summary>
    internal static partial class RDFStoreShims
    {
        #region Constants
        internal const string NQuadsBPBCRegexMask = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*_:[^<>\s]+\s*<[^<>\s]+>\s*\.$";
        internal const string NQuadsBPOCRegexMask = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*<[^<>\s]+>\s*<[^<>\s]+>\s*\.$";
        internal const string NQuadsBPLCRegexMask = @"^_:[^<>\s]+\s*<[^<>\s]+>\s*\""(.)*\""\s*<[^<>\s]+>\s*\.$";
        internal const string NQuadsSPBCRegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*_:[^<>\s]+\s*<[^<>\s]+>\s*\.$";
        internal const string NQuadsSPOCRegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*<[^<>\s]+>\s*<[^<>\s]+>\s*\.$";
        internal const string NQuadsSPLCRegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*\""(.)*\""\s*<[^<>\s]+>\s*\.$";
        #endregion

        #region Ctors
        static RDFStoreShims()
        {
#if NET8_0_OR_GREATER
            NQuadsBPBCRegexShim = new Lazy<Regex>(NQuadsBPBCRegex);
            NQuadsBPOCRegexShim = new Lazy<Regex>(NQuadsBPOCRegex);
            NQuadsBPLCRegexShim = new Lazy<Regex>(NQuadsBPLCRegex);
            NQuadsSPBCRegexShim = new Lazy<Regex>(NQuadsSPBCRegex);
            NQuadsSPOCRegexShim = new Lazy<Regex>(NQuadsSPOCRegex);
            NQuadsSPLCRegexShim = new Lazy<Regex>(NQuadsSPLCRegex);
#else
            NQuadsBPBCRegexShim = new Lazy<Regex>(() => new Regex(NQuadsBPBCRegexMask, RegexOptions.Compiled));
            NQuadsBPOCRegexShim = new Lazy<Regex>(() => new Regex(NQuadsBPOCRegexMask, RegexOptions.Compiled));
            NQuadsBPLCRegexShim = new Lazy<Regex>(() => new Regex(NQuadsBPLCRegexMask, RegexOptions.Compiled));
            NQuadsSPBCRegexShim = new Lazy<Regex>(() => new Regex(NQuadsSPBCRegexMask, RegexOptions.Compiled));
            NQuadsSPOCRegexShim = new Lazy<Regex>(() => new Regex(NQuadsSPOCRegexMask, RegexOptions.Compiled));
            NQuadsSPLCRegexShim = new Lazy<Regex>(() => new Regex(NQuadsSPLCRegexMask, RegexOptions.Compiled));
#endif
        }
        #endregion

        #region Properties
        internal static Lazy<Regex> NQuadsBPBCRegexShim { get; }
        internal static Lazy<Regex> NQuadsBPOCRegexShim { get; }
        internal static Lazy<Regex> NQuadsBPLCRegexShim { get; }
        internal static Lazy<Regex> NQuadsSPBCRegexShim { get; }
        internal static Lazy<Regex> NQuadsSPOCRegexShim { get; }
        internal static Lazy<Regex> NQuadsSPLCRegexShim { get; }
        #endregion

#if NET8_0_OR_GREATER
        [GeneratedRegex(NQuadsBPBCRegexMask)]
        private static partial Regex NQuadsBPBCRegex();

        [GeneratedRegex(NQuadsBPOCRegexMask)]
        private static partial Regex NQuadsBPOCRegex();

        [GeneratedRegex(NQuadsBPLCRegexMask)]
        private static partial Regex NQuadsBPLCRegex();

        [GeneratedRegex(NQuadsSPBCRegexMask)]
        private static partial Regex NQuadsSPBCRegex();

        [GeneratedRegex(NQuadsSPOCRegexMask)]
        private static partial Regex NQuadsSPOCRegex();

        [GeneratedRegex(NQuadsSPLCRegexMask)]
        private static partial Regex NQuadsSPLCRegex();
#endif
    }
}