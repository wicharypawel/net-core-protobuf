# Net Core Protocol Buffers

# This repository

This repository shows how to define basic Protocol Buffer (*.proto) file, generate source code for serialising and deserializing data messages. The process of working with Protocol Buffer is as follow: define proto file, generate source file native to your language using protocol buffers compiler (protoc), use in code.

## Getting started

1. Download repository 
2. Download .Net SDK (in the moment of writing 3.1.101)
3. Open in VS 2019
4. Setup startup project & start debugging

## Tools

### Generate code from proto files (command line)

1. Install the protoc compiler,
  - open https://github.com/protocolbuffers/protobuf/releases
  - download a zip pack suitable for your operating system
  - unzip the zip and open the `bin` folder
  - move the `protoc` file so that it is available in the system path (PATH)
2. (Optional) Install additional Google types,
  - Open the `include` folder located in the package
  - Move the `google` folder to a folder where *.proto files are defined
2. Open powershell
3. Navigate to `.\net-core-protobuf\NetCoreProtobuf.Proto\` folder
4. Execute command
```
protoc --proto_path=. --csharp_out=.\Generated .\Definitions\address_book.proto
protoc --proto_path=. --csharp_out=.\Generated .\Definitions\person.proto
```
__NOTE: in order to generate code for different language replace `--csharp_out` argument eg. `--java_out`__
__NOTE: this example already has included generated files into repository tree, search for result in `Generated` folder__

- (optional) change parameter `--proto_path=.\path\to\imported\proto\files` (default's to current directory)

### Generate code from proto files (Configuration for VS Code)

Install `vscode-proto3` extension in order to get first class experience when working with *.proto files. 

Features:
- code snippets,
- code completion,
- vscode commands for compiling files,
- on-save compilation for *.proto files,

Steps:
1. Install the `protoc` compiler if not installed already  
2. Install `vscode-proto3` via VS Code Extensions Marketplace
3. Restart VS Code
4. Create a folder named `.vscode` in the main repository folder
5. Create a configuration file named `settings.json` inside the newly created folder

```
{
    "protoc": {
        "compile_on_save": true,
        "options": [
            "--proto_path=.",
            "--csharp_out=out"
        ]
    }
}
```

__NOTE: adjust directories for your setup__

6. Open and save any file with the *.proto extension. The result should appear in the folder named `out`. In case of compilation errors a popup notification will be displayed.

## Sources

- https://github.com/protocolbuffers/protobuf/tree/master/csharp/src/AddressBook - code source
- https://developers.google.com/protocol-buffers/
- https://developers.google.com/protocol-buffers/docs/overview
- https://developers.google.com/protocol-buffers/docs/tutorials
- https://developers.google.com/protocol-buffers/docs/csharptutorial
- https://developers.google.com/protocol-buffers/docs/proto3
- https://developers.google.com/protocol-buffers/docs/style
- https://developers.google.com/protocol-buffers/docs/techniques