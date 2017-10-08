[<AutoOpen>]
module Step3.Core

type Emphasis = | Regular | Medium | Strong
type TextPart = { Text:string; Emphasis:Emphasis }
                with static member Regular(text) = { Text=text; Emphasis=Regular }
                     static member Medium(text) = { Text=text; Emphasis=Medium }
                     static member Strong(text) = { Text=text; Emphasis=Strong }

type Text = Text of TextPart list
            with static member Regular(text) = Text([TextPart.Regular(text)])
                 static member Medium(text) = Text([TextPart.Medium(text)])
                 static member Strong(text) = Text([TextPart.Strong(text)])
                 static member Block(text) = Text.Regular(text) |> Block
                 static member List(items) = items |> (List.map Text.Regular) |> List

and DocPart =
    | Block of Text
    | List of Text list
