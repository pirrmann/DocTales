module Final.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../String.fs"
#load "../Output.fs"
#load "Document.fs"
#load "DocumentComparer.fs"
#load "HtmlRenderer.fs"
*)

open Document
open Document.Core

let doc1 =
    [
        TitledSections [
            {
                TitledSection.Title = "This is a test"
                Section = Section.FromParts [
                    Text.Block "Hello world, I'm happy to be here today"
                    Block (Text [TextPart.Regular "I have serious doubts we'll get to this point, but if that's the case, you can all be "
                                 TextPart.Strong "very"
                                 TextPart.Regular " proud."])
                    Text.Block "Now, if you manage to do this exercise, that's awesome."
                ]
            }
        ]
    ]

let doc2 =
    [
        TitledSections [
            {
                TitledSection.Title = "This is a test"
                Section = Section.FromParts [
                    Block (Text [TextPart.Regular "Hello "
                                 TextPart.Strong "students"
                                 TextPart.Regular ", I'm "
                                 TextPart.Strong "very"
                                 TextPart.Regular " happy to be here today..."
                                 TextPart.Medium "and I hope you're happy too!"])
                    Block (Text [TextPart.Regular "I have serious doubts we'll get to this point, but if that's the case, you can all be "
                                 TextPart.Strong "very"
                                 TextPart.Regular " proud."])
                    Text.Block "Let's try to do that."
                ]
            }
        ]
    ]

let run () =
    let mergedDoc = Comparer.getMergedParts doc1 doc2
    mergedDoc |> Output.writeFile HtmlRenderer.toHtml
