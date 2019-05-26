Module Module1


    Sub Main()
        Dim unsortedArray() As Integer = {7, 5, 16, 1, -6}
        InsertSortPP(unsortedArray)
        For x = 0 To 4
            Console.WriteLine(unsortedArray(x))
        Next
        Console.ReadKey()


    End Sub



    Sub InsertSortPP(ByRef myArr() As Integer)
        'HolePosition is the position at which the value currently checked will later be inserted
        Dim HolePosition As Integer = 0
        Dim ValueToInsert As Integer = 0

        For CurrPointer = 1 To 4 '(FOR PSEDUCODE USE 2 To 5)
            'Initilly hole is at the same position where the value checked is as no comparision is made yet.
            ValueToInsert = myArr(CurrPointer)
            HolePosition = CurrPointer
            While (HolePosition > 0 AndAlso myArr(HolePosition - 1) > ValueToInsert) 'OR it can be vice versa i.e:  ValueToInsert < HolePosition-1
                'Shift the value(s) to the right
                myArr(HolePosition) = myArr(HolePosition - 1)
                'Shift the hole to the left
                HolePosition = HolePosition - 1
            End While

            'Finally when no value is greater than the current value checked it is inserted at hole position
            myArr(HolePosition) = ValueToInsert

        Next
    End Sub

End Module


