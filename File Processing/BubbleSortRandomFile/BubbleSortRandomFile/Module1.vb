Module Module1
    Structure studentRecord
        Dim rollNo As Integer
        <VBFixedString(20)> Dim Name As String
    End Structure


    Sub Main()
        Dim totalRecords As Integer
        Dim stuRec As studentRecord
        Dim currentRec As Integer


        FileOpen(1, "D:\UnSortedFile", OpenMode.Random, OpenAccess.ReadWrite, , Len(stuRec))
        FileOpen(2, "D:\SortedFile", OpenMode.Random, OpenAccess.ReadWrite, , Len(stuRec))

        totalRecords = LOF(1) / Len(stuRec)

        Dim sortedArray(totalRecords) As studentRecord
        sortedArray = bubbleSort(totalRecords)

        For currentRec = 1 To totalRecords
            FilePut(2, sortedArray(currentRec - 1), currentRec)
        Next

        FileClose()
        Console.ReadKey()
    End Sub

    Function bubbleSort(ByVal totalRecords As Integer) As Array

        Dim stuRecords(totalRecords) As studentRecord
        Dim i As Integer
        Dim j As Integer
        Dim tempRec As studentRecord

        For i = 1 To totalRecords
            FileGet(1, tempRec, i)
            stuRecords(i - 1) = tempRec
        Next


        For j = 0 To totalRecords - 2
            For i = 0 To totalRecords - 2
                If stuRecords(i).rollNo > stuRecords(i + 1).rollNo Then
                    tempRec = stuRecords(i)
                    stuRecords(i) = stuRecords(i + 1)
                    stuRecords(i + 1) = tempRec

                End If
            Next
        Next


        Return stuRecords
    End Function

End Module
