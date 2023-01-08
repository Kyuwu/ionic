# Running guide for the back-end
To run, you'll need:<br>
1. .NET 6 installed<br>
2. Go to the root of the project in the terminal, so that will be the folder O2GOBackEnd. Type 'dotnet run' or use a editor to run the application. <br>
3. If you go to the https localhost which is given, you'll need to add `/swagger/index.html` to see the swagger documentation. 
It will be something like this `https://localhost:{port}/swagger/index.html`.<br>

# DOCKER
1. docker build -t backendimage -f Dockerfile . 
2. docker run -d -p 8080:80 --name backendcontainer backendimage