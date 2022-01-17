Simple helloworld program variant to teach different basic skills, the intention is to familairize with concepts which are required to be a full stack developer

### Git

1. Create a [github account](https://github.com/signup?ref_cta=Sign+up&ref_loc=header+logged+out&ref_page=%2F&source=header-home) ,
2. If you are not familiar with github do the following
   * https://jwiegley.github.io/git-from-the-bottom-up/1-Repository/1-directory-content-tracking.html
   * https://docs.microsoft.com/en-us/learn/modules/introduction-to-github/ it is recommended that you create a account so that your progress is public eg:https://docs.microsoft.com/en-us/users/krantikaridev/
   * https://docs.github.com/en/get-started/quickstart/hello-world
3. Share your git profile with us(eg:https://github.com/krantikaridev) on [Slack](https://hitalentt.slack.com/archives/C02JU0EELGN), we will add you to this repository 
4. Clone this repository on your local system
5. Create a branch from this [repository](https://github.com/krantikaridev/helloworld/), the branch should be named after your git username(see your git profile, mine is https://github.com/krantikaridev so my username is krantikaridev) we will use "$yourprofilename" as eg in follwing steps 
6. Push this branch with comment "Branch {$yourprofilename} created"

### Getting Familiar with Language
* Write helloworld in language of your choice [java](https://www.learnjavaonline.org/en/Hello,_World!), [python](https://www.learnpython.org/en/Hello%2C_World%21), [c#] (https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/tutorials/hello-world),[javascript](https://javascript.info/hello-world)
* Push your changes with comment, "Basic hello world in {$language:python, java, javascript, c# etc}" 

### Rest Api
* Expose the hellowolrd through **[rest API](https://www.redhat.com/en/topics/api/what-is-a-rest-api)**(eg: http://localhost/api/helloworld), Create a get API method which returns "Hello World!"
  * [Javascript](https://nodejs.org/en/docs/guides/getting-started-guide/)
* Push your changes with comment, "Basic hello world through API"
* Update the **rest api** to support name as **argument** (ex:http://localhost/api/helloworld?name=name), if the named argument is null the API should return Hello World! instead other wise it should return "Heloo {name}!"
* Do Step 5 with comment "Basic hello world API with parameter name"

### Docker
* create dockerhub account
* Learn about **docker** (https://www.youtube.com/watch?v=Gw2Jrid4SaQ&list=WL&index=11&ab_channel=CodeWithHarry , https://hub.docker.com/ , https://hub.docker.com/hello-world), 
* Dockerize your application (your application should be able to run using docker instead of traditional approach)
* Push your changes with comment, "Dockerized"
* Create **Docker** Image(yourprofilename_helloworld) and use and run the same on local, u should be able to run it through eg: docker run -d -p kali-linux kalilinux/kali-rolling:latest


### Database
* Add **database**(mysql, postgres etc) project, store the yourprofilename in dataqbase, show the count just like cache, (dockerrize)


### Docker-Compose
* Learn **Docker-Compose**, Required for step 20,22 now 
* Use docker compose in helloworld, your application should be able to run using docker-compose up

### Cache
* Add **cache**(eg: redis etc) project(dockerized), use cache to store the username parameter, and show the count eg: http://localhost/api/helloworld?name=yourprofilename will give "Hello {yourprofilename}({count})" here count will be 1,2,3,4 depending on how many time you call the api, the count can be kept in cache
* Push your changes with comment, "Introduced Cache"

### CI/CD
* CI/CD https://docs.github.com/en/actions/quickstart Use **git action** to host Create the docker image whenever there is a change in your branch, also integrate linting, if the app is hosted it should be update git action accordingly

### Cloud
## VM
* host your application into **cloud** (use heroku eg: http://helloradhika.heroku.com/api/helloworld, or AWS or Google VM, you can use docker-compose for hosting on VM), on vm u would need dokcer, docker-compose, git installed, then u can clone the repository and simply run docker-compose up
## Kubernetes
* learn about kubernetes
  * https://kubernetes.io/docs/tutorials/hello-minikube
  * https://docs.microsoft.com/en-us/learn/modules/intro-to-kubernetes/ 
  * https://minikube.sigs.k8s.io/docs/start/
* Now instead of docker-compose use **Kubernetes** for hosting the application, this basically is useful for supporting **scaling**
* Update **CI/CD** so that your changes are updated on the hosting automatically (eg: http://helloradhika.heroku.com/api/helloworld)
* Do step 5, **CI/CD** should be able to update the hosted app eg: eg: http://helloradhika.heroku.com/api/helloworld

### Security
* Add authentication layer (Token Based, https://auth0.com/learn/token-based-authentication-made-easy/, https://blog.restcase.com/4-most-used-rest-api-authentication-methods/ try at least two), if the user is authenticated, everything should be in capital instead of small, eg: HELLO WORLD!, **security Step**, as an additional step one can provide login/signup using google oauth (https://oauth.net/)
* Do Step 5, **CI/CD** should be able to update the hosted app eg: eg: http://helloradhika.heroku.com/api/helloworld

### Front End
* Create simple HTML page using any of the following **javascript**, **react**, **angular**. This page will simply take input from a text box(yourprofilename) and print Hello {yourprofilename} on the screen, it should be bold if it is **authenticated** request,for passing the authentication token you should use cokkies or local stogrege of broser, so presence of this token and absense of it will determine whether one is authenticated or not. once this step is done you should see the same at eg:http://helloradhika.heroku.com at the same time api can be accessed at http://helloradhika.heroku.com/api/helloworld, this should be seen as seperate project it's just using the API in the backend, if u have done 31 it should be esiaer to use google outh so you can skip the cookie part
* Do Step 5, CI/CD should be able to update the hosted app eg: eg: http://helloradhika.heroku.com/api/helloworld, CI/CD should be able to update the hosted app eg: eg: http://helloradhika.heroku.com might have to update the CI/CD pipeline
