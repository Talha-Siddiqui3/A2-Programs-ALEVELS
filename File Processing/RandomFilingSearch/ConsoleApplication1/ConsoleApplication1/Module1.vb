Module Module1


    Structure studentRecord
        Dim rollNo As Integer
        <VBFixedString(20)> Dim Name As String
    End Structure

    Sub Main()
        Dim stuRec As studentRecord
        Dim currentRec As Integer = 1
        Dim totalRecords As Integer
        Dim recordFound As Boolean = False
        Dim recordToSearch As String

        FileOpen(1, "D:\SortedFile", OpenMode.Random, OpenAccess.ReadWrite, , Len(stuRec))
        totalRecords = LOF(1) / Len(stuRec)

        Console.WriteLine("Enter the record you want to find")
        recordToSearch = Console.ReadLine()

        While currentRec <= totalRecords And recordFound = False
            FileGet(1, stuRec, currentRec)
            If stuRec.Name = recordToSearch & Space(20 - Len(recordToSearch)) Then  'HAD TO USE EXTRA SPACES BECAUSE REST OF THE STRING IS EMPTY, OTHERWISE THERE WOULD BE FALSE COMPARISON
                recordFound = True
                Console.WriteLine("YOUR Roll No IS " & stuRec.rollNo & " :)")
            Else
                Console.WriteLine("FALSE")
            End If
            currentRec += 1
        End While

        If recordFound = False Then
            Console.WriteLine("RECORD NOT FOUND")
        End If

        Console.ReadKey()
    End Sub

End Module
