Module Module1
    'COPY ALL RECORDS OF FILE 1 AT THE END OF FILE 2

    Structure studentRecord
        <VBFixedString(20)> Dim name As String
        Dim gender As Char
        Dim age As Integer
        <VBFixedString(20)> Dim ID As String
    End Structure

    Sub Main()
        Dim stuRec As studentRecord
        Dim totalRecFile1 As Integer
        Dim currentRecordFile1 As Integer
        Dim nextRecordFile2 As Integer

        FileOpen(1, "D:\File1", OpenMode.Random, OpenAccess.ReadWrite, , Len(stuRec))
        FileOpen(2, "D:\File2", OpenMode.Random, OpenAccess.ReadWrite, , Len(stuRec))

        totalRecFile1 = (LOF(1) / Len(stuRec))
        nextRecordFile2 = (LOF(2) / Len(stuRec)) + 1


        For currentRecordFile1 = 1 To totalRecFile1
            FileGet(1, stuRec, currentRecordFile1)
            FilePut(2, stuRec, nextRecordFile2)
            nextRecordFile2 += 1
        Next

        FileClose()
        Console.ReadKey()
    End Sub

End Module
