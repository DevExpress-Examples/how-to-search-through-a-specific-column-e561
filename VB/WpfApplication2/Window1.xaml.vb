Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid

Namespace WpfApplication2

	Partial Public Class Window1
		Inherits Window
		Private list As List(Of TestData)

		Public Sub New()
			InitializeComponent()

			list = New List(Of TestData)()
			For i As Integer = 0 To 99
				list.Add(New TestData() With {.Text = Guid.NewGuid().ToString(), .Number = i})
			Next i

			grid.DataSource = list
		End Sub

		Private Sub autoSearch_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
			For i As Integer = 0 To list.Count - 1
				If list(i).Text.StartsWith(autoSearch.Text) Then
					view.MoveFocusedRow(grid.GetRowHandleByListIndex(i))
					Return
				End If
			Next i
		End Sub
	End Class

	Public Class TestData
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
	End Class

End Namespace
