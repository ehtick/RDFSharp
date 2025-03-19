﻿/*
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
        internal const string NQuadsSPBCRegexMask = @"^<[^<>\s]+>\s*<[^<>\s]+>\s*_:[^<>\s]+\s*<[^<>\s]+>\s*\.$";
        #endregion

        #region Ctors
        static RDFStoreShims()
        {
#if NET8_0_OR_GREATER
            NQuadsSPBCRegexShim = new Lazy<Regex>(NQuadsSPBCRegex);
#else
            NQuadsSPBCRegexShim = new Lazy<Regex>(() => new Regex(NQuadsSPBCRegexMask, RegexOptions.Compiled));
#endif
        }
        #endregion

        #region Properties
        internal static Lazy<Regex> NQuadsSPBCRegexShim { get; }
        #endregion

#if NET8_0_OR_GREATER
        [GeneratedRegex(NQuadsSPBCRegexMask)]
        private static partial Regex NQuadsSPBCRegex();
#endif
    }
}