module Document.MarkdownParser

open FSharp.Markdown
open Document.Core

let private join (vs:string seq) = System.String.Join("", vs |> Seq.toArray)
let private splitWhen predicate =
    let folder acc i =
        if predicate i || acc = [] then
            [i] :: acc
        else
            (i :: acc.Head) :: acc.Tail
    Seq.fold folder [] >> List.map (List.rev) >> List.rev

let rec private getText = function
    | Literal t -> t
    | MarkdownSpan.Emphasis t
    | MarkdownSpan.Strong t -> t |> Seq.map getText |> join
    | _ -> failwith "Unsupported markdown content"

let private fromSpans =
    let mapSpan = function
        | Literal t -> { Text=t; Emphasis=Regular; Style=None }
        | (MarkdownSpan.Emphasis _) as s -> { Text=getText s; Emphasis=Medium; Style=None }
        | (MarkdownSpan.Strong _) as s -> { Text=getText s; Emphasis=Strong; Style=None }
        | _ -> failwith "Unsupported markdown content"
    List.map mapSpan

let private toDocParts =
    function
    | Paragraph(spans) -> spans |> fromSpans |> Text |> Block
    | ListBlock(_, items) ->
        items
        |> List.collect (
            List.choose (function | Span ss -> Some ss | _ -> None)
            >> List.map (fromSpans >> Text) )
        |> List
    | _ -> failwith "Unsupported markdown content"

let ParseMarkdown s =
    (Markdown.Parse s).Paragraphs
    |> List.map toDocParts

let private parseSection doBreakBefore = function
    | Heading(_, spans) :: ps ->
        {
            Title = spans |> List.map getText |> join
            Section =
                {
                    Parts = ps |> List.map toDocParts
                    BreakBefore = doBreakBefore
                    Style = None
                }
        }
    | _ -> failwith "Invalid section"

let ParseMarkdownSection doBreak s =
    (Markdown.Parse s).Paragraphs |> (parseSection doBreak)

let ParseMarkdownSections s =
    (Markdown.Parse s).Paragraphs
    |> splitWhen (function | Heading(_,_) -> true | _ -> false)
    |> List.map (parseSection false)
