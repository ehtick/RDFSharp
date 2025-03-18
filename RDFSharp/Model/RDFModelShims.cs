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
    public static partial class RDFModelShims
    {
        #region Regex

        internal const string PrefixRegexMask = @"^[a-zA-Z0-9_\-]+$";
        internal static Regex PrefixRegexShim =>
#if NET8_0_OR_GREATER
            PrefixRegex();
#else
            new Regex(PrefixRegexMask, RegexOptions.Compiled);
#endif

        internal const string SubLanguageTagRegexMask = "(-[a-zA-Z0-9]{1,8})*(--ltr|--rtl)?";
        internal const string LanguageTagRegexMask = "[a-zA-Z]{1,8}" + SubLanguageTagRegexMask;
        internal static Regex LanguageTagRegexShim() =>
#if NET8_0_OR_GREATER
            LanguageTagRegex();
#else
            new Regex("^" + LanguageTagRegexMask + "$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
#endif

#if NET8_0_OR_GREATER
        [GeneratedRegex(PrefixRegexMask)]
        private static partial Regex PrefixRegex();

        [GeneratedRegex("^" + LanguageTagRegexMask + "$", RegexOptions.IgnoreCase)]
        private static partial Regex LanguageTagRegex();
#endif

        #endregion
    }
}