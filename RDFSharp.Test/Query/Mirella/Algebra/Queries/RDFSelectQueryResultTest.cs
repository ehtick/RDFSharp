/*
   Copyright 2012-2022 Marco De Salvo

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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using RDFSharp.Model;
using RDFSharp.Query;

namespace RDFSharp.Test.Query
{
    [TestClass]
    public class RDFSelectQueryResultTest
    {
        #region Tests
        [TestMethod]
        public void ShouldCreateSelectQueryResult()
        {
            RDFSelectQueryResult result = new RDFSelectQueryResult();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.SelectResults);
            Assert.IsTrue(result.SelectResultsCount == 0);
        }

        [TestMethod]
        public void ShouldSerializeSelectQueryResultToStream()
        {
            RDFSelectQueryResult selectResult = new RDFSelectQueryResult();
            selectResult.SelectResults.Columns.Add(new DataColumn("?S", typeof(string)));
            selectResult.SelectResults.Columns.Add(new DataColumn("?T", typeof(string)));
            DataRow row0 = selectResult.SelectResults.NewRow();
            row0["?S"] = "ex:org";
            row0["?T"] = "hello@EN-US";
            selectResult.SelectResults.Rows.Add(row0);
            DataRow row1 = selectResult.SelectResults.NewRow();
            row1["?S"] = "bnode:12345";
            row1["?T"] = $"hello^^{RDFVocabulary.XSD.STRING}";
            selectResult.SelectResults.Rows.Add(row1);
            selectResult.SelectResults.AcceptChanges();
            
            MemoryStream stream = new MemoryStream();
            selectResult.ToSparqlXmlResult(stream);
            byte[] streamData = stream.ToArray();
            
            Assert.IsTrue(streamData.Length > 100);

            RDFSelectQueryResult selectResult2 = RDFSelectQueryResult.FromSparqlXmlResult(new MemoryStream(streamData));

            Assert.IsNotNull(selectResult2);
            Assert.IsNotNull(selectResult2.SelectResults);
            Assert.IsTrue(selectResult2.SelectResultsCount == 2);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Count == 2);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?S"));
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?T"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?S"].Equals("ex:org"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?T"].Equals("hello@EN-US"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[1]["?S"].Equals("bnode:12345"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[1]["?T"].Equals($"hello^^{RDFVocabulary.XSD.STRING}"));
        }

        [TestMethod]
        public async Task ShouldSerializeSelectQueryResultToStreamAsync()
        {
            RDFSelectQueryResult selectResult = new RDFSelectQueryResult();
            selectResult.SelectResults.Columns.Add(new DataColumn("?S", typeof(string)));
            selectResult.SelectResults.Columns.Add(new DataColumn("?T", typeof(string)));
            DataRow row = selectResult.SelectResults.NewRow();
            row["?S"] = "ex:org";
            row["?T"] = "hello@EN-US";
            selectResult.SelectResults.Rows.Add(row);
            selectResult.SelectResults.AcceptChanges();
            
            MemoryStream stream = new MemoryStream();
            await selectResult.ToSparqlXmlResultAsync(stream);
            byte[] streamData = stream.ToArray();
            
            Assert.IsTrue(streamData.Length > 100);

            RDFSelectQueryResult selectResult2 = await RDFSelectQueryResult.FromSparqlXmlResultAsync(new MemoryStream(streamData));

            Assert.IsNotNull(selectResult2);
            Assert.IsNotNull(selectResult2.SelectResults);
            Assert.IsTrue(selectResult2.SelectResultsCount == 1);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Count == 2);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?S"));
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?T"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?S"].Equals("ex:org"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?T"].Equals("hello@EN-US"));
        }

        [TestMethod]
        public void ShouldSerializeSelectQueryResultToFile()
        {
            RDFSelectQueryResult selectResult = new RDFSelectQueryResult();
            selectResult.SelectResults.Columns.Add(new DataColumn("?S", typeof(string)));
            selectResult.SelectResults.Columns.Add(new DataColumn("?T", typeof(string)));
            DataRow row = selectResult.SelectResults.NewRow();
            row["?S"] = "ex:org";
            row["?T"] = "hello@EN-US";
            selectResult.SelectResults.Rows.Add(row);
            selectResult.SelectResults.AcceptChanges();
            
            selectResult.ToSparqlXmlResult(Path.Combine(Environment.CurrentDirectory, "RDFSelectQueryResultTest_ShouldSerializeSelectQueryResultToFile.srx"));
            
            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, "RDFSelectQueryResultTest_ShouldSerializeSelectQueryResultToFile.srx")));

            RDFSelectQueryResult selectResult2 = RDFSelectQueryResult.FromSparqlXmlResult(Path.Combine(Environment.CurrentDirectory, "RDFSelectQueryResultTest_ShouldSerializeSelectQueryResultToFile.srx"));

            Assert.IsNotNull(selectResult2);
            Assert.IsNotNull(selectResult2.SelectResults);
            Assert.IsTrue(selectResult2.SelectResultsCount == 1);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Count == 2);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?S"));
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?T"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?S"].Equals("ex:org"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?T"].Equals("hello@EN-US"));
        }

        [TestMethod]
        public async Task ShouldSerializeSelectQueryResultToFileAsync()
        {
            RDFSelectQueryResult selectResult = new RDFSelectQueryResult();
            selectResult.SelectResults.Columns.Add(new DataColumn("?S", typeof(string)));
            selectResult.SelectResults.Columns.Add(new DataColumn("?T", typeof(string)));
            DataRow row = selectResult.SelectResults.NewRow();
            row["?S"] = "ex:org";
            row["?T"] = "hello@EN-US";
            selectResult.SelectResults.Rows.Add(row);
            selectResult.SelectResults.AcceptChanges();
            
            await selectResult.ToSparqlXmlResultAsync(Path.Combine(Environment.CurrentDirectory, "RDFSelectQueryResultTest_ShouldSerializeSelectQueryResultToFileAsync.srx"));
            
            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, "RDFSelectQueryResultTest_ShouldSerializeSelectQueryResultToFileAsync.srx")));

            RDFSelectQueryResult selectResult2 = await RDFSelectQueryResult.FromSparqlXmlResultAsync(Path.Combine(Environment.CurrentDirectory, "RDFSelectQueryResultTest_ShouldSerializeSelectQueryResultToFileAsync.srx"));

            Assert.IsNotNull(selectResult2);
            Assert.IsNotNull(selectResult2.SelectResults);
            Assert.IsTrue(selectResult2.SelectResultsCount == 1);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Count == 2);
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?S"));
            Assert.IsTrue(selectResult2.SelectResults.Columns.Contains("?T"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?S"].Equals("ex:org"));
            Assert.IsTrue(selectResult2.SelectResults.Rows[0]["?T"].Equals("hello@EN-US"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            foreach (string file in Directory.EnumerateFiles(Environment.CurrentDirectory, "RDFSelectQueryResultTest_Should*"))
                File.Delete(file);
        }
        #endregion
    }
}