Module Module1
    Structure NODE
        Dim LeftPointer As Integer
        Dim Data As String
        Dim RightPointer As Integer
    End Structure
    Const NULLPOINTER = -1

    'Binary tree array of size 8(0-7)
    Dim Nodes(7) As NODE
    Dim RootPointer As Integer = NULLPOINTER
    Dim FreePointer As Integer = 0


    Sub Main()
        For count = 0 To 7
            Nodes(count).LeftPointer = -1
            Nodes(count).Data = ""
            Nodes(count).RightPointer = count + 1
        Next
        Nodes(7).RightPointer = NULLPOINTER

        'Input Cities in any order
        For count = 0 To 7
            Console.WriteLine("Enter City Name " & (count + 1) & ": ")
            Call insertBT(Console.ReadLine)
        Next

        'OUTPUT BINARY TREE
        Console.WriteLine() 'JUST TO LEAVE A LINE IN OUTPUT
        For count = 0 To 7
            Dim currentNode = Nodes(count)
            Console.WriteLine("  " & count & Space(7) & currentNode.LeftPointer & Space(3) & currentNode.Data & Space(12 - Len(currentNode.Data)) & currentNode.RightPointer)
        Next

        Console.WriteLine() 'JUST TO LEAVE A LINE IN OUTPUT
        TraverseInOrder(RootPointer)


        Console.ReadKey()




    End Sub



    Sub insertBT(ByVal Val As String)
        Dim NewNodePointer = NULLPOINTER
        If FreePointer <> NULLPOINTER Then
            'There is space available in freelist
            'So we take node from it
            NewNodePointer = FreePointer
            FreePointer = Nodes(FreePointer).RightPointer  'Then set FreePointer to next avaialble space in array
            'As we grabbed a new node we set data to it and initially make it's left and right pointers to null
            Nodes(NewNodePointer).Data = Val
            Nodes(NewNodePointer).RightPointer = NULLPOINTER
            Nodes(NewNodePointer).LeftPointer = NULLPOINTER

            'check if the tree is empty
            If RootPointer = NULLPOINTER Then 'insert new node at root
                RootPointer = NewNodePointer
            Else
                'find insertion point
                SelectLeftOrRightNode(RootPointer, Val, NewNodePointer)
            End If

        Else
            Console.WriteLine("No avialble space in free list.")
        End If


    End Sub




    Sub SelectLeftOrRightNode(ByVal curPointer As Integer, ByVal Val As String, ByVal NewNodePointer As Integer)
        If (Val > Nodes(curPointer).Data) Then
            FindNodeRight(curPointer, Val, NewNodePointer)
        Else
            FindNodeLeft(curPointer, Val, NewNodePointer)
        End If
    End Sub

    Sub FindNodeRight(ByVal curPointer As Integer, ByVal Val As String, ByVal NewNodePointer As Integer)

        If Nodes(curPointer).RightPointer = -1 Then
            Nodes(curPointer).RightPointer = NewNodePointer
        Else
            curPointer = Nodes(curPointer).RightPointer
            SelectLeftOrRightNode(curPointer, Val, NewNodePointer)
        End If

    End Sub

    Sub FindNodeLeft(ByVal curPointer As Integer, ByVal Val As String, ByVal NewNodePointer As Integer)
        If Nodes(curPointer).LeftPointer = -1 Then
            Nodes(curPointer).LeftPointer = NewNodePointer
        Else
            curPointer = Nodes(curPointer).LeftPointer
            SelectLeftOrRightNode(curPointer, Val, NewNodePointer)
        End If

    End Sub


    Sub TraverseInOrder(ByVal CurrNodePointer As Integer)

        If CurrNodePointer <> NULLPOINTER Then

            'Keep moving left untill nullpointer
            TraverseInOrder(Nodes(CurrNodePointer).LeftPointer)


            'OUTPUT
            Console.WriteLine(Nodes(CurrNodePointer).Data)

            'Keep moving right untill nullpointer
            TraverseInOrder(Nodes(CurrNodePointer).RightPointer)


        End If

    End Sub


End Module
