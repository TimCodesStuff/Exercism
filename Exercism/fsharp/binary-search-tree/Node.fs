module Node

type Node = {
    data : int;
    mutable left: Node option;
    mutable right: Node option;
    }

let CreateNode (rootData : int) =
    {
        data = rootData;
        left = None;
        right = None;
    }