Module Module1

    Structure studentRecord
        Dim rollNo As Integer
        <VBFixedString(20)> Dim Name As String
    End Structure

    Sub Main()
        Dim stuRec As studentRecord
        Dim currentRec As Integer
        Dim totalRecords As Integer

   
        FileOpen(1, "D:\SortedFile", OpenMode.Random, OpenAccess.ReadWrite, , Len(stuRec))
        totalRecords = LOF(1) / Len(stuRec)

        For currentRec = 1 To totalRecords
            FileGet(1, stuRec, currentRec)
            Console.WriteLine("RollNo: " & stuRec.rollNo)
            Console.WriteLine("Name: " & stuRec.Name)
            Console.WriteLine("NameLen: " & Len(stuRec.Name))
            
        Next

        FileClose()
        Console.ReadKey()
    End Sub
End Module
