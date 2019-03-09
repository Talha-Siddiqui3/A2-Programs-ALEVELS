Module Module1

    Sub Main()

        Dim myArr(5) As Integer
        myArr(0) = 1
        myArr(1) = 2
        myArr(2) = 5
        myArr(3) = 0
        myArr(4) = -2

        Call bubbleSort(myArr, 4)
        For x = 0 To 4
            Console.WriteLine(myArr(x))
        Next
        Console.ReadKey()

    End Sub

    Sub bubbleSort(ByRef myArr() As Integer, ByVal UB As Integer)
        Dim temp As Integer = 0
        Dim swapped = True
        Dim itemsSorted As Integer = 0
        'Dim count As Integer = 0


        While (swapped)
            swapped = False

            For i = 0 To (UB - (itemsSorted + 1))
                '        count += 1
                If myArr(i) > myArr(i + 1) Then
                    swapped = True
                    temp = myArr(i)
                    myArr(i) = myArr(i + 1)
                    myArr(i + 1) = temp
                End If
            Next
            itemsSorted += 1
        End While
        ' Console.WriteLine(count)

    End Sub




End Module
