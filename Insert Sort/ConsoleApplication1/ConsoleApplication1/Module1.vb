Module Module1

    Sub Main()
        Dim myArr(5) As Integer
        myArr(0) = 7
        myArr(1) = 5
        myArr(2) = 16
        myArr(3) = 1
        myArr(4) = -6
        Dim temp As Integer = 0

        For j = 1 To 4
            For i = 0 To (j - 1)
                If myArr(j) < myArr(i) Then
                    temp = myArr(j)
                    For k = j To (i + 1) Step -1
                        myArr(k) = myArr(k - 1)
                    Next
                    myArr(i) = temp
                    Exit For
                End If
            Next
        Next

        For x = 0 To 4
            Console.WriteLine(myArr(x))
        Next
        Console.ReadKey()


    End Sub

End Module
