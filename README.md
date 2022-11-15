# Sample Project
This is a sample project using the same technologies as the real MPT app will use, intended to be used for building a POC of pipeline solutions.

## SampleService
.NET API that manages TODOs. Just uses a List in memory for data storage.

Commands:
- `dotnet build`
- `dotnet run` (starts a web api listening on http port 5191)
- `dotnet watch` (starts a web api listening on http port 5191, restarts if/when code changes)

## SampleService.Tests
.NET XUnit project to unit test SampleService

Commands:
- `dotnet test` runs all unit tests in the project

## SampleUI
Static front-end SPA using Svelte

Commands: 
- `npm run build` package the client-side app into SampleUI/dist directory. We should then put the dist files into a static web host of some kind - S3, etc
- `npm run dev` start SampleService in watch mode (http://localhost:5191), and starts UI using Vite to serve content (http://localhost:5173) - serves from source code instead of dist, and uses hot-module reloading as code changes
- `npm run cypress:open` - opens cypress UI to run specs manually
- `npm run cypress:run` - runs cypress tests in CLI

# Pipeline Goals
- Notify slack build started for what branch/tag/who pushed if possible
- `dotnet build` in SampleService
- `dotnet test` in SampleService.Tests
- `npm run build` in SampleUI to generate dist folder
- `npm run cypress:run` in SampleUI - integration tests, currently expects a running instance of SampleService at localhost:5191, and SampleUI served from localhost:5173
- Notify slack of test results w/ link to view details
- branch or tag-dependent steps? Currently we deploy to demo if building for a `demo/*`, and stage if building for `master`
  - deploy SampleService as container somewhere
  - deploy SampleUI to S3
  - not yet implemented: flyway database migrations (talk about this.. I haven't made this API use a database / haven't had time to dig into flyway yet)
