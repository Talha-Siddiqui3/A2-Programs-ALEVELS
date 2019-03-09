Module Module1
    Dim TopStackPtr As Integer 'ALways points to current TopMostElement in STACK
    Dim Stack(9) As String 'STACK OF 10 Elements(0-9)

    Sub Main()
        TopStackPtr = -1 'Initially empty stack so points to -1(NULLPOINTER)
        Dim MenuChoice As Integer = 0
        While MenuChoice <> 3
            Console.WriteLine("1: to PUSH to STACK.")
            Console.WriteLine("2: to POP to STACK.")
            Console.WriteLine("3: Exit")

            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1 : Push()
                Case 2 : Pop()
                Case 3
                Case Else : Console.WriteLine("Wrong Choice. Please try again")
            End Select

        End While


    End Sub

    Private Sub Push()
        'TopStackPtr + 1 means next free space in stack
        If (TopStackPtr + 1) > 9 Then
            Console.WriteLine("Your Stack is full.")
            Exit Sub
        End If
        Dim Data As String
        Console.WriteLine("Enter data to be inserted to stack.")
        Data = Console.ReadLine
        Stack(TopStackPtr + 1) = Data
        TopStackPtr += 1
    End Sub

    Private Sub Pop()
        If (TopStackPtr < 0) Then
            Console.WriteLine("Your Stack is Empty.")
            Exit Sub
        End If
        Console.WriteLine(Stack(TopStackPtr))
        TopStackPtr -= 1
    End Sub

End Module
