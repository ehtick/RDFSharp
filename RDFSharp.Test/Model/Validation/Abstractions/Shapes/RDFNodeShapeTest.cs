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

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDFSharp.Model;

namespace RDFSharp.Test.Model;

[TestClass]
public class RDFNodeShapeTests
{
    #region Tests
    [TestMethod]
    public void ShouldCreateNodeShape()
    {
        RDFNodeShape nodeShape = new RDFNodeShape(new RDFResource("ex:nodeShape"));

        Assert.IsNotNull(nodeShape);
        Assert.IsTrue(nodeShape.Equals(new RDFResource("ex:nodeShape")));
        Assert.IsFalse(nodeShape.IsBlank);
        Assert.IsFalse(nodeShape.Deactivated);
        Assert.AreEqual(RDFValidationEnums.RDFShapeSeverity.Violation, nodeShape.Severity);
        Assert.AreEqual(0, nodeShape.MessagesCount);
        Assert.AreEqual(0, nodeShape.TargetsCount);
        Assert.AreEqual(0, nodeShape.ConstraintsCount);
    }

    [TestMethod]
    public void ShouldCreateBlankNodeShape()
    {
        RDFNodeShape nodeShape = new RDFNodeShape();

        Assert.IsNotNull(nodeShape);
        Assert.IsTrue(nodeShape.IsBlank);
        Assert.IsFalse(nodeShape.Deactivated);
        Assert.AreEqual(RDFValidationEnums.RDFShapeSeverity.Violation, nodeShape.Severity);
        Assert.AreEqual(0, nodeShape.MessagesCount);
        Assert.AreEqual(0, nodeShape.TargetsCount);
        Assert.AreEqual(0, nodeShape.ConstraintsCount);
    }

    [TestMethod]
    public void ShouldEnumerateNodeShape()
    {
        RDFNodeShape nodeShape = new RDFNodeShape(new RDFResource("ex:nodeShape"));
        int i = nodeShape.Count();

        Assert.AreEqual(0, i);
    }

    [TestMethod]
    public void ShouldDeactivateNodeShape()
    {
        RDFNodeShape nodeShape = new RDFNodeShape(new RDFResource("ex:nodeShape"));
        nodeShape.Deactivate();

        Assert.IsTrue(nodeShape.Deactivated);
    }

    [TestMethod]
    public void ShouldExportNodeShape()
    {
        RDFNodeShape nodeShape = new RDFNodeShape(new RDFResource("ex:nodeShape"));
        RDFGraph nshGraph = nodeShape.ToRDFGraph();

        Assert.IsNotNull(nshGraph);
        Assert.IsTrue(nshGraph.Context.Equals(nodeShape.URI));
        Assert.AreEqual(3, nshGraph.TriplesCount);
        Assert.IsTrue(nshGraph.ContainsTriple(new RDFTriple(nodeShape, RDFVocabulary.RDF.TYPE, RDFVocabulary.SHACL.NODE_SHAPE)));
        Assert.IsTrue(nshGraph.ContainsTriple(new RDFTriple(nodeShape, RDFVocabulary.SHACL.SEVERITY_PROPERTY, RDFVocabulary.SHACL.VIOLATION)));
        Assert.IsTrue(nshGraph.ContainsTriple(new RDFTriple(nodeShape, RDFVocabulary.SHACL.DEACTIVATED, RDFTypedLiteral.False)));
    }

    [TestMethod]
    public void ShouldExportDeactivatedNodeShape()
    {
        RDFNodeShape nodeShape = new RDFNodeShape(new RDFResource("ex:nodeShape"));
        nodeShape.Deactivate();
        RDFGraph nshGraph = nodeShape.ToRDFGraph();

        Assert.IsNotNull(nshGraph);
        Assert.IsTrue(nshGraph.Context.Equals(nodeShape.URI));
        Assert.AreEqual(3, nshGraph.TriplesCount);
        Assert.IsTrue(nshGraph.ContainsTriple(new RDFTriple(nodeShape, RDFVocabulary.RDF.TYPE, RDFVocabulary.SHACL.NODE_SHAPE)));
        Assert.IsTrue(nshGraph.ContainsTriple(new RDFTriple(nodeShape, RDFVocabulary.SHACL.SEVERITY_PROPERTY, RDFVocabulary.SHACL.VIOLATION)));
        Assert.IsTrue(nshGraph.ContainsTriple(new RDFTriple(nodeShape, RDFVocabulary.SHACL.DEACTIVATED, RDFTypedLiteral.True)));
    }
    #endregion
}