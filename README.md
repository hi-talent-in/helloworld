# helloworld

Simple helloworld program variant to teach different basic skills, the intention is to familairize with concepts which are required to be full stack developer

1. Create a git account 
2. https://docs.github.com/en/get-started/quickstart/hello-world
3. Create a branch from this repository named after username(see your git profile is https://github.com/krantikaridev so my username is krantikaridev) we will use "yourprofilename" as eg in follwing step 
4. Write helloworld in language of your choice(java(https://www.learnjavaonline.org/en/Hello,_World!),python(https://www.learnpython.org/en/Hello%2C_World%21),c#,javascript), use terminal
5. Push it to your branch named "yourprofilename"
6. Expose the hellowolrd through rest API(eg: http://localhost/api/helloworld)
7. Do Step 5
8. Update the **rest api** to support Name as argument (ex:http://localhost/api/helloworld?name=yourprofilename), if the named argument is null the API should return Hello World! instead
9. Do Step 5
11. Dockerize your application (https://hub.docker.com/ , https://hub.docker.com/_/hello-world)
12. Create **Docker** Image(yourprofilename_helloworld) and use and run the same on local
13. Learn Docker-Compose, Required for step 17,19
14. Do step 5
17. Add **cache**(eg: redis  etc) project(dockerized), use cache to store the username parameter, and show the count eg: http://localhost/api/helloworld?name=yourprofilename will give "Hello {yourprofilename}({count})" here count will be 1,2,3,4 depending on how many time you call the api, the count can be kept in cache
18. Do step 5
19. Add **database**(mysql, postgres etc) project, store the yourprofilename in dataqbase, show the count just like cache, (dockerrize)
20. Do step 5
21. CI/CD https://docs.github.com/en/actions/quickstart Use **git action** to host on cloud, or code analysis, quality check
22. https://kubernetes.io/docs/tutorials/hello-minikube/  containerized applications
23. host your application into **cloud** (heroku - http://helloradhika.heroku.com/api/helloworld)
24. Add authentication layer (Token Based, https://auth0.com/learn/token-based-authentication-made-easy/, https://blog.restcase.com/4-most-used-rest-api-authentication-methods/ try at least two), if the user is authenticated, everything should be in capital instead of small, eg: HELLO WORLD!
25. Do Step 5
26. Create simple HTML page using any of the following javascript, react, angular. This page will simply take input from a text box(yourprofilename) and print Hello {yourprofilename} on the screen, it should be bold if it is authenticated request
