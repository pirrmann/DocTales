module Step5.Exercise

(*
//If you want to execute part of this file in the REPL, you must first load the following files:
#load "../Blank.fs"
#load "../String.fs"
#load "../Output.fs"
#load "Document.fs"
#load "HtmlRenderer.fs"

open Step5
*)

open Expecto

let shouldEqual expected actual =
  Expect.equal actual expected "Values should be equal"

// You can write tests and/or work with the REPL
// However, I don't write the tests myself anymore, that's up to you

// this run function is called in Program.fs if you execute the application
let run () =
    // Now I don't even do that.
    // You're in charge from now on.
    [
        // Now we have a few more things:
        // - sections (which should generate divs)
        // - single titled section (basically a div with a title at the beginning)
        // - titled sections (a list of numbered titled sections, generating "ol" elements)
    ] |> Output.writeFile HtmlRenderer.toHtml
