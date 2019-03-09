Module Module1

    Sub Main()
        Dim myArr(5) As Char
        myArr(0) = "a"
        myArr(1) = "c"
        myArr(2) = "f"
        myArr(3) = "g"
        myArr(4) = "x"
        Dim UB As Integer = 4

        Console.WriteLine("Enter Search Value")
        Dim searchVal As Char = Console.ReadLine()


        'NORMAL SEARCH
        Call normalBinarySearch(UB, myArr, searchVal)

        'RECURSIVE SEARCH
        Dim result As Integer = recursiveBinarySearch(0, UB, myArr, searchVal)
        If result = -1 Then
            Console.WriteLine(searchVal & " not found")
        Else
            Console.WriteLine("Found your search value " & searchVal & " at location: " & result)
        End If

        Console.ReadKey()
    End Sub

    Sub normalBinarySearch(ByVal UB As Integer, ByRef myArr() As Char, ByVal searchVal As Char)
        Dim LB As Integer = 0
        Dim isFound As Boolean = False
        Dim MID As Integer = 0

        While (UB >= LB And isFound = False)
            MID = (UB + LB) / 2 'As the data types are integers so result is also an integer instead of decimal or we can use \'
            If myArr(MID) = searchVal Then
                Console.WriteLine("Found your search value " & searchVal & " at location: " & MID)
                isFound = True

            Else
                If myArr(MID) < searchVal Then
                    LB = MID + 1
                Else
                    UB = MID - 1
                End If
            End If
        End While

        If (isFound = False) Then
            Console.WriteLine("Search value not found in array")
        End If
    End Sub



    Function recursiveBinarySearch(ByVal LB As Integer, ByVal UB As Integer, ByRef myArr() As Char, ByVal searchVal As Char) As Integer
        Dim MID As Integer = 0
        MID = (UB + LB) / 2 'As the data types are integers so result is also an integer instead of decimal or we can use \'
        If (LB > UB) Then
            Return -1 ' MEANS NOT FOUND
        Else
            Select Case myArr(MID)
                Case searchVal : Return MID
                Case Is < searchVal : Return recursiveBinarySearch((MID + 1), UB, myArr, searchVal)
                Case Is > searchVal : Return recursiveBinarySearch(LB, (MID - 1), myArr, searchVal)
            End Select

        End If
        ' Return -1

    End Function


End Module
