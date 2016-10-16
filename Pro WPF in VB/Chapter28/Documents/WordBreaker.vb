Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Documents

Public Class WordBreaker


    ' Returns a TextRange covering a word containing or following this TextPointer.

    ' If this TextPointer is within a word or at start of word, the containing word range is returned.
    ' If this TextPointer is between two words, the following word range is returned.
    ' If this TextPointer is at trailing word boundary, the following word range is returned.

    Public Shared Function GetWordRange(ByVal position As TextPointer) As TextRange
        Dim wordRange As TextRange = Nothing
        Dim wordStartPosition As TextPointer = Nothing
        Dim wordEndPosition As TextPointer = Nothing

        ' Go forward first, to find word end position.
        wordEndPosition = GetPositionAtWordBoundary(position, LogicalDirection.Forward)

        If Not wordEndPosition Is Nothing Then
            ' Then travel backwards, to find word start position.
            wordStartPosition = GetPositionAtWordBoundary(wordEndPosition, LogicalDirection.Backward)
        End If

        If Not wordStartPosition Is Nothing AndAlso Not wordEndPosition Is Nothing Then
            wordRange = New TextRange(wordStartPosition, wordEndPosition)
        End If

        Return wordRange
    End Function


    ' 1.  When wordBreakDirection = Forward, returns a position at the end of the word,
    '     i.e. a position with a wordBreak character (space) following it.
    ' 2.  When wordBreakDirection = Backward, returns a position at the start of the word,
    '     i.e. a position with a wordBreak character (space) preceeding it.
    ' 3.  Returns null when there is no workbreak in the requested direction.

	Private Shared Function GetPositionAtWordBoundary(ByVal position As TextPointer, ByVal wordBreakDirection As LogicalDirection) As TextPointer
        If (Not position.IsAtInsertionPosition) Then
            position = position.GetInsertionPosition(wordBreakDirection)
        End If

		Dim navigator As TextPointer = position
        Do While Not navigator Is Nothing AndAlso Not IsPositionNextToWordBreak(navigator, wordBreakDirection)
            navigator = navigator.GetNextInsertionPosition(wordBreakDirection)
        Loop

        Return navigator
    End Function

    ' Helper for GetPositionAtWordBoundary.
    ' Returns true when passed TextPointer is next to a wordBreak in requested direction.
    Private Shared Function IsPositionNextToWordBreak(ByVal position As TextPointer, ByVal wordBreakDirection As LogicalDirection) As Boolean
        Dim isAtWordBoundary As Boolean = False

        ' Skip over any formatting.
        If position.GetPointerContext(wordBreakDirection) <> TextPointerContext.Text Then
            position = position.GetInsertionPosition(wordBreakDirection)
        End If

        If position.GetPointerContext(wordBreakDirection) = TextPointerContext.Text Then
            Dim oppositeDirection As LogicalDirection
            oppositeDirection = If((wordBreakDirection = LogicalDirection.Forward), LogicalDirection.Backward, LogicalDirection.Forward)

            Dim runBuffer As Char() = New Char(0) {}
            Dim oppositeRunBuffer As Char() = New Char(0) {}

            position.GetTextInRun(wordBreakDirection, runBuffer, 0, 1)
            position.GetTextInRun(oppositeDirection, oppositeRunBuffer, 0, 1)

            If runBuffer(0) = " "c AndAlso Not (oppositeRunBuffer(0) = " "c) Then
                isAtWordBoundary = True
            End If
        Else
            ' If we're not adjacent to text then we always want to consider this position a "word break".  
            ' In practice, we're most likely next to an embedded object or a block boundary.
            isAtWordBoundary = True
        End If

        Return isAtWordBoundary
    End Function

End Class
