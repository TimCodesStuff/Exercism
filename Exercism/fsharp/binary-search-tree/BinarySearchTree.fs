module BinarySearchTree

open Node

let left node  = node.left
let right node = node.right
let data node = node.data

let rec AddNodeToTree (treeRoot : Node) (nodeToAdd : Node) =
    if (data treeRoot) >= (data nodeToAdd) then
        match left treeRoot with 
        | Some leftNode -> AddNodeToTree leftNode nodeToAdd |> ignore
        | None -> treeRoot.left <- Some nodeToAdd
    else
        match right treeRoot with 
        | Some rightNode -> AddNodeToTree rightNode nodeToAdd |> ignore
        | None -> treeRoot.right <- Some nodeToAdd

    treeRoot

let create (items : int seq) =
    let rootNode = CreateNode (Seq.head items)
    items 
    |> Seq.tail
    |> Seq.fold (fun root newData -> AddNodeToTree root (CreateNode newData)) rootNode

let sortedData node =
    let rec getData (rootNode: Node) (sortedDataList : int list) = 
        let listWithLeftData = 
            match left rootNode with
            | Some leftNode -> getData leftNode sortedDataList
            | None -> sortedDataList

        let listWithNodeData = 
            List.append listWithLeftData [rootNode.data]

        match right rootNode with 
        | Some rightNode -> getData rightNode listWithNodeData
        | None -> listWithNodeData

    getData node []