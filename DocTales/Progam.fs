module Main

open Expecto

[<EntryPoint>]
let main argv =
    match argv with
    | [| "tests" |] -> Tests.runTestsInAssembly { defaultConfig with ``parallel`` = false } Array.empty
    | _ ->
        let mutable stepName = "step 1"
        try
            Step1.Exercise.run ()
            //stepName <- "step 2"
            //Step2.Exercise.run ()
            //stepName <- "step 3"
            //Step3.Exercise.run ()
            //stepName <- "step 4"
            //Step4.Exercise.run ()
            //stepName <- "step 5"
            //Step5.Exercise.run ()
            //stepName <- "step 6"
            //Step6.Exercise.run ()
            //stepName <- "final step"
            //Final.Exercise.run ()
        with e ->
            Output.writeFile Seq.singleton [
                sprintf "<h1>An exception occurred during %s</h1>" stepName
                sprintf "<pre>%s\n%s</pre>" e.Message e.StackTrace
            ]
        0