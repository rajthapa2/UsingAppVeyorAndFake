// include Fake lib
#r "tools/FAKE/tools/FakeLib.dll"
open Fake

// Properties
let buildDir = "./build/"

let restorePackages() = RestoreMSSolutionPackages (fun p -> { p with OutputPath = "./packages" }) "./SmallestThingThatWillWork.sln"

// Targets
Target "Clean" (fun _ ->
    !!"./**/bin/**" |> DeleteDirs
    !!"./**/obj/**" |> DeleteDirs
)

Target "Restore" restorePackages

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

let tests () =
    !! ("./**/bin/Release/SmallestThingThatWillWork.dll")
        |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = "./TestResults.xml" })

let build () =
    !! "./**/*.csproj"
      |> MSBuildWithDefaults "Build"
      |> Log "AppBuild-Output: "

Target "Test" tests
Target "Build" build

// Dependencies
"Clean"
  ==> "Restore"
  ==> "Build"
  ==> "Test"
  ==> "Default"

// start build
RunTargetOrDefault "Default"