Module Module1

    Structure NODE
        Dim LeftPointer As Integer
        Dim Data As String
        Dim RightPointer As Integer
    End Structure

    'Binary tree array of size 5(0-4)
    Dim Nodes(4) As NODE

    Dim TopStackPtr As Integer 'ALways points to current TopMostElement in STACK
    Dim Stack(4) As NODE 'STACK OF 4 NODES(0-4)


    Sub Main()
        TopStackPtr = -1 'Initially empty stack so points to -1(NULLPOINTER)
        For count = 0 To 4
            Nodes(count).LeftPointer = -1
            Nodes(count).Data = ""
            Nodes(count).RightPointer = -1
        Next

        'Input Cities in any order
        For count = 0 To 4
            Console.WriteLine("Enter City Name " & (count + 1) & ": ")
            Call insertBT(Console.ReadLine)
        Next

        'OUTPUT BINARY TREE
        Console.WriteLine() 'JUST TO LEAVE A LINE IN OUTPUT
        For count = 0 To 4
            Dim currentNode = Nodes(count)
            Console.WriteLine(count & Space(7) & currentNode.LeftPointer & Space(3) & currentNode.Data & Space(12 - Len(currentNode.Data)) & currentNode.RightPointer)
        Next

        'TraverseInOrderAndPrint
        Console.WriteLine() 'JUST TO LEAVE A LINE IN OUTPUT
        Call TraverseBinaryTreeInOrder()

        Console.ReadKey()
    End Sub

    Sub insertBT(ByVal Val As String)

        If Nodes(0).Data = "" Then
            'IF inserting first value 
            Nodes(0).Data = Val

        Else
            Call SelectLeftOrRightNode(0, Val)
        End If


    End Sub

    Sub SelectLeftOrRightNode(ByVal curPos As Integer, ByVal Val As String)
        If (Val > Nodes(curPos).Data) Then
            FindNodeRight(curPos, Val)
        Else
            FindNodeLeft(curPos, Val)
        End If
    End Sub

    Sub FindNodeRight(ByVal curPos As Integer, ByVal Val As String)
        Dim TempPos = 0
        If Nodes(curPos).RightPointer = -1 Then
            'Find any next available free space in array linearly
            While (Nodes(TempPos).Data <> "")
                TempPos += 1
            End While
            Nodes(TempPos).Data = Val
            Nodes(curPos).RightPointer = TempPos
        Else
            curPos = Nodes(curPos).RightPointer
            SelectLeftOrRightNode(curPos, Val)
        End If

    End Sub

    Sub FindNodeLeft(ByVal curPos As Integer, ByVal Val As String)
        Dim TempPos = 0
        If Nodes(curPos).LeftPointer = -1 Then
            'Find any next available free space in array linearly
            While (Nodes(TempPos).Data <> "")
                TempPos += 1
            End While
            Nodes(TempPos).Data = Val
            Nodes(curPos).LeftPointer = TempPos
        Else
            curPos = Nodes(curPos).RightPointer
            SelectLeftOrRightNode(curPos, Val)
        End If

    End Sub

    Private Sub Push(ByVal node As NODE)
        'TopStackPtr + 1 means next free space in stack
        Stack(TopStackPtr + 1) = node
        TopStackPtr += 1
    End Sub

    Private Function Pop() As NODE
        Dim tempTopStackNode As NODE = Stack(TopStackPtr)
        Console.WriteLine(tempTopStackNode.Data)
        TopStackPtr -= 1
        Return tempTopStackNode
    End Function

    Private Sub TraverseBinaryTreeInOrder()

        Dim currentNode As Integer = 0
        While currentNode <> -1 Or TopStackPtr <> -1
            If (currentNode <> -1) Then
                Push(Nodes(currentNode))
                currentNode = Nodes(currentNode).LeftPointer
            Else
                currentNode = Pop().RightPointer
            End If
        End While
    End Sub


End Module
