# CLI Example

This project is a .NET console app that behaves like a CLI and it uses ahead of time compilation to generate an application into a native (architecture-specific) single-file executable.

## How to use

Build the `Dockerfile`:
```bash
docker build --rm -t cli-example .
```

Run the container:
```bash
docker container run --rm cli-example help
```

## Reference
- https://github.com/dotnet/runtimelab/blob/feature/NativeAOT/samples/HelloWorld/README.md
