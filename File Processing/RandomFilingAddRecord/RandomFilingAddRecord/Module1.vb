Module Module1
 Structure studentRecord
        Dim rollNo As Integer
        <VBFixedString(20)> Dim Name As String
    End Structure

    Sub Main()
        Dim stuRec As studentRecord
        Dim nextRecPosition As Integer

        Console.WriteLine("Enter Student's RollNo: ")
        stuRec.rollNo = Console.ReadLine()

        Console.WriteLine("Enter Student's Name: ")
        stuRec.Name = Console.ReadLine()

        FileOpen(1, "D:\UnSortedFile", OpenMode.Random, OpenAccess.ReadWrite, , Len(stuRec))
        nextRecPosition = (LOF(1) / Len(stuRec)) + 1
        FilePut(1, stuRec, nextRecPosition)

        FileClose()
        Console.ReadKey()


    End Sub

End Module
