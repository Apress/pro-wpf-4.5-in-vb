Imports System.Data
Imports System.Globalization

Public Class StoreDataSetPaginator
	Inherits DocumentPaginator
	Private dt As DataTable

	' Could be wrapped with public properties that call PaginateData() when set.
	Private typeface As Typeface
	Private fontSize As Double
	Private margin As Double

	Public Sub New(ByVal dt As DataTable, ByVal typeface As Typeface, ByVal fontSize As Double, ByVal margin As Double, ByVal pageSize As Size)
		Me.dt = dt
		Me.typeface = typeface
		Me.fontSize = fontSize
		Me.margin = margin
        Me._pageSize = pageSize
        PaginateData()
    End Sub

    Public Overrides ReadOnly Property IsPageCountValid() As Boolean
        Get
            Return True
        End Get
    End Property

    Private _pageCount As Integer
    Public Overrides ReadOnly Property PageCount() As Integer
        Get
            Return _pageCount
        End Get
    End Property

    Private _pageSize As Size
    Public Overrides Property PageSize() As Size
        Get
            Return _pageSize
        End Get
        Set(ByVal value As Size)
            _pageSize = value
            PaginateData()
        End Set
    End Property

    Public Overrides ReadOnly Property Source() As IDocumentPaginatorSource
        Get
            Return Nothing
        End Get
    End Property


    ' This helper method splits the data into pages.
    ' In some cases you'll need to store objects representing the per-page data.
    ' Here, a rowsPerPage value is enough becuase every page is the same.
    Private rowsPerPage As Integer
    Private Sub PaginateData()
        ' Create a test string for the purposes of measurement.
        Dim text As FormattedText = GetFormattedText("A")

        ' Count the lines that fit on a page.
        rowsPerPage = CInt(Fix((_pageSize.Height - margin * 2) / text.Height))

        ' Leave a row for the headings
        rowsPerPage -= 1

        _pageCount = CInt(Fix(Math.Ceiling(CDbl(dt.Rows.Count) / rowsPerPage)))
    End Sub

    Public Overrides Function GetPage(ByVal pageNumber As Integer) As DocumentPage
        ' Create a test string for the purposes of measurement.
        Dim text As FormattedText = GetFormattedText("A")
        ' Size columns relative to the width of one "A" letter.
        ' It's a shortcut that works in this example.
        Dim col1_X As Double = margin
        Dim col2_X As Double = col1_X + text.Width * 15

        ' Calculate the range of rows that fits on this page.
        Dim minRow As Integer = pageNumber * rowsPerPage
        Dim maxRow As Integer = minRow + rowsPerPage

        ' Create the visual for the page.
        Dim visual As New DrawingVisual()

        ' Initially, set the position to the top-left corner of the printable area.
        Dim point As New Point(margin, margin)

        ' Print the column values.
        Using dc As DrawingContext = visual.RenderOpen()
            ' Draw the column headers.
            Dim columnHeaderTypeface As New Typeface(typeface.FontFamily, FontStyles.Normal, FontWeights.Bold, FontStretches.Normal)
            point.X = col1_X
            text = GetFormattedText("Model Number", columnHeaderTypeface)
            dc.DrawText(text, point)
            text = GetFormattedText("Model Name", columnHeaderTypeface)
            point.X = col2_X
            dc.DrawText(text, point)

            ' Draw the line underneath.
            dc.DrawLine(New Pen(Brushes.Black, 2), New Point(margin, margin + text.Height), New Point(_pageSize.Width - margin, margin + text.Height))

            point.Y += text.Height

            ' Draw the column values.
            For i As Integer = minRow To maxRow - 1
                ' Check for the end of the last (half-filled) page.
                If i > (dt.Rows.Count - 1) Then
                    Exit For
                End If

                point.X = col1_X
                text = GetFormattedText(dt.Rows(i)("ModelNumber").ToString())
                dc.DrawText(text, point)

                ' Add second column.                    
                text = GetFormattedText(dt.Rows(i)("ModelName").ToString())
                point.X = col2_X
                dc.DrawText(text, point)
                point.Y += text.Height
            Next
        End Using
        Return New DocumentPage(visual)
    End Function


	Private Function GetFormattedText(ByVal text As String) As FormattedText
		Return GetFormattedText(text, typeface)
	End Function
	Private Function GetFormattedText(ByVal text As String, ByVal typeface As Typeface) As FormattedText
		Return New FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, typeface, fontSize, Brushes.Black)
	End Function

End Class
