module Document.Core

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
    | TitledSections of TitledSection list
    | TitledSection of TitledSection
    | Block of Text
    | List of Text list
    | Table of SomeTableContentType
    | Section of Section

and SomeTableContentType = LetsDesignThat

and TitledSection = { Title: string; Section: Section }

and Section = { Parts: DocPart list; BreakBefore: bool; Style: string option }
              with static member FromParts(parts) = { Parts = parts; BreakBefore = false; Style = None }