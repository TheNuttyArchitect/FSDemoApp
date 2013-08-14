namespace Centric.fs.DemoConsoleApp

open System

[<AutoOpen>]
module Core = 
    type Fmap = Fmap with
        static member instance (_Functor:Fmap, x:Option<_>   , _) = fun f -> Option.map  f x
        static member instance (_Functor:Fmap, l:_ list      , _) = fun f -> List.map f l
        static member instance (_Functor:Fmap, a:_ array     , _) = fun f -> Array.map f a
        static member instance (_Functor:Fmap, e:Choice<_,_> , _) = fun f -> match e with
                                                                             | Choice1Of2 x -> f x |> Choice1Of2
                                                                             | Choice2Of2 x -> Choice2Of2 x

    let (.&.) (left:bool) (right:bool):bool = 
        left && right

    let (|=|) (left:'a) (right:'a):bool = 
        Unchecked.compare left right = 0

    let inline fmap f x = Inline.instance (Fmap, x) f
    let inline (=>>) x f = fmap f x
    let inline (<|>) x f = fmap f x

    let asOption e = 
        match e with
        | null -> None
        | _ -> Some(e)

    let compareIgnoreCase (s1:string) (s2:string) = 
        match ((s1 |> asOption),(s2|> asOption)) with
        | (None,None) -> true
        | (None,_) -> false
        | (_,None) -> false
        | _ -> 
            String.Compare(s1,s2,StringComparison.OrdinalIgnoreCase) = 0

    let (=~=) (left:string) (right:string):bool = compareIgnoreCase left right

    let (<--) (op:'a option) = match op with | Some o -> o | None -> Unchecked.defaultof<'a>

    let private parseResultAsOpt (output:bool*'a) =
        match output with
        | true, i -> Some i
        | _ -> None

    let boolTryParse b = parseResultAsOpt (Boolean.TryParse(b))

    let byteTryParse b = parseResultAsOpt (Byte.TryParse(b))

    let datetimeTryParse d = parseResultAsOpt (DateTime.TryParse(d))

    let decimalTryParse n = parseResultAsOpt (Decimal.TryParse(n))
    
    let doubleTryParse n = parseResultAsOpt (Double.TryParse(n))

    let guidTryParse g = parseResultAsOpt (Guid.TryParse(g))

    let int16TryParse n = parseResultAsOpt (Int16.TryParse(n))

    let int32TryParse n = parseResultAsOpt (Int32.TryParse(n))

    let int64TryParse n = parseResultAsOpt (Int64.TryParse(n))