Module Module1
    Structure StackNode
        Dim Data As String
        Dim Pointer As Integer
    End Structure



    Dim TopStackPtr As Integer 'ALways points to current TopMostElement in STACK
    Dim Stack(9) As StackNode 'STACK OF 10 Elements(0-9)
    Dim FreeListPtr As Integer

    Sub Main()
        TopStackPtr = -1 'Initially empty stack so points to -1(NULLPOINTER)
        Call InitializeStackWithFreeList()

        Dim MenuChoice As Integer = 0
        While MenuChoice <> 4
            Console.WriteLine("1: to PUSH to STACK.")
            Console.WriteLine("2: to POP to STACK.")
            Console.WriteLine("3: to OUTPUT STACK.")
            Console.WriteLine("4: Exit")

            MenuChoice = Console.ReadLine
            Select Case MenuChoice
                Case 1 : Push()
                Case 2 : Pop()
                Case 3 : Output()
                Case 4
                Case Else : Console.WriteLine("Wrong Choice. Please try again")
            End Select

        End While


    End Sub

    Sub InitializeStackWithFreeList()
        FreeListPtr = 0
        For i = 0 To 9
            Stack(i).Pointer = i + 1
        Next
        Stack(9).Pointer = -1
    End Sub


    Sub Output()
        Dim i As Integer = -1
        Dim tempTopStackPtr = TopStackPtr 'So that stack is only shown on screen instead of all elements poped out xD
        While tempTopStackPtr <> -1
            i = Stack(tempTopStackPtr).Pointer + 1
            Console.WriteLine("Index:" & i & Space(3) & Stack(tempTopStackPtr).Data & Space(3) & Stack(tempTopStackPtr).Pointer)
            tempTopStackPtr = Stack(tempTopStackPtr).Pointer
        End While
    End Sub

    Private Sub Push()
        Dim NewNodePtr As Integer
        Dim Data As String
        If (FreeListPtr) = -1 Then
            Console.WriteLine("Your Stack is full as there is no node available in free list.")
            Exit Sub
        End If
        NewNodePtr = FreeListPtr
        FreeListPtr = Stack(FreeListPtr).Pointer 'Setting freepointer to next free node.
        Console.WriteLine("Enter data to be inserted to stack.")
        Data = Console.ReadLine
        Stack(NewNodePtr).Data = Data
        Stack(NewNodePtr).Pointer = TopStackPtr 'initially will be equal to -1 but gradually will point to node below it in stack
        TopStackPtr = NewNodePtr
    End Sub

    Private Sub Pop()
        Dim currentNodePtr = TopStackPtr
        If (TopStackPtr = -1) Then
            Console.WriteLine("Your Stack is Empty.")
            Exit Sub
        End If
        Console.WriteLine(Stack(TopStackPtr).Data)
        TopStackPtr = Stack(currentNodePtr).Pointer 'Moving top of stack to node below the which it is currently pointing to
        Stack(currentNodePtr).Pointer = FreeListPtr
        FreeListPtr = currentNodePtr 'Setting free list pointer to the TopStack node (the one which we are currenlt poping out)
    End Sub

End Module
