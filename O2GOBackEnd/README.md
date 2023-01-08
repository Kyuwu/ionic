# Running guide for the back-end
To run, you'll need:<br>
1. .NET installed<br>
2. Go to the root of the project in the terminal, so that will be the folder O2GOBackEnd <br>
3. If you go to the https localhost which is given, you'll need to add `/swagger/index.html` to see the swagger documentation. It will be something like this `https://localhost:{port}/swagger/index.html`.<br>
4. In postman or in the swagger UI you'll be able to test the calls.<br>

# DOCKER
1. docker build -t backendimage -f Dockerfile . 
2. docker run -d -p 8080:80 --name backendcontainer backendimage