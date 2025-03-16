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

        private const string PrefixRegexShimMask = @"^[a-zA-Z0-9_\-]+$";
        internal static Regex PrefixRegexShim =>
#if NET8_0_OR_GREATER
            PrefixRegex();
#else
            new Regex(PrefixRegexShimMask, RegexOptions.Compiled);
#endif

#if NET8_0_OR_GREATER
        [GeneratedRegex(PrefixRegexShimMask)]
        private static partial Regex PrefixRegex();
#endif

        #endregion
    }
}