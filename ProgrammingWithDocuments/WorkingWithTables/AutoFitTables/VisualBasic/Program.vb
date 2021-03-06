'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Words. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Diagnostics

Imports Aspose.Words
Imports Aspose.Words.Tables

Namespace AutoFitTablesExample
	Public Class Program
		Public Shared Sub Main()
			' The path to the documents directory.
			Dim dataDir As String = Path.GetFullPath("../../../Data/")

			' Demonstrate autofitting a table to the window.
			AutoFitTableToWindow(dataDir)

			' Demonstrate autofitting a table to its contents.
			AutoFitTableToContents(dataDir)

			' Demonstrate autofitting a table to fixed column widths.
			AutoFitTableToFixedColumnWidths(dataDir)
		End Sub

		Public Shared Sub AutoFitTableToWindow(ByVal dataDir As String)
			'ExStart
			'ExFor:Table.AutoFit
			'ExFor:AutoFitBehavior
			'ExId:FitTableToPageWidth
			'ExSummary:Autofits a table to fit the page width.
			' Open the document
			Dim doc As New Document(dataDir & "TestFile.doc")

			Dim table As Table = CType(doc.GetChild(NodeType.Table, 0, True), Table)

			' Autofit the first table to the page width.
			table.AutoFit(AutoFitBehavior.AutoFitToWindow)

			' Save the document to disk.
			doc.Save(dataDir & "TestFile.AutoFitToWindow Out.doc")
			'ExEnd

			Debug.Assert(doc.FirstSection.Body.Tables(0).PreferredWidth.Type = PreferredWidthType.Percent, "PreferredWidth type is not percent")
			Debug.Assert(doc.FirstSection.Body.Tables(0).PreferredWidth.Value = 100, "PreferredWidth value is different than 100")
		End Sub

		Public Shared Sub AutoFitTableToContents(ByVal dataDir As String)
			'ExStart
			'ExFor:Table.AutoFit
			'ExFor:AutoFitBehavior
			'ExId:FitTableToContents
			'ExSummary:Autofits a table in the document to its contents.
			' Open the document
			Dim doc As New Document(dataDir & "TestFile.doc")

			Dim table As Table = CType(doc.GetChild(NodeType.Table, 0, True), Table)

			' Auto fit the table to the cell contents
			table.AutoFit(AutoFitBehavior.AutoFitToContents)

			' Save the document to disk.
			doc.Save(dataDir & "TestFile.AutoFitToContents Out.doc")
			'ExEnd

			Debug.Assert(doc.FirstSection.Body.Tables(0).PreferredWidth.Type = PreferredWidthType.Auto, "PreferredWidth type is not auto")
			Debug.Assert(doc.FirstSection.Body.Tables(0).FirstRow.FirstCell.CellFormat.PreferredWidth.Type = PreferredWidthType.Auto, "PrefferedWidth on cell is not auto")
			Debug.Assert(doc.FirstSection.Body.Tables(0).FirstRow.FirstCell.CellFormat.PreferredWidth.Value = 0, "PreferredWidth value is not 0")
		End Sub

		Public Shared Sub AutoFitTableToFixedColumnWidths(ByVal dataDir As String)
			'ExStart
			'ExFor:Table.AutoFit
			'ExFor:AutoFitBehavior
			'ExId:DisableAutoFitAndUseFixedWidths
			'ExSummary:Disables autofitting and enables fixed widths for the specified table.
			' Open the document
			Dim doc As New Document(dataDir & "TestFile.doc")

			Dim table As Table = CType(doc.GetChild(NodeType.Table, 0, True), Table)

			' Disable autofitting on this table.
			table.AutoFit(AutoFitBehavior.FixedColumnWidths)

			' Save the document to disk.
			doc.Save(dataDir & "TestFile.FixedWidth Out.doc")
			'ExEnd

			Debug.Assert(doc.FirstSection.Body.Tables(0).PreferredWidth.Type = PreferredWidthType.Auto, "PreferredWidth type is not auto")
			Debug.Assert(doc.FirstSection.Body.Tables(0).PreferredWidth.Value = 0, "PreferredWidth value is not 0")
			Debug.Assert(doc.FirstSection.Body.Tables(0).FirstRow.FirstCell.CellFormat.Width = 69.2, "Cell width is not correct.")
		End Sub
	End Class
End Namespace