Module Module1
    Structure NODE
        Dim LeftPointer As Integer
        Dim Data As String
        Dim RightPointer As Integer
    End Structure
    Const NULLPOINTER = -1

    'Binary tree array of size 5(0-4)
    Dim Nodes(4) As NODE
    Dim RootPointer As Integer = NULLPOINTER
    Dim FreePointer As Integer = 0


    Sub Main()
        For count = 0 To 4
            Nodes(count).LeftPointer = -1
            Nodes(count).Data = ""
            Nodes(count).RightPointer = count + 1
        Next
        Nodes(4).RightPointer = NULLPOINTER

        'Input Cities in any order
        For count = 0 To 4
            Console.WriteLine("Enter City Name " & (count + 1) & ": ")
            Call insertBTBookWala(Console.ReadLine)
        Next

        'OUTPUT BINARY TREE
        Console.WriteLine() 'JUST TO LEAVE A LINE IN OUTPUT
        For count = 0 To 4
            Dim currentNode = Nodes(count)
            Console.WriteLine("  " & count & Space(7) & currentNode.LeftPointer & Space(3) & currentNode.Data & Space(12 - Len(currentNode.Data)) & currentNode.RightPointer)
        Next

        Console.WriteLine() 'JUST TO LEAVE A LINE IN OUTPUT
        TraverseInOrder(RootPointer)


        Console.WriteLine() 'JUST TO LEAVE A LINE IN OUTPUT
        Console.WriteLine("Please enter data to seacrch")
        Dim searchstring As String = Console.ReadLine()
        FindNodePointer(searchstring)

        Console.ReadKey()




    End Sub





    Sub insertBTBookWala(ByVal Val As String)
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
                Dim CurrPointer = RootPointer
                Dim PreviousNodePointer As Integer = 0
                Dim TurnedRight As Boolean = True
                While CurrPointer <> NULLPOINTER
                    PreviousNodePointer = CurrPointer   'MAIN STEP: 
                    'IF CurrPointer becomes nullpointer we have found the node where to add our new node but we would be needing previous node to link to it(PS IK Its confusing)
                    If (Val > Nodes(CurrPointer).Data) Then
                        CurrPointer = Nodes(CurrPointer).RightPointer        'Go to Right Pointer.
                        TurnedRight = True
                    Else
                        CurrPointer = Nodes(CurrPointer).LeftPointer         'Go to Left Pointer. 
                        TurnedRight = False
                    End If

                End While

                If TurnedRight Then
                    Nodes(PreviousNodePointer).RightPointer = NewNodePointer
                Else
                    Nodes(PreviousNodePointer).LeftPointer = NewNodePointer
                End If

            End If

        Else
            Console.WriteLine("No avialble space in free list.")
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

    Sub FindNodePointer(ByVal data As String)
        Dim currNodePointer As Integer = RootPointer
        While currNodePointer <> NULLPOINTER And data <> Nodes(currNodePointer).Data
            If data > Nodes(currNodePointer).Data Then
                currNodePointer = Nodes(currNodePointer).RightPointer
            Else
                currNodePointer = Nodes(currNodePointer).LeftPointer
            End If
        End While
        If currNodePointer = NULLPOINTER Then
            Console.WriteLine("Searched value not found")
        Else
            Console.WriteLine("Pointer is: " & currNodePointer)
        End If
    End Sub


End Module
