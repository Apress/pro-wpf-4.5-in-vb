Imports System.Globalization

Public Class HeaderedFlowDocumentPaginator
	Inherits DocumentPaginator

    Private flowDocumentPaginator As DocumentPaginator

	Public Sub New(ByVal document As FlowDocument)
		flowDocumentPaginator = (CType(document, IDocumentPaginatorSource)).DocumentPaginator
	End Sub

	Public Overrides Function GetPage(ByVal pageNumber As Integer) As DocumentPage
		' Get the requested page.
		Dim page As DocumentPage = flowDocumentPaginator.GetPage(pageNumber)

		' Wrap the page in a Visual. You can then add a transformation and extras.
		Dim newVisual As New ContainerVisual()
		newVisual.Children.Add(page.Visual)

		' Create a header. 
		Dim header As New DrawingVisual()
		Using context As DrawingContext = header.RenderOpen()
			Dim typeface As New Typeface("Times New Roman")
			Dim text As New FormattedText("Page " & (pageNumber + 1).ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, typeface, 14, Brushes.Black)

			' Leave a quarter-inch of space between the page edge and this text.
			context.DrawText(text, New Point(96*0.25, 96*0.25))
		End Using
		' Add the title to the visual.
		newVisual.Children.Add(header)

		' Wrap the visual in a new page.
		Dim newPage As New DocumentPage(newVisual)
		Return newPage
	End Function

	Public Overrides ReadOnly Property IsPageCountValid() As Boolean
		Get
			Return flowDocumentPaginator.IsPageCountValid
		End Get
	End Property

	Public Overrides ReadOnly Property PageCount() As Integer
		Get
			Return flowDocumentPaginator.PageCount
		End Get
	End Property

	Public Overrides Property PageSize() As System.Windows.Size
		Get
			Return flowDocumentPaginator.PageSize
		End Get
		Set(ByVal value As System.Windows.Size)
			flowDocumentPaginator.PageSize = value
		End Set
	End Property

	Public Overrides ReadOnly Property Source() As IDocumentPaginatorSource
		Get
			Return flowDocumentPaginator.Source
		End Get
	End Property
End Class
