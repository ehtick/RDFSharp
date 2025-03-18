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
        #endregion

        #region Ctors
        static RDFModelShims()
        {
#if NET8_0_OR_GREATER
            PrefixRegexShim = PrefixRegex();
            LanguageTagRegexShim = LanguageTagRegex();
            TurtleLongLiteralCharsRegexShim = TurtleLongLiteralCharsRegex();
#else
            PrefixRegexShim = new Regex(PrefixRegexMask, RegexOptions.Compiled);
            LanguageTagRegexShim = new Regex("^" + LanguageTagRegexMask + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            TurtleLongLiteralCharsRegexShim = new Regex(TurtleLongLiteralCharsRegexMask, RegexOptions.Compiled);
#endif
        }
        #endregion

        #region Properties
        internal static Regex PrefixRegexShim { get; }

        internal static Regex LanguageTagRegexShim { get; }

        internal static Regex TurtleLongLiteralCharsRegexShim { get; }
        #endregion

#if NET8_0_OR_GREATER
        [GeneratedRegex(PrefixRegexMask)]
        private static partial Regex PrefixRegex();

        [GeneratedRegex("^" + LanguageTagRegexMask + "$", RegexOptions.IgnoreCase)]
        private static partial Regex LanguageTagRegex();

        [GeneratedRegex(TurtleLongLiteralCharsRegexMask)]
        private static partial Regex TurtleLongLiteralCharsRegex();
#endif
    }
}