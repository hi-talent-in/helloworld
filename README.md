# helloworld

Simple helloworld program variant to teach different basic skills, the intention is to familairize with concepts which are required to be full stack developer

1. Create a github account (https://github.com/signup?ref_cta=Sign+up&ref_loc=header+logged+out&ref_page=%2F&source=header-home) (To know more about **git** https://jwiegley.github.io/git-from-the-bottom-up/1-Repository/1-directory-content-tracking.html)
2. Do the following https://docs.github.com/en/get-started/quickstart/hello-world, this step is **optional** if you are comfurtable with git you can skip this step.
3. Clone this repository on your local system, Share your git profile with us, we will add you to the repository 
5. Create a branch from this(https://github.com/krantikaridev/helloworld/) repository named after username(see your git profile, mine is https://github.com/krantikaridev so my username is krantikaridev) we will use "yourprofilename" as eg in follwing step 
6. Push this branch with comment "Branch {branchname} created"
7. Write helloworld in language of your choice(java(https://www.learnjavaonline.org/en/Hello,_World!),python(https://www.learnpython.org/en/Hello%2C_World%21),c#(https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/hello-world),javascript(https://javascript.info/hello-world))
8. Do Step 5 with comment, "Basic hello world in {language:python, java, javascript, c# etc}" 
9. Expose the hellowolrd through **rest API**(eg: http://localhost/api/helloworld), Create a get API method which returns "Hello World!"
10. Do Step 5 with comment, "Basic hello world through API"
12. Learn about **docker**, (https://hub.docker.com/ , https://hub.docker.com/hello-world), create dockerhub account
13. Dockerize your application
14. Do Step 5 with comment "Dockerized"
15. Create **Docker** Image(yourprofilename_helloworld) and use and run the same on local, u should be able to run it through eg: docker run -d -p kali-linux kalilinux/kali-rolling:latest
16. Do Step 6
17. Update the **rest api** to support name as **argument** (ex:http://localhost/api/helloworld?name=name), if the named argument is null the API should return Hello World! instead other wise it should return "Heloo {name}!"
17. Do Step 5 with comment "Basic hello world API with parameter name"
18. Learn **Docker-Compose**, Required for step 20,22 now your application should be able to run using docker-compose up
19. Do step 5
20. Add **cache**(eg: redis  etc) project(dockerized), use cache to store the username parameter, and show the count eg: http://localhost/api/helloworld?name=yourprofilename will give "Hello {yourprofilename}({count})" here count will be 1,2,3,4 depending on how many time you call the api, the count can be kept in cache
21. Do step 5
24. CI/CD https://docs.github.com/en/actions/quickstart Use **git action** to host Create the docker image whenever there is a change in your branch, also integrate linting, if the app is hosted it should be update git action accordingly
25. host your application into **cloud** (use heroku eg: http://helloradhika.heroku.com/api/helloworld, or AWS or Google VM, you can use docker-compose for hosting on VM), on vm u would need dokcer, docker-compose, git installed, then u can clone the repository and simply run docker-compose up
27. https://kubernetes.io/docs/tutorials/hello-minikube/  containerized applications
28. Now instead of docker-compose use **Kubernetes** for hosting the application, this basically is useful for supporting **scaling**
29. Update **CI/CD** so that your changes are updated on the hosting automatically (eg: http://helloradhika.heroku.com/api/helloworld)
30. Add **database**(mysql, postgres etc) project, store the yourprofilename in dataqbase, show the count just like cache, (dockerrize)
28. Do step 5, **CI/CD** should be able to update the hosted app eg: eg: http://helloradhika.heroku.com/api/helloworld
31. **Security**: Add authentication layer (Token Based, https://auth0.com/learn/token-based-authentication-made-easy/, https://blog.restcase.com/4-most-used-rest-api-authentication-methods/ try at least two), if the user is authenticated, everything should be in capital instead of small, eg: HELLO WORLD!, **security Step**, as an additional step one can provide login/signup using google oauth (https://oauth.net/)
32. Do Step 5, **CI/CD** should be able to update the hosted app eg: eg: http://helloradhika.heroku.com/api/helloworld
33. Create simple HTML page using any of the following **javascript**, **react**, **angular**. This page will simply take input from a text box(yourprofilename) and print Hello {yourprofilename} on the screen, it should be bold if it is **authenticated** request,for passing the authentication token you should use cokkies or local stogrege of broser, so presence of this token and absense of it will determine whether one is authenticated or not. once this step is done you should see the same at eg:http://helloradhika.heroku.com at the same time api can be accessed at http://helloradhika.heroku.com/api/helloworld, this should be seen as seperate project it's just using the API in the backend, if u have done 31 it should be esiaer to use google outh so you can skip the cookie part
34. Do Step 5, CI/CD should be able to update the hosted app eg: eg: http://helloradhika.heroku.com/api/helloworld, CI/CD should be able to update the hosted app eg: eg: http://helloradhika.heroku.com might have to update the CI/CD pipeline
