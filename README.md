# helloworld

Simple helloworld program variant to teach different basic skills, the intention is to familairize with concepts which are required to be full stack developer

1. Create a github account(https://github.com/signup?ref_cta=Sign+up&ref_loc=header+logged+out&ref_page=%2F&source=header-home) account (To know more about git https://jwiegley.github.io/git-from-the-bottom-up/1-Repository/1-directory-content-tracking.html)
2. Do the following https://docs.github.com/en/get-started/quickstart/hello-world
3. Clone this repository on your local
4. Create a branch from this(https://github.com/krantikaridev/helloworld/) repository named after username(see your git profile, mine is https://github.com/krantikaridev so my username is krantikaridev) we will use "yourprofilename" as eg in follwing step 
5. Push this branch with comment "Branch {branchname} created", you should be able to see the same at https://github.com/krantikaridev/helloworld/branches
6. Write helloworld in language of your choice(java(https://www.learnjavaonline.org/en/Hello,_World!),python(https://www.learnpython.org/en/Hello%2C_World%21),c#(https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/hello-world),javascript(https://javascript.info/hello-world))
7. Do Step 5 with comment, "Basic hello world in {language:python,java etc}" 
8. Expose the hellowolrd through rest API(eg: http://localhost/api/helloworld), Create a get API method which returns "Hello World!"
9. Do Step 5 with comment, "Basic hello world through API"
10. Update the **rest api** to support name as argument (ex:http://localhost/api/helloworld?name=name), if the named argument is null the API should return Hello World! instead other wise it should return "Heloo {name}!"
11. Do Step 5 with comment "Basic hello world API with parameter name"
12. Learn about docker your application (https://hub.docker.com/ , https://hub.docker.com/hello-world), create dockerhub account
13. Dockerize your application
14. Do Step 5 with comment "Dockerized"
15. Create **Docker** Image(yourprofilename_helloworld) and use and run the same on local
16. Do Step 6
17. Learn Docker-Compose, Required for step 17,19
18. Do step 5
19. Add **cache**(eg: redis  etc) project(dockerized), use cache to store the username parameter, and show the count eg: http://localhost/api/helloworld?name=yourprofilename will give "Hello {yourprofilename}({count})" here count will be 1,2,3,4 depending on how many time you call the api, the count can be kept in cache
20. Do step 5
21. Add **database**(mysql, postgres etc) project, store the yourprofilename in dataqbase, show the count just like cache, (dockerrize)
22. Do step 5
23. CI/CD https://docs.github.com/en/actions/quickstart Use **git action** to host Create the docker image whenever there is a change in your branch, also integrate linting, if the app is hosted it should be update git action accordingly
24. https://kubernetes.io/docs/tutorials/hello-minikube/  containerized applications
25. host your application into **cloud** (heroku - http://helloradhika.heroku.com/api/helloworld)
26. host https://www.helloworld.hitalent.org/{profilename/branchname}/api/hellowold?name=madan
27. Add authentication layer (Token Based, https://auth0.com/learn/token-based-authentication-made-easy/, https://blog.restcase.com/4-most-used-rest-api-authentication-methods/ try at least two), if the user is authenticated, everything should be in capital instead of small, eg: HELLO WORLD!
28. Do Step 5
29. Create simple HTML page using any of the following javascript, react, angular. This page will simply take input from a text box(yourprofilename) and print Hello {yourprofilename} on the screen, it should be bold if it is authenticated request
30. Host at https://www.helloworld.hitalent.org/{branchname}
