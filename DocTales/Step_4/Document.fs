[<AutoOpen>]
module Step4.Core

type Emphasis = | Regular | Medium | Strong
type TextPart = { Text:string; Emphasis:Emphasis; Style:string option }
                with static member Regular(text) = { Text=text; Emphasis=Regular; Style=None }
                     static member Medium(text) = { Text=text; Emphasis=Medium; Style=None }
                     static member Strong(text) = { Text=text; Emphasis=Strong; Style=None }

type Text = Text of TextPart list
            with static member Regular(text) = Text([TextPart.Regular(text)])
                 static member Medium(text) = Text([TextPart.Medium(text)])
                 static member Strong(text) = Text([TextPart.Strong(text)])
                 static member Block(text) = Text.Regular(text) |> Block
                 static member List(items) = items |> (List.map Text.Regular) |> List

and DocPart =
    | Block of Text
    | List of Text list
