Sub SelectRepresentativeData()
    Dim lastRow As Long
    Dim i As Long, j As Long
    Dim currentID As String
    Dim firstDupRow As Long, lastDupRow As Long
    Dim bottomRow As Long
    Dim matchFound As Boolean
    
    Application.ScreenUpdating = False
    
    lastRow = Cells(Rows.Count, 2).End(xlUp).Row
    
    ' Start processing each unique project_readfile_id
    For i = 2 To lastRow
        If Cells(i, 2).Value <> "" Then
            currentID = Cells(i, 2).Value
            
            ' Find the last row for the current project_readfile_id
            For j = i To lastRow
                If Cells(j, 2).Value <> currentID Then
                    Exit For
                End If
            Next j
            lastDupRow = j - 1
            
            ' Process the current project_readfile_id
            bottomRow = lastDupRow
            matchFound = False
            For j = lastDupRow To i Step -1
                If Cells(j, 16).Value = "match" Then
                    bottomRow = j
                    matchFound = True
                    Exit For
                End If
            Next j
            
            If matchFound Then
                Cells(bottomRow, 17).Value = "select"
            Else
                ' If all rows have no "match" in column P, provide "check" at the top row
                Cells(i, 17).Value = "check"
            End If
            
            ' Move to the next unique project_readfile_id
            i = lastDupRow
        End If
    Next i
    
    Application.ScreenUpdating = True
End Sub



