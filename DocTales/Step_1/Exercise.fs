module Step1.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../String.fs"
#load "../Output.fs"
#load "Text.fs"
#load "HtmlRenderer.fs"

open Step1
*)

open Expecto

let shouldEqual expected actual =
  Expect.equal actual expected "Values should be equal"

// You can write tests and/or work with the REPL
[<Tests>]
let tests =
    testList "Step 1" [
        test "Rendering a simple text part produces the text" {
            { Text = "text"; Emphasis=Regular } |> HtmlRenderer.toHtml |> String.concat |> shouldEqual "text"
        }

        test "Rendering a text part with emphasis applies a style" {
            { Text = "text"; Emphasis=Medium } |> HtmlRenderer.toHtml |> String.concat |> shouldEqual "<span class=\"em-medium\">text</span>"
        }
    ]

// this run function is called in Program.fs if you execute the application
let run () =
    [
        { Text = "Hello "; Emphasis=Regular }
        { Text = "World"; Emphasis=Strong }
    ] |> Output.writeFile HtmlRenderer.toHtml
